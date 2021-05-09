using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class LogicalOrExpression : Expression, IExpression
    {
        public Expression Parse(Stack<Token> tokens)
        {
            var expression = new LogicalAndExpression().Parse(tokens);

            var nextToken = tokens.Peek();

            while (nextToken.Name == TokenLibrary.Words.OR)
            {
                var op = BinaryOperator.New(tokens.Pop());

                var nextExpression = new LogicalAndExpression().Parse(tokens);

                expression = op.Add(expression, nextExpression);

                nextToken = tokens.Peek();
            }

            return expression;
        }
    }
}