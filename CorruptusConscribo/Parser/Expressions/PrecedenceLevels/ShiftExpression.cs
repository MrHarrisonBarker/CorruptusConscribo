using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class ShiftExpression : Expression, IExpression
    {
        // <shift-exp> ::= <summing-exp> { ("<<" | ">>") <summing-exp> }
        public Expression Parse(Stack<Token> tokens)
        {
            var expression = new SummingExpression().Parse(tokens);

            var nextToken = tokens.Peek();

            while (nextToken.Name == TokenLibrary.Words.BitwiseLeft || nextToken.Name == TokenLibrary.Words.BitwiseRight)
            {
                var op = BinaryOperator.New(tokens.Pop());

                var nextExpression = new SummingExpression().Parse(tokens);

                expression = op.Add(expression, nextExpression);

                nextToken = tokens.Peek();
            }

            return expression;
        }
    }
}