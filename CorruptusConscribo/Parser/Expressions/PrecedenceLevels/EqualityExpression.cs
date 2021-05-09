using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    // <equality-exp> ::= <relational-exp> { ("!=" | "==") <relational-exp> }
    public class EqualityExpression : Expression
    {
        public Expression Parse(Stack<Token> tokens)
        {
            var expression = new RelationalExpression(Scope).Parse(tokens);

            var nextToken = tokens.Peek();

            while (nextToken.Name == TokenLibrary.Words.Equal || nextToken.Name == TokenLibrary.Words.NotEqual)
            {
                var op = BinaryOperator.New(Scope, tokens.Pop());

                var nextExpression = new RelationalExpression(Scope).Parse(tokens);

                expression = op.Add(expression, nextExpression);

                nextToken = tokens.Peek();
            }

            return expression;
        }

        public EqualityExpression(Scope scope) : base(scope)
        {
        }
    }
}