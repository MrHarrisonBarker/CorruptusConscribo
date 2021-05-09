using System;
using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Declare : Statement
    {
        private Expression Initialise { get; set; }
        private string Identifier { get; set; }
        private string Type { get; set; }

        public Declare Parse(Stack<Token> tokens)
        {
            Type = (string) tokens.Pop().Value;

            var token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.Identifier) throw new SyntaxException("expected identifier");

            Identifier = (string) token.Value;

            token = tokens.Pop();

            if (token.Name == TokenLibrary.Words.Assignment)
            {
                Initialise = new Expression().Parse(tokens);
                token = tokens.Pop();
            }

            if (token.Name != TokenLibrary.Words.Semicolon) throw new SyntaxException("expected ;");

            return this;
        }

        public override string ToString()
        {
            return Initialise == null ? $"\tint {Identifier}" : $"\tint {Identifier} = {Initialise}";
        }
    }
}