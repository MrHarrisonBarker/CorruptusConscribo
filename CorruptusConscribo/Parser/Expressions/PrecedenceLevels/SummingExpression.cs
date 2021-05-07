using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    // <summing-exp> ::= <term> { ("+" | "-") <term> }
    public class SummingExpression : Expression, IExpression
    {
        public Expression Parse(Stack<Token> tokens)
        {
            var expression = new Term().Parse(tokens);

            var nextToken = tokens.Peek();

            while (nextToken.Name == TokenLibrary.Words.Addition || nextToken.Name == TokenLibrary.Words.Negation)
            {
                var op = BinaryOperator.New(tokens.Pop());

                var nextExpression = new Term().Parse(tokens);

                expression = op.Add(expression, nextExpression);
                
                nextToken = tokens.Peek();
            }

            return expression;
        }
    }
}