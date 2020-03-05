using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ArgParse.Actions;
using ArgParse.Enums;
using ArgParse.Exceptions;
using ArgParse.Extensions;
using ArgParse.Interfaces;

namespace ArgParse
{
	public class ArgumentParser : ActionsContainer, IArgumentParser
	{
      public bool AddHelp { get; set; } = false;

      public ArgumentParser() : this (new ParserSettings())
		{
		}

		public ArgumentParser(ParserSettings parserSettings) : base(parserSettings)
		{
         /*self.prog = prog
         self.usage = usage
         self.epilog = epilog
         self.formatter_class = formatter_class
         self.fromfile_prefix_chars = fromfile_prefix_chars*/
         AddHelp = parserSettings.AddHelp;
         /*self.allow_abbrev = allow_abbrev*/

         var positionals = AddArgumentGroup("positional arguments");
         var optionals = AddArgumentGroup("optional arguments");
         /*

         self._subparsers = None*/



         // add help argument if necessary
         // (using explicit default to override global argument_default)
         if (AddHelp == true)
         {
            AddArgument(new Argument("-h", "--help") { HelpText = "показать это сообщение помощи и выйти", ActionName = ActionNames.HELP });
         }
        

        /*# add parent arguments and defaults
         for parent in parents:
            self._add_container_actions(parent)
            try:
                defaults = parent._defaults
            except AttributeError:
                pass
            else:
                self._defaults.update(defaults)*/


         Debug.WriteLine(1);
		}

      public ParseResult ParseArguments(IEnumerable<string> args, ParseResult parseResult = null)
      {
         parseResult = ParseKnownArguments(args, parseResult);

         if (parseResult.UnrecognizedArguments != null && parseResult.UnrecognizedArguments.Any())
            throw new UnrecognizedArgumentsException(parseResult.UnrecognizedArguments);

         return parseResult;
      }
      public ParseResult ParseKnownArguments(IEnumerable<string> args, ParseResult parseResult)
      {
         // default Namespace built from parser defaults
         if (parseResult == null) parseResult = new ParseResult();

         // add any action defaults that aren't present
         foreach (ActionAP action in Actions)
         {
            if (action.HasDestination)
            {
               var res = parseResult[action.Destination];
               if (ReferenceEquals(res, null))
               {
                  if (action.HasDefaultValue)
                  {
                     parseResult[action.Destination] = action.DefaultValue;
                  }
               }
            }
         }

         parseResult = ParseKnowArgumentsInternal(args, parseResult);

         return parseResult;
      }
      internal ParseResult ParseKnowArgumentsInternal(IEnumerable<string> args, ParseResult parseResult)
      {
         var argStrings = args.ToList();

         // map all mutually exclusive arguments to the other arguments they can't occur with
         var actionConflicts = new Dictionary<ActionAP, List<ActionAP>>();
         foreach (var mutexGroup in MutuallyExclusiveGroups)
         {
            Debug.WriteLine(1);
         }

         // find all option indices, and determine the arg_string_pattern
         // which has an 'O' if there is an option at an index,
         // an 'A' if there is an argument, or a '-' if there is a '--'
         var optionStringIndices = new Dictionary<int, object>();
         var argStringPatternBuilder = new StringBuilder();
         var argEnumerator = argStrings.GetEnumerator();
         var argPos = 0;
         for (; argEnumerator.MoveNext(); ++argPos)
         {
            Debug.WriteLine(1);
         }

         // join the pieces together to form the pattern
         var argStringPattern = argStringPatternBuilder.ToString();

         // converts arg strings to the appropriate and then takes the action
         var seenActions = new HashSet<ActionAP>();
         var seenNonDefaultActions = new HashSet<ActionAP>();

         Action<ActionAP, IEnumerable<string>, string> takeAction = (action, argumentStrings, optionString) =>
         {
            Debug.WriteLine(1);
         };

         // function to convert arg_strings into an optional action
         Func<int, int> consumeOptional = startIndex =>
         {
            Debug.WriteLine(1);

            return 0;
         };

         // the list of Positionals left to be parsed; this is modified by consume_positionals()
         var positionals = GetPositionalActions();

         // function to convert arg_strings into positional actions
         Func<int, int> consumePositionals = patternStartIndex =>
         {
            if (patternStartIndex < 0) return patternStartIndex;
            var selectedPattern = argStringPattern.Substring(patternStartIndex);
            var argCounts = MatchArgumentsPartial(positionals, selectedPattern);

            // slice off the appropriate arg strings for each Positional
            // and add the Positional and its args to the list
            foreach (var it in positionals.Zip(argCounts, (action, argCount) => new { action, argCount }))
            {
               var actionArgs = argStrings.Skip(patternStartIndex).Take(it.argCount).ToList();
               patternStartIndex += it.argCount;
               takeAction(it.action, actionArgs, null);
            }
            var toRemove = positionals.Count > argCounts.Count ? argCounts.Count : positionals.Count;
            if (toRemove > 0)
               positionals.RemoveRange(0, toRemove);

            return patternStartIndex;
         };

         // consume Positionals and Optionals alternately, until we have passed the last option string
         var extras = new List<string>();
         var globalStartIndex = 0;
         var maxOptionStringIndex = optionStringIndices.Any() ? optionStringIndices.Keys.Max() : -1;
         while (globalStartIndex <= maxOptionStringIndex)
         {
            Debug.WriteLine(1);
         }

         // consume any positionals following the last Optional
         var globalStopIndex = consumePositionals(globalStartIndex);

         // if we didn't consume all the argument strings, there were extras
         extras.AddRange(argStrings.Skip(globalStopIndex));
         if (extras.Any())
            parseResult.UnrecognizedArguments =
                new[] { parseResult.UnrecognizedArguments, extras }.Where(it => it != null)
                    .SelectMany(it => it)
                    .ToList();

         // make sure all required actions were present and also convert
         // action defaults which were not given as arguments
         var requiredActions = new List<ActionAP>();
         foreach (var action in Actions)
         {
            if (!seenActions.Contains(action))
            {
               if (action.IsRequired) requiredActions.Add(action);
               else
               {
                  // Convert action default now instead of doing it before
                  // parsing arguments to avoid calling convert functions
                  // twice (which may fail) if the argument was given, but
                  // only if it was defined already in the namespace
                  if (action.HasDefaultValue && !ReferenceEquals(action.DefaultValue, null) &&
                      action.DefaultValue is string &&
                      parseResult.Get<string>(action.Destination) == (string)action.DefaultValue)
                     parseResult[action.Destination] = GetValue(action, (string)action.DefaultValue);
               }
            }
         }

         if (!requiredActions.IsNullOrEmpty()) throw new RequiredArgumentsException(requiredActions);

         return parseResult;
      }
      protected List<ActionAP> GetPositionalActions()
      {
         return Actions.Where(it => !it.OptionStrings.Any()).ToList();
      }
      protected List<ActionAP> GetOptionalActions()
      {
         return Actions.Where(it => it.OptionStrings.Any()).ToList();
      }
      private IList<int> MatchArgumentsPartial(IList<ActionAP> actions, string argStringsPattern)
      {
         var res = new List<int>();
         for (var i = actions.Count; i > 0; --i)
         {
            var actionsSlice = actions.Take(i);
            var pattern = "^" + string.Concat(actionsSlice.Select(GetValueCountPattern));
            var match = Regex.Match(argStringsPattern, pattern);
            if (!match.Success) continue;
            res.AddRange(match.Groups.OfType<Group>().Skip(1).Select(it => it.Length));
            break;
         }
         return res;
      }
      private static string GetValueCountPattern(ActionAP action)
      {
         var res = action.IsRemainder
             ? "([-AO]*)"
             : (action.IsParser
                 ? "(-*A[-AO]*)"
                 : string.Format("(-*(?:A-*){0})", action.ValueCount ?? new ValueCount(1)));
         if (!action.OptionStrings.IsNullOrEmpty())
            res = res.Replace("-*", "").Replace("-", "");
         return res;
      }
      private object GetValue(ActionAP action, string argString)
      {
         var typeFactory = action.TypeFactory ??
                           GetTypeFactory(action.Type) ?? GetTypeFactory(action.TypeName) ?? DefaultTypeFactory;
         try
         {
            return typeFactory(argString);
         }
         catch (Exception err)
         {
            throw new Exceptions.ArgumentException(action,
                string.Format("Invalid type \"{0}\" for value \"{1}\"", action.TypeName, argString), err);
         }
      }
   }
}