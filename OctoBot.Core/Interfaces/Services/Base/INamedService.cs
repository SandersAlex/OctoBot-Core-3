using System;
using System.Collections.Generic;
using System.Text;

namespace OctoBot.Core
{
   public interface INamedService
   {
      string ServiceName { get; }
   }
}