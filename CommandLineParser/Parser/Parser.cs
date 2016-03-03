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
    public class Parser<TOptions>
        where TOptions : class, new()
    {
        private readonly List<ParseRule> _rulesTable;
        private readonly ArgumentParser _parser;

        public Parser()
        {
            _rulesTable = BuildParseRules();
            _parser = new ArgumentParser(_rulesTable);
        }

        static List<ParseRule> BuildParseRules()
        {
            List<ParseRule> rules = ReflectionExtensions
                .GetAttributes<TOptions, OptionAttribute>()
                .Select(x => new ParseRule
                {
                    Property = x.Key,
                    Option = x.Value
                })
                .ToList();
            return rules;
        }

        public TOptions Parse(string input)
        {
            string[] arguments = input.Split(' ');
            TOptions result = Parse(arguments);
            return result;
        }

        public TOptions Parse(string[] arguments)
        {
            _parser.Parse(arguments);

            TOptions result = BuildResult();
            return result;
        }

        private TOptions BuildResult()
        {
            TOptions result = new TOptions();
            IEnumerable<ParseRule> parsedRules = _rulesTable
                .Where(x => x.ParsedValue != null);

            foreach (var entry in parsedRules)
            {
                result.SetProperty(entry.Property.Name, entry.ParsedValue);
            }

            return result;
        }
    }
}
