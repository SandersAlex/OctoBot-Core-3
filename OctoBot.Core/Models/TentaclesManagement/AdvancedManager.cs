using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using OctoBot.Core;

namespace OctoBot.TentaclesManagement
{
	public class AdvancedManager
	{
		/// <summary>
		/// """ is_abstract will test if the class in an abstract one or not by checking if __metaclass__ attribute is inherited or not we will know if the class is an abstract one
		/// Returns True if it is an abstract one else False. """
		/// </summary>
		/// <param name="class_type"></param>
		private static bool IsAbstract(Type classType)
		{
			return classType.IsAbstract;
		}
		/// <summary>
		/// """ get_advanced will get each subclasses of the parameter class_type
		/// For each abstract subclasses it will call itself with the reference abstract_class not set
		/// If the current child is not abstract it will be set as the reference only if abstract_class is None
		/// If there is not subclasses to class_type it will add class_type into the config advanced list
		/// with its name as a key or the reference class name --> abstract_class
		/// </summary>
		/// <param name="config"></param>
		/// <param name="class_type"></param>
		/// <param name="abstract_class"></param>
		private static void GetAdvanced(object config, object class_type, object abstract_class = null)
		{
			Debug.WriteLine(1);
		}
		/// <summary>
		/// """ create_class_list will create a list with the best class available
		/// Advanced class are declared into advanced folders of each packages
		/// For AbstractEvaluator and AbstractUtil classes, this will call the get_advanced method to initialize the config list
		/// </summary>
		/// <param name="config"></param>
		private static void CreateClassList(object config)
		{
			Debug.WriteLine(1);
		}
		public static void InitAdvancedClassesIfNecessary(ICoreConfig config)
		{
			if (config.AdvancedClasses.Count > 0)
			{
				Debug.WriteLine(1);
			}
		}
		private static Dictionary<string, object> GetAdvancedClassesList(ICoreConfig config)
		{
			return config.AdvancedClasses;
		}
		private static void GetAdvancedInstancesList(object config)
		{
			Debug.WriteLine(1);
		}
		private static void AppendToClassList(object config, object class_name, object class_type)
		{
			Debug.WriteLine(1);
		}
		private static List<Type> GetClasses(ICoreConfig config, Type classType, bool getAllClasses = false)
		{
			List<Type> classes = new List<Type>();

			if (AdvancedManager.GetAdvancedClassesList(config).ContainsKey(classType.Name) == true)
			{
				//classes = copy(AdvancedManager._get_advanced_classes_list(config)[class_type.get_name()])
				Debug.WriteLine(1);
			}

			if (classes.Count == 0 || (getAllClasses == true && classes.Contains(classType) == false))
			{
				classes.Add(classType);
			}

			return classes;
		}
		private static void GetClass(object config, object class_type)
		{
			Debug.WriteLine(1);
		}
		private static void GetUtilInstance(object config, object class_type, object args)
		{
			Debug.WriteLine(1);
		}
		public static List<Type> CreateDefaultTypesList(Type clazz)
		{
			List<Type> defaultClassList = new List<Type>();
			var mainClasses = FindDerivedTypes(clazz);

			foreach (var currentSubclass in mainClasses)
			{
				var subClasses = FindDerivedTypes(currentSubclass);

				if (subClasses.Count() > 0)
				{
					foreach (var currentClass in subClasses) defaultClassList.Add(currentClass);
				}
				else
				{
					if (AdvancedManager.IsAbstract(currentSubclass) == false) defaultClassList.Add(currentSubclass);
				}
			}

			return defaultClassList;
		}
		public static List<Type> CreateAdvancedEvaluatorTypesList(Type evaluatorClass, ICoreConfig config)
		{
			List<Type> evaluatorAdvancedEvalClassList = new List<Type>();

			IEnumerable<Type> lstEvaluatorClass = FindDerivedTypes(evaluatorClass);

			foreach (Type evaluatorSubclass in lstEvaluatorClass)
			{
				IEnumerable<Type> lstEvaluatorSubclass = FindDerivedTypes(evaluatorSubclass);
				foreach (Type evalClass in lstEvaluatorSubclass)
				{
					foreach (Type evalClassType in AdvancedManager.GetClasses(config, evalClass))
					{
						evaluatorAdvancedEvalClassList.Add(evalClassType);
					}
				}
			}

			if (AdvancedManager.CheckDuplicate(evaluatorAdvancedEvalClassList) == false)
			{
				var logger = Application.Resolve<ILoggingService>();
				logger.Warning("Дубликат имени evaluator");
			}

			return evaluatorAdvancedEvalClassList;
		}
		private static void GetAllClasses(object evaluator_class, object config)
		{
			Debug.WriteLine(1);
		}
		private static bool CheckDuplicate(List<Type> listToCheck)
		{
			return listToCheck.Count == listToCheck.Count;
		}
		public static IEnumerable<Type> FindDerivedTypes(Type baseType)
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			List<Type> types = new List<Type>();

			foreach (var assembly in assemblies)
			{
				//var enumTypes = assembly.GetTypes().Where(t => t != baseType && baseType.IsAssignableFrom(t));
				var enumTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(baseType));
				types.AddRange(enumTypes);
			}

			return types;
		}
	}
}
