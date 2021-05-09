using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class LogicalOrExpression : Expression
    {
        public Expression Parse(Stack<Token> tokens)
        {
            var expression = new LogicalAndExpression(Scope).Parse(tokens);

            var nextToken = tokens.Peek();

            while (nextToken.Name == TokenLibrary.Words.OR)
            {
                var op = BinaryOperator.New(Scope, tokens.Pop());

                var nextExpression = new LogicalAndExpression(Scope).Parse(tokens);

                expression = op.Add(expression, nextExpression);

                nextToken = tokens.Peek();
            }

            return expression;
        }

        public LogicalOrExpression(Scope scope) : base(scope)
        {
        }
    }
}