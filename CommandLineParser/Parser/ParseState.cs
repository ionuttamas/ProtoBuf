using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandLineParser.Parser
{
    enum ParseState
    {
        None,
        IndexedOption,
        GenericOption,
        ShortOption,
        LongOption,
        BooleanOption,
        Value
    }
}
