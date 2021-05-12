using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Slice : ASTNode
    {
        public Slice(Scope scope) : base(scope)
        {
        }

        public Slice Parse(Stack<Token> tokens)
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