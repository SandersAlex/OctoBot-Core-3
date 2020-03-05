using System;
using System.Collections.Generic;
using System.Text;
using ArgParse.Actions;

namespace ArgParse.Exceptions
{
   public class ArgumentException : ParserException
   {
      public ActionAP ActionAP { get; private set; }

      public ArgumentException(ActionAP action, string message, Exception innerException = null)
          : base(message, innerException)
      {
         ActionAP = action;
      }
   }
}