using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class BitwiseAndExpression : Expression, IExpression
    {
        public Expression Parse(Stack<Token> tokens)
        {
            var expression = new EqualityExpression().Parse(tokens);

            var nextToken = tokens.Peek();

            while (nextToken.Name == TokenLibrary.Words.BitwiseAnd)
            {
                var op = BinaryOperator.New(tokens.Pop());

                var nextExpression = new EqualityExpression().Parse(tokens);

                expression = op.Add(expression, nextExpression);
                
                nextToken = tokens.Peek();
            }

            return expression;
        }
    }
}