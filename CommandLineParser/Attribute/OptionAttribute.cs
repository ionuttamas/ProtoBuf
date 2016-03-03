using System;

namespace CommandLineParser.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class OptionAttribute : System.Attribute
    {
        public string ShortName { get; private set; }
        public string LongName { get; private set; }
        public string HelpText { get; set; }
        public bool Required { get; set; }
        public int Index { get; set; }

        public OptionAttribute(string shortName = null, string longName = null)
        {
            ShortName = shortName;
            LongName = longName;
            Index = -1;
        }

        public override string ToString()
        {
            string t = "";
            if (Required)
                t += "(Required)";
            if (ShortName != null)
                t += "Short: " + ShortName + " ";
            if (LongName != null)
                t += "Long: " + LongName + " ";
            if (Index >= 0)
                t += "Index: " + Index + " ";
            if (HelpText != null)
                t += "\n" + HelpText;
            return t;
        }
    }
}
