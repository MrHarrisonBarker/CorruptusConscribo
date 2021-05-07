using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    // <logical-and-exp> ::= <equality-exp> { "&&" <equality-exp> }
    public class LogicalAndExpression : Expression, IExpression
    {
        public Expression Parse(Stack<Token> tokens)
        {
            var expression = new BitwiseOrExpression().Parse(tokens);

            var nextToken = tokens.Peek();

            while (nextToken.Name == TokenLibrary.Words.AND)
            {
                var op = BinaryOperator.New(tokens.Pop());

                var nextExpression = new BitwiseOrExpression().Parse(tokens);

                expression = op.Add(expression, nextExpression);
                
                nextToken = tokens.Peek();
            }

            return expression;
        }
    }
}