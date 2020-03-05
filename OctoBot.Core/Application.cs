using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Autofac;
using Autofac.Core;

namespace OctoBot.Core
{
	public class Application
	{
		public readonly static IConfigProvider ConfigProvider = new ConfigProvider();

		private static IContainer container;
		public static ILifetimeScope Container
		{
			get
			{
				RegisterComponents();

				return container;
			}
		}

		public static TService Resolve<TService>(params Parameter[] parameters) where TService : class
		{
			return Container.Resolve<TService>(parameters);
		}

		public static void RegisterComponents(bool repos = true, bool queries = true, bool mappers = true)
		{
			if (Application.container == null)
			{
				var builder = new ContainerBuilder();

				var assemblyPattern = new Regex($"{nameof(OctoBot)}.*.dll");
				var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => assemblyPattern.IsMatch(Path.GetFileName(a.Location)));
				var dynamicAssembliesPath = new Uri(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location)).LocalPath;
				var dynamicAssemblies = Directory.EnumerateFiles(dynamicAssembliesPath, "*.dll", SearchOption.AllDirectories)
							  .Where(filename => assemblyPattern.IsMatch(Path.GetFileName(filename)) &&
							  !loadedAssemblies.Any(a => Path.GetFileName(a.Location) == Path.GetFileName(filename)));

				var allAssemblies = loadedAssemblies.Concat(dynamicAssemblies.Select(Assembly.LoadFrom)).Distinct();

				builder.RegisterAssemblyModules(allAssemblies.ToArray());
				Application.container = builder.Build();
			}
		}
	}
}