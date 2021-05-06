using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Factor : Term
    {
        // <factor> ::= "(" <exp> ")" | <unary_op> <factor> | <int>
        public Expression Parse(Queue<Token> tokens)
        {
            var token = tokens.Dequeue();

            if (token.Name == TokenLibrary.Words.OpenParenthesis)
            {
                var expression = new Expression().Parse(tokens);

                if (tokens.Dequeue().Name != TokenLibrary.Words.CloseParenthesis) throw new SyntaxException("expected )");

                return expression;
            }

            // if unary operator
            if (token.Name == TokenLibrary.Words.Negation || token.Name == TokenLibrary.Words.BitwiseComplement || token.Name == TokenLibrary.Words.LogicalNegation)
            {
                var op = new UnaryOperator(token);
                var factor = new Factor().Parse(tokens);
                return op.Add(factor);
            }

            if (token.Name == TokenLibrary.Words.IntegerLiteral)
            {
                return new Constant(token.Value.ToInt32(null));
            }

            throw new SyntaxException("Lol u fucked up");
        }
    }
}