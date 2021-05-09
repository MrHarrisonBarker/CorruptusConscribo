using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    // <logical-and-exp> ::= <equality-exp> { "&&" <equality-exp> }
    public class LogicalAndExpression : Expression
    {
        public Expression Parse(Stack<Token> tokens)
        {
            var expression = new BitwiseOrExpression(Scope).Parse(tokens);

            var nextToken = tokens.Peek();

            while (nextToken.Name == TokenLibrary.Words.AND)
            {
                var op = BinaryOperator.New(Scope, tokens.Pop());

                var nextExpression = new BitwiseOrExpression(Scope).Parse(tokens);

                expression = op.Add(expression, nextExpression);

                nextToken = tokens.Peek();
            }

            return expression;
        }

        public LogicalAndExpression(Scope scope) : base(scope)
        {
        }
    }
}