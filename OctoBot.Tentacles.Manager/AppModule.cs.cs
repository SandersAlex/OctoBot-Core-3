using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using OctoBot.Core;

namespace OctoBot.Tentacles.Manager
{
   public class AppModule : Module
   {
      protected override void Load(ContainerBuilder builder)
      {
         builder.RegisterType<TentacleManagerService>().As<ITentacleManagerService>().SingleInstance();
      }
   }
}