using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class BitwiseOrExpression : Expression
    {
        public Expression Parse(Stack<Token> tokens)
        {
            var expression = new BitwiseXorExpression(Scope).Parse(tokens);

            var nextToken = tokens.Peek();

            while (nextToken.Name == TokenLibrary.Words.BitwiseOr)
            {
                var op = BinaryOperator.New(Scope, tokens.Pop());

                var nextExpression = new BitwiseXorExpression(Scope).Parse(tokens);

                expression = op.Add(expression, nextExpression);

                nextToken = tokens.Peek();
            }

            return expression;
        }

        public BitwiseOrExpression(Scope scope) : base(scope)
        {
        }
    }
}