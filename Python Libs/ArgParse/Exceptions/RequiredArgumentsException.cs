using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArgParse.Actions;
using ArgParse.Extensions;

namespace ArgParse.Exceptions
{
   public class RequiredArgumentsException : ParserException
   {
      private readonly string message;

      public RequiredArgumentsException(IEnumerable<ActionAP> requiredActions)
      {
         RequiredActions = (requiredActions ?? new ActionAP[] { }).ToList();
         RequiredArguments = RequiredActions.Select(GetArgumentName).ToList();
         message = string.Format("The following arguments are required: {0}", string.Join(", ", RequiredArguments));
      }

      public override string Message
      {
         get { return message; }
      }

      public IList<ActionAP> RequiredActions { get; private set; }
      public IList<string> RequiredArguments { get; private set; }

      private static string GetArgumentName(ActionAP action)
      {
         if (action == null) return null;
         if (action.OptionStrings.IsTrue())
            return string.Format("({0})", string.Join("/", action.OptionStrings));
         if (!string.IsNullOrWhiteSpace(action.MetaVariable))
            return action.MetaVariable;
         if (action.HasDestination && action.HasValidDestination)
            return action.Destination;
         return null;
      }
   }
}