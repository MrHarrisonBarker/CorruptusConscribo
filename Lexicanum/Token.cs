using System;
using System.Text.RegularExpressions;

namespace CorruptusConscribo
{
    public class Token
    {
        protected Token(string name, Regex expression)
        {
            Name = name;
            Expression = expression;
        }

        public Token(Token token, int start, int end, IConvertible value)
        {
            Name = token.Name;
            Start = start;
            End = end;
            Value = value;
        }

        protected Token(string name, int start, int end)
        {
            Name = name;
            Start = start;
            End = end;
        }

        public string Name { get; }
        public Regex Expression { get; }
        
        public int Start { get; set; }
        public int End { get; set; }
        public IConvertible Value { get; set; }

        public override string ToString()
        {
            return $"{Name} -> {Value} ** {Start}:{End}";
        }
    }
}