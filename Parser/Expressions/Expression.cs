using System;
using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Expression : ASTNode
    {
        // <exp> ::= <term> { ("+" | "-") <term> }
        // <term> ::= <factor> { ("*" | "/") <factor> }
        // <facto   r> ::= "(" <exp> ")" | <unary_op> <factor> | <int>

        public Expression Parse(Queue<Token> tokens)
        {
            // get the first/left expression as a term
            // multiplication and division will happen here first for higher precedence
            var term = new Term().Parse(tokens);

            var nextToken = tokens.Peek();

            // if the next token is a plus or minus
            while (nextToken.Name == TokenLibrary.Words.Addition || nextToken.Name == TokenLibrary.Words.Negation)
            {
                var op = new BinaryOperator(tokens.Dequeue());
                var nextTerm = new Term().Parse(tokens);
                term = new Term(new BinaryOperator(op, term, nextTerm));
                nextToken = tokens.Peek();
            }

            // might be wrong
            return term;

            // if (token.Name == TokenLibrary.Words.IntegerLiteral)
            // {
            //     var expression = new Constant(token.Value.ToInt32(null));
            //
            //     return expression;
            // }
            // else
            // {
            //     var expression = new Expression().Parse(tokens);
            //
            //     return new UnaryOperator(token, expression);
            // }

            // if (token.Name != TokenLibrary.Words.IntegerLiteral) throw new Exception("invalid syntax");
        }
    }
}