using System;
using System.Text.RegularExpressions;

namespace CorruptusConscribo
{
    public class Operator : Token
    {
        public Operator(string name, Regex expression) : base(name, expression)
        {
        }
    }
}