using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CommandLineParser.Attribute;
using CommandLineParser.Parser;
using CommandLineParser.Reflection;
using NUnit.Framework;

namespace CommandLineParser.UnitTests
{
    [TestFixture]
    public class CommandLineTests
    {
        [TestCase("-iInput.bin --length=150", "InputFile", "MaximumLength")]
        [TestCase("-i Input.bin --length=150", "InputFile", "MaximumLength")]
        [TestCase("-i=Input.bin --length=150", "InputFile", "MaximumLength")]
        [TestCase("-i=Input.bin -o=Out.bin --length=150", "InputFile", "OutputFile", "MaximumLength")]
        [TestCase("-i=Input.bin --output=Out.bin --length=150", "InputFile", "OutputFile", "MaximumLength")]
        public void Parser_WhenParsingShortNameOptions_ParsesArgumentsCorrectly(string input, params string[] expectedArguments)
        {
            TestOptions options = ParseArguments<TestOptions>(input);

            AssertResults(options, expectedArguments);
        }

        [TestCase("-viInput.bin --length=150", "InputFile", "MaximumLength", "Verbose")]
        [TestCase("--verbosei=Input.bin --length=150", "InputFile", "MaximumLength", "Verbose")]
        [TestCase("--verbose -i=Input.bin --length=150", "InputFile", "MaximumLength", "Verbose")]
        [TestCase("-i=Input.bin -v -o=Out.bin --length=150", "InputFile", "OutputFile", "MaximumLength", "Verbose")]
        [TestCase("-i=Input.bin -v -o=Out.bin -l=150", "InputFile", "OutputFile", "MaximumLength", "Verbose")]
        [TestCase("-i=Input.bin -o=Out.bin -vl=150", "InputFile", "OutputFile", "MaximumLength", "Verbose")]
        [TestCase("-i=Input.bin -o=Out.bin --verboselength=150", "InputFile", "OutputFile", "MaximumLength", "Verbose")]
        [TestCase("-i=Input.bin -o=Out.bin -vlength=150", "InputFile", "OutputFile", "MaximumLength", "Verbose")]
        [TestCase("-i=Input.bin --verbose --output=Out.bin --length=150", "InputFile", "OutputFile", "MaximumLength", "Verbose")]
        public void Parser_WhenParsingBooleanNameOptions_ParsesArgumentsCorrectly(string input, params string[] expectedArguments)
        {
            TestOptions options = ParseArguments<TestOptions>(input);

            AssertResults(options, expectedArguments);
        }

        [TestCase("Input.bin Out.bin -vlength=150", "InputFile", "OutputFile", "MaximumLength", "Verbose")]
        public void Parser_WhenParsingIndexedOptions_ParsesArgumentsCorrectly(string input, params string[] expectedArguments)
        {
            TestIndexedOptions options = ParseArguments<TestIndexedOptions>(input);

            AssertResults(options, expectedArguments);
        }

        [TestCase("-i=Input.bin -vlength=150")]
        [TestCase("-vlength=150")]
        [TestCase("--output=Out.bin -vlength=150")]
        [TestCase("-vlength=150")]
        [TestCase("-o=Out.bin -i=Input.bin -vlength=150")]
        public void Parser_WhenParsingInvalidIndexedOptions_ThrowsException(string input)
        {
            Assert.Throws<ArgumentException>(() => ParseArguments<TestIndexedOptions>(input));
        }

        private T ParseArguments<T>(string input) where T : class, new()
        {
            var parser = new Parser<T>();
            T options = parser.Parse(input);

            return options;
        }

        private void AssertResults(object options, params string[] expectedArguments)
        {
            foreach (var expectedArgument in expectedArguments)
            {
                object value = options.GetProperty(expectedArgument);

                if (value.GetType().IsNumeric())
                {
                    Assert.GreaterOrEqual((int)value, 0);
                }
                else if (value.GetType().IsBoolean())
                {
                    Assert.IsTrue((bool)value);
                }
                else
                {
                    Assert.NotNull(value);
                }
            }
        }
    }
}
