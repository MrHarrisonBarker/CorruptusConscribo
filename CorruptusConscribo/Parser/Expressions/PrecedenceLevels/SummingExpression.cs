using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    // <summing-exp> ::= <term> { ("+" | "-") <term> }
    public class SummingExpression : Expression
    {
        public Expression Parse(Stack<Token> tokens)
        {
            var expression = new Term(Scope).Parse(tokens);

            var nextToken = tokens.Peek();

            while (nextToken.Name == TokenLibrary.Words.Addition || nextToken.Name == TokenLibrary.Words.Negation)
            {
                var op = BinaryOperator.New(Scope, tokens.Pop());

                var nextExpression = new Term(Scope).Parse(tokens);

                expression = op.Add(expression, nextExpression);

                nextToken = tokens.Peek();
            }

            return expression;
        }

        public SummingExpression(Scope scope) : base(scope)
        {
        }
    }
}