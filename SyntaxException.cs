using System;

namespace CorruptusConscribo
{
    public class SyntaxException : Exception
    {
        public SyntaxException(string msg) : base($"invalid syntax: {msg}")
        {
        }
    }
}