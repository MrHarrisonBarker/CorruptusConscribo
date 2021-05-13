using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class OptionalSemicolon : Expression
    {
        public OptionalSemicolon(Scope scope) : base(scope)
        {
        }

        public Expression Parse(Stack<Token> tokens)
        {
            var nextToken = tokens.Peek();

            if (nextToken.Name == TokenLibrary.Words.Semicolon)
            {
                tokens.Pop();
                return this;
            }

            var exp = new Expression(Scope).Parse(tokens);

            nextToken = tokens.Pop();

            if (nextToken.Name != TokenLibrary.Words.Semicolon) throw new SyntaxException("expected ;");

            return exp;
        }
    }
}