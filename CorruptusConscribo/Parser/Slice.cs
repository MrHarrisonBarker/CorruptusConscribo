using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Slice : Block
    {
        public Slice(Scope scope) : base(scope)
        {
        }

        public Block Parse(Stack<Token> tokens)
        {
            var token = tokens.Peek();

            if (token.Name == TokenLibrary.Words.Int)
            {
                return new Declare(Scope).Parse(tokens);
            }

            return new Statement(Scope).Parse(tokens);
        }
    }
}