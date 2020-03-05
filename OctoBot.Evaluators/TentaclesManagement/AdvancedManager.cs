using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OctoBot.TentaclesManagement
{
	public class AdvancedManager
	{
		/// <summary>
		/// """ is_abstract will test if the class in an abstract one or not by checking if __metaclass__ attribute is inherited or not we will know if the class is an abstract one
		/// Returns True if it is an abstract one else False. """
		/// </summary>
		/// <param name="class_type"></param>
		private static void IsAbstract(object class_type)
		{
			Debug.WriteLine(1);
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
		private static void InitAdvancedClassesIfNecessary(object config)
		{
			Debug.WriteLine(1);
		}
		private static void GetAdvancedClassesList(object config)
		{
			Debug.WriteLine(1);
		}
		private static void GetAdvancedInstancesList(object config)
		{
			Debug.WriteLine(1);
		}
		private static void AppendToClassList(object config, object class_name, object class_type)
		{
			Debug.WriteLine(1);
		}
		private static void GetClasses(object config, object class_type, bool get_all_classes = false)
		{
			Debug.WriteLine(1);
		}
		private static void GetClass(object config, object class_type)
		{
			Debug.WriteLine(1);
		}
		private static void GetUtilInstance(object config, object class_type, object args)
		{
			Debug.WriteLine(1);
		}
		public static object CreateDefaultTypesList(Type clazz)
		{
			List<object> defaultClassList = new List<object>();

			Debug.WriteLine(1);

			return null;
		}
		private static void CreateAdvancedEvaluatorTypesList(object evaluator_class, object config)
		{
			Debug.WriteLine(1);
		}
		private static void GetAllClasses(object evaluator_class, object config)
		{
			Debug.WriteLine(1);
		}
		private static void CheckDuplicate(object list_to_check)
		{
			Debug.WriteLine(1);
		}
	}
}
