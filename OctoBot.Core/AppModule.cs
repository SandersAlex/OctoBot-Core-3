using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace OctoBot.Core
{
   public class AppModule : Module
   {
      protected override void Load(ContainerBuilder builder)
      {
         builder.RegisterType<CoreService>().As<ICoreService>().As<IConfigurableService>().Named<IConfigurableService>(Constants.ServiceNames.CoreService).SingleInstance();
         builder.RegisterType<LoggingService>().As<ILoggingService>().As<IConfigurableService>().Named<IConfigurableService>(Constants.ServiceNames.LoggingService).SingleInstance();
      }
   }
}