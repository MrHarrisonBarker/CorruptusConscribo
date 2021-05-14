using System;

namespace CorruptusConscribo
{
    public class SyntaxException : Exception
    {
        public SyntaxException(string msg) : base($"invalid syntax: {msg}")
        {
        }
    }
    
    public class CompileException : Exception
    {
        public CompileException(string msg) : base($"compile error: {msg}")
        {
        }
    }
}