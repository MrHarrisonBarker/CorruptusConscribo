using System;
using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Expression : ASTNode, IExpression
    {

        // <exp> ::= <logical-and-exp> { "||" <logical-and-exp> }
        // <logical-and-exp> ::= <equality-exp> { "&&" <equality-exp> }
        // <equality-exp> ::= <relational-exp> { ("!=" | "==") <relational-exp> }
        // <relational-exp> ::= <additive-exp> { ("<" | ">" | "<=" | ">=") <additive-exp> }
        // <additive-exp> ::= <term> { ("+" | "-") <term> }
        // <term> ::= <factor> { ("*" | "/") <factor> }
        // <factor> ::= "(" <exp> ")" | <unary_op> <factor> | <int>
        // <unary_op> ::= "!" | "~" | "-"

        public Expression Parse(Stack<Token> tokens)
        {
            var exp = new LogicalExpression().Parse(tokens);

            var nextToken = tokens.Peek();
            
            while (nextToken.Name == TokenLibrary.Words.OR)
            {
                var op = BinaryOperator.New(tokens.Pop());
                
                var nextExp = new LogicalExpression().Parse(tokens);
                
                exp = op.Add(exp, nextExp);

                nextToken = tokens.Peek();
            }

            return exp;
        }
    }
}