using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Factor : Term
    {
        // <factor> ::= "(" <exp> ")" | <unary_op> <factor> | <int>
        public Expression Parse(Stack<Token> tokens)
        {
            var token = tokens.Pop();

            if (token.Name == TokenLibrary.Words.OpenParenthesis)
            {
                var expression = new Expression(Scope).Parse(tokens);

                if (tokens.Pop().Name != TokenLibrary.Words.CloseParenthesis) throw new SyntaxException("expected )");

                return expression;
            }

            // if unary operator
            if (token.Name == TokenLibrary.Words.Negation || token.Name == TokenLibrary.Words.BitwiseComplement || token.Name == TokenLibrary.Words.LogicalNegation)
            {
                var op = UnaryOperator.New(Scope, token);
                var factor = new Factor(Scope).Parse(tokens);
                return op.Add(factor);
            }

            if (token.Name == TokenLibrary.Words.IntegerLiteral)
            {
                return new Constant(Scope, token.Value.ToInt32(null));
            }

            if (token.Name == TokenLibrary.Words.Identifier)
            {
                if (tokens.Peek().Name == TokenLibrary.Words.OpenParenthesis)
                {
                    return new FunctionCall(Scope).Parse(tokens, (string) token.Value);
                }

                return new Variable(Scope, (string) token.Value);
            }

            throw new SyntaxException("Lol u fucked up");
        }

        public Factor(Scope scope) : base(scope)
        {
        }
    }
}