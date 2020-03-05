using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace OctoBot.Core
{
	public abstract class ConfigrableServiceBase<TConfig> : IConfigurableService where TConfig : class
	{
      private TConfig config;
      private IConfigurationSection rawConfig;

      public abstract string ServiceName { get; }

      private object syncRoot = new object();

      public TConfig Config
      {
         get
         {
            lock (syncRoot)
            {
               if (config == null)
               {
                  config = RawConfig.Get<TConfig>();
                  PrepareConfig();
               }
               return config;
            }
         }
      }
      public IConfigurationSection RawConfig
      {
         get
         {
            lock (syncRoot)
            {
               if (rawConfig == null)
               {
                  rawConfig = Application.ConfigProvider.GetSection(ServiceName, OnRawConfigChanged);
               }

               return rawConfig;
            }
         }
      }

      protected virtual void PrepareConfig() { }
      private void OnRawConfigChanged(IConfigurationSection changedRawConfig)
      {
         Debug.WriteLine(1);
      }
   }
}