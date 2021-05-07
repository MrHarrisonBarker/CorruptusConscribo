using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    // <relational-exp> ::= <summing-exp> { ("<" | ">" | "<=" | ">=") <summing-exp> }
    public class RelationalExpression : Expression, IExpression
    {
        public Expression Parse(Stack<Token> tokens)
        {
            var expression = new ShiftExpression().Parse(tokens);

            var nextToken = tokens.Peek();

            while (nextToken.Name == TokenLibrary.Words.LessThan || nextToken.Name == TokenLibrary.Words.LessThanOrEqual || nextToken.Name == TokenLibrary.Words.GreaterThan || nextToken.Name == TokenLibrary.Words.GreaterThanOrEqual)
            {
                var op = BinaryOperator.New(tokens.Pop());

                var nextExpression = new ShiftExpression().Parse(tokens);

                expression = op.Add(expression, nextExpression);
                
                nextToken = tokens.Peek();
            }

            return expression;
        }
    }
}