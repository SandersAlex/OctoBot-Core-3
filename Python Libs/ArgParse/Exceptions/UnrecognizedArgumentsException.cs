using System;
using System.Collections.Generic;
using System.Text;

namespace ArgParse.Exceptions
{
   public class UnrecognizedArgumentsException : ParserException
   {
      public UnrecognizedArgumentsException(IList<string> unrecognizedArguments)
      {
         UnrecognizedArguments = unrecognizedArguments;
      }
      public UnrecognizedArgumentsException(string message, IList<string> unrecognizedArguments)
      {
         UnrecognizedArguments = unrecognizedArguments;
      }

      public IList<string> UnrecognizedArguments { get; private set; }
   }
}