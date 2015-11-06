using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SilentOrbit.ProtocolBuffers
{
    public class OptionAttribute : Attribute
    {
        public char Alias { get; set; }
        public string Command { get; set; }
        public bool Required { get; set; }
        public string HelpText { get; set; }

        public OptionAttribute()
        {
        }

        public OptionAttribute(string command)
        {
            Command = command;
        }

        public OptionAttribute(char alias, string command) : this(command)
        {
            Alias = alias;
        }
    }

    public class Parser
    {
        private readonly static List<ParseConfiguration> ParseCache = new List<ParseConfiguration>();
        private const string COMMAND_PREFIX = "--";

        public ParseResult<T> ParseArguments<T>(string[] args) where T : new()
        {
            Type type = typeof (T);
            ParseConfiguration configuration = ParseCache.FirstOrDefault(x => x.Type == type) ?? BuildMap<T>();

            foreach (string argument in args)
            {
                if (argument.StartsWith(COMMAND_PREFIX))
                {
                    configuration[argument.tr]
                }
            }
        }



        private ParseConfiguration BuildMap<T>() where T : new()
        {
            Type type = typeof (T);
            IEnumerable<PropertyInfo> properties = type.GetProperties()
                .Where(x => Attribute.IsDefined(x, typeof(OptionAttribute)));
            Dictionary<OptionAttribute, PropertyInfo> commandsTable = properties
                .ToDictionary(prop => (OptionAttribute) prop.GetCustomAttributes(true).First(attr => attr is OptionAttribute), x => x);
            ParseConfiguration result = new ParseConfiguration
            {
                Type = type,
                CommandsTable = commandsTable
            };

            return result;
        }
        
        private class ParseConfiguration
        {
            public Dictionary<OptionAttribute, PropertyInfo> CommandsTable { get; set; }
            public Type Type { get; set; }

            public PropertyInfo this[string key]
            {
                get
                {
                    PropertyInfo property = CommandsTable.FirstOrDefault(x => x.Key.Command == key).Value;
                    return property;
                }
            }

            public PropertyInfo this[char key]
            {
                get
                {
                    PropertyInfo property = CommandsTable.FirstOrDefault(x => x.Key.Alias == key).Value;
                    return property;
                }
            }
        }
    }

    public class ParseResult<T> where T : new()
    {
        public IEnumerable<string> Errors { get; internal set; }
        public T Value { get; internal set; }
    }
}