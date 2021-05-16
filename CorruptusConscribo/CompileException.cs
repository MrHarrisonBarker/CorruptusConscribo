using System;

namespace CorruptusConscribo
{
    public class CompileException : Exception
    {
        public CompileException(string msg) : base(msg)
        {
        }
    }
}