using System;
using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Expression : ASTNode
    {
        // private Expression Term { get; set; }

        // <exp> ::= <term> { ("+" | "-") <term> }
        // <term> ::= <factor> { ("*" | "/") <factor> }
        // <factor> ::= "(" <exp> ")" | <unary_op> <factor> | <int>

        public Expression Parse(Stack<Token> tokens)
        {
            // get the first/left expression as a term
            // multiplication and division will happen here first for higher precedence
            Expression exp = new Term().Parse(tokens);

            var nextToken = tokens.Peek();

            // if the next token is a plus or minus
            while (nextToken.Name == TokenLibrary.Words.Addition || nextToken.Name == TokenLibrary.Words.Negation)
            {
                // create the binary operator using the current token
                var op = BinaryOperator.New(tokens.Pop());

                // get the expression after the operator
                var nextExp = new Term().Parse(tokens);

                // set the expression to the binary operator with its left and right expression
                exp = op.Add(exp, nextExp);

                nextToken = tokens.Peek();
            }

            return exp;

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
            // return new UnaryOperator(token, expression);
            // }

            // if (token.Name != TokenLibrary.Words.IntegerLiteral) throw new Exception("invalid syntax");
        }
    }
}