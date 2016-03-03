using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using CommandLineParser.Attribute;
using CommandLineParser.Reflection;

namespace CommandLineParser.Parser
{
    class ArgumentParser
    {
        private const char EQUAL_MARKER = '=';
        private const string SINGLE_HYPHEN = "-";
        private const string DOUBLE_HYPHEN = "--";
        private readonly List<ParseRule> _rules;
        private readonly Dictionary<string, ParseRule> _rulesTable;
        private ParseState _state;
        private ParseRule _currentRule;

        public ArgumentParser(List<ParseRule> rules)
        {
            _rules = rules;
            _rulesTable = GetDictionary(rules);
            _state = ParseState.None;
        }

        static Dictionary<string, ParseRule> GetDictionary(List<ParseRule> _rulesTable)
        {
            var dic = new Dictionary<string, ParseRule>();
            foreach (var r in _rulesTable)
            {
                if (r.Option.ShortName != null)
                    dic.Add(r.Option.ShortName, r);
                if (r.Option.LongName != null)
                    dic.Add(r.Option.LongName, r);
                //Skip indexed options
            }
            return dic;
        }

        public void Parse(string[] arguments)
        {
            foreach (var argument in arguments)
                ParseArgument(argument);
        }

        private void ParseArgument(string argument)
        {
            if (argument == null)
                throw new ArgumentNullException("argument");

            while (!string.IsNullOrEmpty(argument))
            {
                //Used to make sure the returned argument is shortened.
                var prev = argument;

                _state = GetTransition(argument);

                argument = ParseArgumentState(_state, argument);

                //Make sure the parsing has shortened argument.
                //Otherwise we risk getting into an infinite loop.
                if (argument == prev || argument.Length >= prev.Length)
                    throw new InvalidProgramException("Variable argument was not shortened.");
            }
        }

        private ParseState GetTransition(string argument)
        {
            ParseRule indexedOption = _rules
                .Where(x => x.Option.Index >= 0 && x.ParsedValue == null)
                .OrderBy(x => x.Option.Index)
                .FirstOrDefault();

            ParseRule booleanOption = _rules
                .Where(x => x.IsBoolean())
                .OrderBy(x => x.Option.LongName == null ? x.Option.ShortName.Length : x.Option.LongName.Length)
                .FirstOrDefault(x => IsCandidate(argument, x.Option));

            ParseRule regularOption = _rules
                .Where(x => !x.IsBoolean())
                .OrderBy(x => x.Option.LongName == null ? x.Option.ShortName.Length : x.Option.LongName.Length)
                .FirstOrDefault(x => IsCandidate(argument, x.Option));

            if (indexedOption != null)
                return ParseState.IndexedOption;

            if (booleanOption != null)
                return ParseState.BooleanOption;

            if (argument.StartsWith(DOUBLE_HYPHEN))
                return ParseState.LongOption;

            if (argument.StartsWith(SINGLE_HYPHEN))
                return ParseState.ShortOption;

            if (argument.IndexOf(EQUAL_MARKER) > 0 || regularOption != null)
                return ParseState.GenericOption;

            return ParseState.Value;
        }

        private bool IsCandidate(string argument, OptionAttribute option)
        {
            if (option.LongName != null)
            {
                if (argument.StartsWith(option.LongName) ||
                argument.StartsWith(SINGLE_HYPHEN + option.LongName) ||
                argument.StartsWith(DOUBLE_HYPHEN + option.LongName))
                    return true;
            }

            if (argument.StartsWith(option.ShortName) ||
                argument.StartsWith(SINGLE_HYPHEN + option.ShortName) ||
                argument.StartsWith(DOUBLE_HYPHEN + option.ShortName))
                return true;

            return false;
        }

        private string ParseArgumentState(ParseState state, string argument)
        {
            switch (state)
            {
                case ParseState.IndexedOption:
                    return ParseIndexedOption(argument);
                case ParseState.GenericOption:
                    return ParseGenericOption(argument);
                case ParseState.ShortOption:
                    return ParseShortOption(argument);
                case ParseState.LongOption:
                    return ParseLongOption(argument);
                case ParseState.BooleanOption:
                    return ParseBooleanOption(argument);
                case ParseState.Value:
                    return ParseValue(argument);
                default:
                    throw new ArgumentException("Unknown state: " + state, "state");
            }
        }

        private string ParseIndexedOption(string argument)
        {
            ParseRule priorityOption = _rules
                .Where(x => x.Option.Index >= 0 && x.ParsedValue == null)
                .OrderBy(x => x.Option.Index)
                .FirstOrDefault();

            if (priorityOption != null)
            {
                _currentRule = priorityOption;

                if (argument.StartsWith(SINGLE_HYPHEN) || argument.StartsWith(DOUBLE_HYPHEN))
                    throw new ArgumentException(string.Format("Argument {0} could not be mapped to any option", argument));

                _currentRule.ParsedValue = Convert.ChangeType(argument, _currentRule.Property.PropertyType);
                _currentRule = null;


                return string.Empty;
            }

            throw new InvalidOperationException("No indexed option was found");
        }

        private string ParseGenericOption(string argument)
        {
            string result = ParseOption(argument);

            return result;
        }

        private string ParseShortOption(string argument)
        {
            argument = argument.Substring(SINGLE_HYPHEN.Length);
            string result = ParseOption(argument);

            return result;
        }

        private string ParseLongOption(string argument)
        {
            argument = argument.Substring(DOUBLE_HYPHEN.Length);
            string result = ParseOption(argument);

            return result;
        }

        private string ParseOption(string argument)
        {
            var matchingRule = _rulesTable
                .Where(x => argument.StartsWith(x.Key))
                .OrderByDescending(x => x.Key.Length)
                .FirstOrDefault();

            if (matchingRule.Equals(default(KeyValuePair<string, ParseRule>)))
                throw new ArgumentException(string.Format("Argument {0} is not available", argument));

            var isBoolean = matchingRule.Value.Property.PropertyType.IsBoolean();
            argument = argument.Substring(matchingRule.Key.Length);
            _currentRule = matchingRule.Value;
            _state = isBoolean
                ? ParseState.BooleanOption
                : ParseState.Value;

            return argument;
        }

        private string ParseBooleanOption(string argument)
        {
            ParseRule booleanOption = _rules
                .Where(x => x.IsBoolean())
                .OrderBy(x => x.Option.LongName == null ? x.Option.ShortName.Length : x.Option.LongName.Length)
                .First(x => IsCandidate(argument, x.Option));

            _currentRule = booleanOption;
            _currentRule.ParsedValue = true;
            _currentRule = null;
            _state = ParseState.None;

            if (booleanOption.Option.LongName != null && argument.StartsWith(DOUBLE_HYPHEN + booleanOption.Option.LongName))
                return argument.Substring((DOUBLE_HYPHEN + booleanOption.Option.LongName).Length);

            if (booleanOption.Option.ShortName != null && argument.StartsWith(SINGLE_HYPHEN + booleanOption.Option.ShortName))
                return argument.Substring((SINGLE_HYPHEN + booleanOption.Option.ShortName).Length);

            //This occur if we falsely get a long option name into the ShortName property.
            throw new InvalidProgramException("No matching boolean option was found");
        }

        private string ParseValue(string argument)
        {
            if (_currentRule == null)
                throw new InvalidOperationException(string.Format("There is not option for value {0}", argument));

            TypeConverter converter = TypeDescriptor.GetConverter(_currentRule.Property.PropertyType);

            argument = argument.Trim(EQUAL_MARKER);
            argument = argument.Trim();

            if (!converter.IsValid(argument))
                throw new InvalidOperationException(string.Format("The value {0} cannot be assigned to option {1}", argument, _currentRule.Option.ShortName ?? _currentRule.Option.LongName));

            _currentRule.ParsedValue = Convert.ChangeType(argument, _currentRule.Property.PropertyType);
            _currentRule = null;

            return null;
        }

    }
}
