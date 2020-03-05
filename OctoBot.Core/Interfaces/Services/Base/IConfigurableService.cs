using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace OctoBot.Core
{
   public interface IConfigurableService : INamedService
   {
      IConfigurationSection RawConfig { get; }
   }
}
