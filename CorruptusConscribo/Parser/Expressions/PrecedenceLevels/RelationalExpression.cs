using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    // <relational-exp> ::= <summing-exp> { ("<" | ">" | "<=" | ">=") <summing-exp> }
    public class RelationalExpression : Expression
    {
        public Expression Parse(Stack<Token> tokens)
        {
            var expression = new ShiftExpression(Scope).Parse(tokens);

            var nextToken = tokens.Peek();

            while (nextToken.Name == TokenLibrary.Words.LessThan || nextToken.Name == TokenLibrary.Words.LessThanOrEqual || nextToken.Name == TokenLibrary.Words.GreaterThan ||
                   nextToken.Name == TokenLibrary.Words.GreaterThanOrEqual)
            {
                var op = BinaryOperator.New(Scope, tokens.Pop());

                var nextExpression = new ShiftExpression(Scope).Parse(tokens);

                expression = op.Add(expression, nextExpression);

                nextToken = tokens.Peek();
            }

            return expression;
        }

        public RelationalExpression(Scope scope) : base(scope)
        {
        }
    }
}