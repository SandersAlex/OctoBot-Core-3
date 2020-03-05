using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ArgParse.Actions;

namespace ArgParse
{
	public class Argument
	{
		/// <summary>
		/// Название предопределенного действия, одно из: 
		/// "store", "store_const", "store_true", "store_false", "append", "append_const", "count".
		/// </summary>
		public string ActionName { get; set; }
		/// <summary>
		/// Описание аргумента
		/// </summary>
		public string HelpText { get; set; }
		/// <summary>
		/// Название назначения для хранения результатов анализа
		/// </summary>
		public string Destination { get; set; }
		public Type Type { get; set; }
		/// <summary>
		/// Настраиваемое «действие», которое должно выполняться над аргументом. Если существует <see cref="ActionName"/>, то значение будет проигнорировано
		/// </summary>
		public Func<Argument, ActionAP> ActionFactory { get; set; }

		public IList<string> OptionStrings { get; private set; }

		public bool SuppressDefaultValue { get; set; }
		/// <summary>
		/// Default argument value
		/// </summary>
		public object DefaultValue { get; set; }
		/// <summary>
		/// This argument should contain all remaining args
		/// </summary>
		public bool IsRemainder { get; set; }
		/// <summary>
		/// Count of values for this argument.
		/// </summary>
		public ValueCount ValueCount { get; set; }
		/// <summary>
		/// Is argument required.
		/// </summary>
		public bool IsRequired { get; set; }
		/// <summary>
		/// Argument to show in help / errors
		/// </summary>
		public string MetaVariable { get; set; }
		public Func<string, object> TypeFactory { get; set; }
		/// <summary>
		/// Name argument type
		/// </summary>
		public string TypeName { get; set; }

		public Argument()
		{
			Debug.WriteLine(1);
		}
		public Argument(params string[] optionStrings) : this(optionStrings as IEnumerable<string>)
		{
		}
		public Argument(IEnumerable<string> optionStrings)
		{
			OptionStrings = (optionStrings ?? new string[] { }).ToList();
		}
		public Argument(Argument argument, IEnumerable<string> optionStrings = null) : this(optionStrings ?? (argument != null ? argument.OptionStrings : null))
		{
			if (ReferenceEquals(argument, null)) return;

			ActionFactory = argument.ActionFactory;
			ActionName = argument.ActionName;
			/*Choices = argument.Choices != null ? argument.Choices.ToList() : null;
			ConstValue = argument.ConstValue;*/
			DefaultValue = argument.DefaultValue;
			Destination = argument.Destination;
			HelpText = argument.HelpText;
			IsRemainder = argument.IsRemainder;
			IsRequired = argument.IsRequired;
			MetaVariable = argument.MetaVariable;
			SuppressDefaultValue = argument.SuppressDefaultValue;
			TypeFactory = argument.TypeFactory;
			Type = argument.Type;
			TypeName = argument.TypeName;
			ValueCount = argument.ValueCount;
		}
	}
}