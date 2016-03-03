using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CommandLineParser.Attribute;

namespace CommandLineParser.Parser
{
    public class ParseRule
    {
        public OptionAttribute Option { get; set; }
        public PropertyInfo Property { get; set; }
        /// <summary>
        /// Value being parsed from the arguments
        /// </summary>
        public object ParsedValue { get; set; }

        public bool IsBoolean()
        {
            var type = Property.PropertyType;
            if (type == typeof(bool?))
                return true;

            return Type.GetTypeCode(type) == TypeCode.Boolean;
        }

        public override string ToString()
        {
            if(ParsedValue != null)
                return Option.ToString() + "\n = " + ParsedValue;
            else
                return Option.ToString() + "\nNot parsed";
        }
    }
}
