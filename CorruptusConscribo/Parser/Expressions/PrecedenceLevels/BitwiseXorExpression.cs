using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class BitwiseXorExpression : Expression
    {
        public Expression Parse(Stack<Token> tokens)
        {
            var expression = new BitwiseAndExpression(Scope).Parse(tokens);

            var nextToken = tokens.Peek();

            while (nextToken.Name == TokenLibrary.Words.BitwiseXor)
            {
                var op = BinaryOperator.New(Scope, tokens.Pop());

                var nextExpression = new BitwiseAndExpression(Scope).Parse(tokens);

                expression = op.Add(expression, nextExpression);

                nextToken = tokens.Peek();
            }

            return expression;
        }

        public BitwiseXorExpression(Scope scope) : base(scope)
        {
        }
    }
}