using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class OptionalCloseParam : Expression
    {
        public OptionalCloseParam(Scope scope) : base(scope)
        {
        }

        public Expression Parse(Stack<Token> tokens)
        {
            var nextToken = tokens.Peek();

            if (nextToken.Name == TokenLibrary.Words.CloseParenthesis)
            {
                tokens.Pop();
                return this;
            }

            var exp = new Expression(Scope).Parse(tokens);

            nextToken = tokens.Pop();

            if (nextToken.Name != TokenLibrary.Words.CloseParenthesis) throw new SyntaxException("expected )");

            return exp;
        }
    }
}