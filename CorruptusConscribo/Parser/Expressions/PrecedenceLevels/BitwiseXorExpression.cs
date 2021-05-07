using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class BitwiseXorExpression : Expression, IExpression
    {
        public Expression Parse(Stack<Token> tokens)
        {
            var expression = new BitwiseAndExpression().Parse(tokens);

            var nextToken = tokens.Peek();

            while (nextToken.Name == TokenLibrary.Words.BitwiseXor)
            {
                var op = BinaryOperator.New(tokens.Pop());

                var nextExpression = new BitwiseAndExpression().Parse(tokens);

                expression = op.Add(expression, nextExpression);
                
                nextToken = tokens.Peek();
            }

            return expression;
        }
    }
}