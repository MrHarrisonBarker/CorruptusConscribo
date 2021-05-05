using System;
using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Factor : BinaryOperator
    {
        private BinaryOperator Operator { get; }
        private Expression Expression { get; }

        public Factor()
        {
        }

        private Factor(Expression expression)
        {
            Expression = expression;
        }

        public Factor(BinaryOperator op)
        {
            Operator = op;
        }

        public Factor Parse(Queue<Token> tokens)
        {
            var token = tokens.Dequeue();

            if (token.Name == TokenLibrary.Words.OpenParenthesis)
            {
                var expression = new Expression().Parse(tokens);

                if (tokens.Dequeue().Name != TokenLibrary.Words.CloseParenthesis) throw new SyntaxException("expected )");

                return new Factor(expression);
            }

            return null;
        }
    }
}