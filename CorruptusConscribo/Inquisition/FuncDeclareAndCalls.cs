using System.Collections.Generic;
using CorruptusConscribo.Parser;

namespace CorruptusConscribo.Inquisition
{
    public class FuncDeclareAndCalls
    {
        public Function Definition { get; set; }
        public Function Declaration { get; set; }
        public List<FunctionCall> Calls { get; set; }
    }
}