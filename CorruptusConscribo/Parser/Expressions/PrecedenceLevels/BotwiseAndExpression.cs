using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class BitwiseAndExpression : Expression
    {
        public Expression Parse(Stack<Token> tokens)
        {
            var expression = new EqualityExpression(Scope).Parse(tokens);

            var nextToken = tokens.Peek();

            while (nextToken.Name == TokenLibrary.Words.BitwiseAnd)
            {
                var op = BinaryOperator.New(Scope, tokens.Pop());

                var nextExpression = new EqualityExpression(Scope).Parse(tokens);

                expression = op.Add(expression, nextExpression);

                nextToken = tokens.Peek();
            }

            return expression;
        }

        public BitwiseAndExpression(Scope scope) : base(scope)
        {
        }
    }
}