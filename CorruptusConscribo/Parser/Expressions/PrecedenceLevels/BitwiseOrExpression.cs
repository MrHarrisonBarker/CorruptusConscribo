using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class BitwiseOrExpression : Expression, IExpression
    {
        public Expression Parse(Stack<Token> tokens)
        {
            var expression = new BitwiseXorExpression().Parse(tokens);

            var nextToken = tokens.Peek();

            while (nextToken.Name == TokenLibrary.Words.BitwiseOr)
            {
                var op = BinaryOperator.New(tokens.Pop());

                var nextExpression = new BitwiseXorExpression().Parse(tokens);

                expression = op.Add(expression, nextExpression);
                
                nextToken = tokens.Peek();
            }

            return expression;
        }
    }
}