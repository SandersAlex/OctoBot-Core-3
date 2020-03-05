using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ArgParse.Actions;
using ArgParse.Enums;
using ArgParse.Exceptions;
using ArgParse.Extensions;
using ArgParse.Interfaces;

namespace ArgParse
{
	public class ActionsContainer : IActionsContainer
	{
		/// <summary>
		/// Описание того, что делает программа
		/// </summary>
		private string Description { get; set; }
		/// <summary>
		/// Символы префексов для дополнительных аргументов
		/// </summary>
		private IList<string> PrefixChars { get; set; }
		private IEnumerable<string> LongPrefixes
		{
			get { return PrefixChars.Where(it => it.Length > 1); }
		}
		/// <summary>
		/// Значение по умолчанию для всех аргументов
		/// </summary>
		private object ArgumentDefault { get; set; }
		/// <summary>
		/// Строка, указывающая, на обработчик ошибок
		/// </summary>
		private ConflictHandlerType ConflictHandlerType { get; set; }

		// "Фабрика" реестра для Action's с названием action
		private readonly IDictionary<string, Func<Argument, ActionAP>> registriesActionFactories;
		private IDictionary<string, Func<Argument, ActionAP>> RegistriesActionFactories
		{
			get { return registriesActionFactories; }
		}

		private readonly IList<ActionAP> actions;
		public virtual IList<ActionAP> Actions
		{
			get { return actions; }
		}
		private readonly IDictionary<string, ActionAP> OptionStringActions;

		public IList<ArgumentGroup> ActionGroups { get; private set; }
		protected virtual IList<object> MutuallyExclusiveGroups { get; set; }

		private readonly IDictionary<string, object> Defaults;
		public string DefaultAction { get; set; }

		private readonly Regex NegativeNumberMatcher;

		public IList<object> HasNegativeNumberOptionals { get; private set; }

		private readonly IDictionary<string, Func<string, object>> typeFactoriesByName = new Dictionary<string, Func<string, object>>(StringComparer.InvariantCultureIgnoreCase);
		private readonly IDictionary<Type, Func<string, object>> typeFactoriesByType = new Dictionary<Type, Func<string, object>>();
		protected Func<string, object> DefaultTypeFactory { get; set; }

		public ActionsContainer(ParserSettings parserSettings = null, IActionsContainer container = null)
		{
			parserSettings = parserSettings ?? new ParserSettings();

			Description = parserSettings.Description;
			ArgumentDefault = parserSettings.ArgumentDefault;
			PrefixChars = parserSettings.PrefixChars;
			ConflictHandlerType = parserSettings.ConflictHandlerType;

			// Установка реестра для Action"s
			registriesActionFactories = new Dictionary<string, Func<Argument, ActionAP>>();

			// Регистрируем Action"s
			/*Register("action", "none", typeof(StoreAction));
			Register("action", "store", typeof(StoreAction));
			Register("action", "store_const", typeof(StoreConstAction));
			Register("action", "store_true", typeof(StoreTrueAction));
			Register("action", "store_false", typeof(StoreFalseAction));
			Register("action", "append", typeof(AppendAction));
			Register("action", "append_const", typeof(AppendConstAction));
			Register("action", "count", typeof(CountAction));
			Register("action", "help", typeof(HelpAction));
			Register("action", "version", typeof(VersionAction));
			Register("action", "parsers", typeof(SubParsersAction));*/
			RegisterActions(new Dictionary<string, Func<Argument, ActionAP>>() {
				{ ActionNames.NONE, arg => new StoreAction(arg, this) },
				{ ActionNames.STORE, arg => new StoreAction(arg, this) },
				{ ActionNames.STORE_CONST, arg => new StoreConstAction(arg, this) },
				{ ActionNames.STORE_TRUE, arg => new StoreTrueAction(arg, this) },
				{ ActionNames.STORE_FALSE, arg => new StoreFalseAction(arg, this) },
				{ ActionNames.APPEND, arg => new AppendAction(arg, this) },
				{ ActionNames.APPEND_CONST, arg => new AppendConstAction(arg, this) },
				{ ActionNames.COUNT, arg => new CountAction(arg, this) },
				{ ActionNames.HELP, arg => new HelpAction(arg, this) },
				{ ActionNames.VERSION, arg => new VersionAction(arg, this) },
				{ ActionNames.PARSERS, arg => new SubParsersAction(arg, this) }
			});

			DefaultAction = ActionNames.NONE;
			// регистрируем типы
			AddSimpleTypeFactories(new Dictionary<string, Type>
			{
					{"int", typeof (int)},
					{"uint", typeof (uint)},
					{"float", typeof (float)},
					{"double", typeof (double)},
					{"decimal", typeof (decimal)},
					{"datetime", typeof (DateTime)},
					{"datetimeoffset", typeof (DateTimeOffset)},
					{"timespan", typeof (TimeSpan)},
					{"string", typeof (string)}
			});

			// Вызываем исключение, если не установлен обработчик ошибок
			GetHandler();

			// Хранилище action
			actions = new List<ActionAP>();
			OptionStringActions = new Dictionary<string, ActionAP>(StringComparer.InvariantCulture);

			// Группы
			ActionGroups = new List<ArgumentGroup>();
			MutuallyExclusiveGroups = new List<object>();

			// Хранилище по умолчанию
			Defaults = new Dictionary<string, object>(StringComparer.InvariantCulture);

			// определяет, выглядит ли «опция» как отрицательное число
			// self._negative_number_matcher = _re.compile(r'^-\d+$|^-\d*\.\d+$')
			NegativeNumberMatcher = new Regex(@"^-\d+(\.\d*)?$|^-\.\d+$");

			// есть ли какие-либо дополнительные опции, которые выглядят как отрицательные
			// числа - используем список, чтобы его можно было разделять и редактировать
			HasNegativeNumberOptionals = new List<object>();
		}

		#region Методы регистрации
		public void Register(string registryName, string actionName, object registredObject)
		{
			Debug.WriteLine(1);
		}
		protected void RegisterActions(IEnumerable<KeyValuePair<string, Func<Argument, ActionAP>>> newActionFactories)
		{
			foreach (var kv in newActionFactories)
			{
				RegistriesActionFactories[kv.Key] = kv.Value;
			}
		}
		public void RegistryGet(string registryName, object value, object defaultValue = null)
		{
			Debug.WriteLine(1);
		}
		#endregion
		#region Методы доступа для пространства имен по умолчанию
		public void SetDefaults(object kwargs)
		{
			Debug.WriteLine(1);
		}
		public void GetDefault(object dest)
		{
			Debug.WriteLine(1);
		}
		#endregion
		#region Добавление аргументов действий
		public void AddArgument(object args, object kwargs)
		{
			Debug.WriteLine(1);
		}
		public ArgumentGroup AddArgumentGroup(string title = "", string description = "")
		{
			ArgumentGroup group = new ArgumentGroup(this, title, description);
			ActionGroups.Add(group);

			return group;
		}
		public ActionAP AddArgument(Argument argument)
		{
			// если позиционные аргументы не заданы или задан только один, и он не похож на строку параметров, то анализируем позиционный аргумент
			Argument preparedArgument = !IsOptionalArgument(argument) ? PreparePositionalArgument(argument) : PrepareOptionalArgument(argument);

			ActionAP argumentAction = CreateAction(preparedArgument);

			if (ReferenceEquals(argumentAction, null)) throw new ParserException("Unregistered action exception");

			return AddAction(argumentAction);
		}
		public Action AddArgument(params string[] optionStrings)
		{
			Debug.WriteLine(1);

			return null;
		}
		private ActionAP CreateAction(Argument argument)
		{
			Func<Argument, ActionAP> argumentActionFactory =
				argument.ActionFactory ?? RegistriesActionFactories.SafeGetValue(!string.IsNullOrWhiteSpace(argument.ActionName) ? argument.ActionName : DefaultAction);

			return argumentActionFactory != null ? argumentActionFactory(argument) : null;
		}
		private bool IsOptionalArgument(Argument argument)
		{
			bool ret = !argument.OptionStrings.IsNullOrEmpty() && (argument.OptionStrings.Count != 1 || StartsWithPrefix(argument.OptionStrings[0]));

			return ret;
		}
		protected bool StartsWithPrefix(string optionString)
		{
			return optionString.StartsWith(PrefixChars);
		}
		public void AddMutuallyExclusiveGroup(object kwargs)
		{
			Debug.WriteLine(1);
		}
		public virtual ActionAP AddAction(ActionAP action)
		{
			if (ReferenceEquals(action, null)) throw new ArgumentNullException("action");

			// resolve any conflicts
			CheckConflict(action);

			// add to actions list
			Actions.Add(action);
			action.Container = this;

			// index the action by any option strings it has
			foreach (string optionString in action.OptionStrings)
			{
				OptionStringActions[optionString] = action;
			}

			// set the flag if any option strings look like negative numbers
			if (!HasNegativeNumberOptionals.IsTrue() && action.OptionStrings.Any(optionString => NegativeNumberMatcher.IsMatch(optionString)))
			{
				HasNegativeNumberOptionals.Add(true);
			}

			return action;
		}
		public void RemoveAction(object action)
		{
			Debug.WriteLine(1);
		}
		public void AddContainerActions(object container)
		{
			Debug.WriteLine(1);
		}
		public void GetPositionalKwargs(object dest, object kwargs)
		{
			Debug.WriteLine(1);
		}
		public void GetOptionalKwargs(object args, object kwargs)
		{
			Debug.WriteLine(1);
		}
		private Argument PreparePositionalArgument(Argument argument)
		{
			var res = new Argument(argument, new string[] { });

			Debug.WriteLine(1);

			// mark positional arguments as required if at least one is always required
			/*ValueCount valueCount = res.ValueCount;
			if (valueCount == null || valueCount.Min.HasValue && valueCount.Min > 0)
				res.IsRequired = true;
			else
			{
				if (valueCount.Max == 1)
					res.IsRequired = false;
				else if (ReferenceEquals(res.DefaultValue, null))
					res.IsRequired = true;
			}

			if (string.IsNullOrEmpty(res.Destination) && !argument.OptionStrings.IsNullOrEmpty())
				res.Destination = argument.OptionStrings.FirstOrDefault();*/

			return res;
		}

		private Argument PrepareOptionalArgument(Argument argument)
		{
			var res = new Argument(argument, (argument.OptionStrings ?? new string[] { }).Where(StartsWithPrefix));

			if (!res.OptionStrings.Any()) throw new Exception("Optional argument should have name starting with prefix");

			// infer destination
			if (string.IsNullOrWhiteSpace(res.Destination) && res.OptionStrings.Any())
			{
				res.Destination = StripPrefix(res.OptionStrings.FirstOrDefault(StartsWithLongPrefix) ?? res.OptionStrings.FirstOrDefault());
			}

			if (string.IsNullOrWhiteSpace(res.Destination)) throw new ParserException("Destination should be specified for options like " + res.OptionStrings[0]);

			res.Destination = res.Destination.Replace('-', '_');

			return res;
		}
		private string StripPrefix(string optionString)
		{
			if (string.IsNullOrEmpty(optionString)) return optionString;

			return PrefixChars.Where(prefix => optionString.StartsWith(prefix, true, CultureInfo.InvariantCulture))
				 .Select(prefix => optionString.Replace(prefix, ""))
				 .FirstOrDefault() ?? optionString;
		}
		protected bool StartsWithLongPrefix(string optionString)
		{
			return optionString.StartsWith(LongPrefixes);
		}

		public void PopActionClass(object kwargs, object defaultValue = null)
		{
			Debug.WriteLine(1);
		}
		public Action<object, object> GetHandler()
		{
			// определяем функцию обработчика ошибок из названия
			switch (ConflictHandlerType)
			{
				case ConflictHandlerType.Error:
					return HandleConflictWithError;
				case ConflictHandlerType.Resolve:
					return HandleConflictWithResolve;
			}

			throw new ParserException(string.Format("Invalid conflict resolution value: {0}", ConflictHandlerType));
		}
		public void CheckConflict(ActionAP action)
		{
			var conflOptionals = new List<KeyValuePair<string, ActionAP>>();
			foreach (string optionString in action.OptionStrings)
			{
				ActionAP conflOptional;
				if (OptionStringActions.TryGetValue(optionString, out conflOptional))
					conflOptionals.Add(new KeyValuePair<string, ActionAP>(optionString, conflOptional));
			}
			if (!conflOptionals.Any()) return;
			Action<ActionAP, IEnumerable<KeyValuePair<string, ActionAP>>> confictHandler = GetHandler();
			confictHandler(action, conflOptionals);
		}
		protected void AddSimpleTypeFactories(IEnumerable<KeyValuePair<string, Type>> typeFactoryPairs)
		{
			foreach (var kv in typeFactoryPairs)
			{
				AddTypeFactory(kv.Key, kv.Value, CreateSimpleTypeFactory(kv.Value));
			}
		}
		public void AddTypeFactory(string typeName, Type type, Func<string, object> typeFactory)
		{
			if (!ReferenceEquals(type, null)) typeFactoriesByType[type] = typeFactory;
			if (!string.IsNullOrEmpty(typeName)) typeFactoriesByName[typeName] = typeFactory;

			if (ReferenceEquals(type, null) && string.IsNullOrEmpty(typeName) && typeFactory != null) DefaultTypeFactory = typeFactory;
		}
		private Func<string, object> CreateSimpleTypeFactory(Type targetType)
		{
			return argString => Convert.ChangeType(argString, targetType);
		}
		public void HandleConflictWithError(object action, object conflicting_actions)
		{
			Debug.WriteLine(1);
		}
		public void HandleConflictWithResolve(object action, object conflicting_actions)
		{
			Debug.WriteLine(1);
		}
		protected Func<string, object> GetTypeFactory(string typeName)
		{
			return typeFactoriesByName.SafeGetValue(typeName);
		}
		protected Func<string, object> GetTypeFactory(Type type)
		{
			return typeFactoriesByType.SafeGetValue(type);
		}
		#endregion
	}
}