using System;
using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Expression : ASTNode
    {
        public Expression Parse(Queue<Token> tokens)
        {
            var token = tokens.Dequeue();

            if (token.Name == TokenLibrary.Words.IntegerLiteral)
            {
                var expression = new Constant(token.Value.ToInt32(null));

                return expression;
            }
            else
            {
                var expression = new Expression().Parse(tokens);

                return new UnaryOperator(token, expression);
            }

            // if (token.Name != TokenLibrary.Words.IntegerLiteral) throw new Exception("invalid syntax");
        }
    }
}