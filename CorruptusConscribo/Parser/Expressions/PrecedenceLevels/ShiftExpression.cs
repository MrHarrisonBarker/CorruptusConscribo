using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class ShiftExpression : Expression
    {
        // <shift-exp> ::= <summing-exp> { ("<<" | ">>") <summing-exp> }
        public Expression Parse(Stack<Token> tokens)
        {
            var expression = new SummingExpression(Scope).Parse(tokens);

            var nextToken = tokens.Peek();

            while (nextToken.Name == TokenLibrary.Words.BitwiseLeft || nextToken.Name == TokenLibrary.Words.BitwiseRight)
            {
                var op = BinaryOperator.New(Scope, tokens.Pop());

                var nextExpression = new SummingExpression(Scope).Parse(tokens);

                expression = op.Add(expression, nextExpression);

                nextToken = tokens.Peek();
            }

            return expression;
        }

        public ShiftExpression(Scope scope) : base(scope)
        {
        }
    }
}