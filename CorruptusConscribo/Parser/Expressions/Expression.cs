using System;
using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Expression : Statement
    {
        // <exp> ::= <id> "=" <exp> | <logical-or-exp>
        // <logical-or-exp> ::= <logical-and-exp> { "||" <logical-and-exp> }
        // <logical-and-exp> ::= <bitwise-or-exp> { "&&" <bitwise-or-exp> }
        // <bitwise-or-exp> ::= <bitwise-xor-exp> { "|" <bitwise-xor-exp> }
        // <bitwise-xor-exp> ::= <bitwise-and-exp> { "^" <bitwise-and-exp> }
        // <bitwise-and-exp> ::= <equality-exp> { "&" <equality-exp> }
        // <equality-exp> ::= <relational-exp> { ("!=" | "==") <relational-exp> }
        // <relational-exp> ::= <shift-exp> { ("<" | ">" | "<=" | ">=") <shift-exp> }
        // <shift-exp> ::= <additive-exp> { ("<<" | ">>") <additive-exp> }
        // <additive-exp> ::= <term> { ("+" | "-") <term> }
        // <term> ::= <factor> { ("*" | "/" | "%") <factor> }
        // <factor> ::= "(" <exp> ")" | <unary_op> <factor> | <int>
        // <unary_op> ::= "!" | "~" | "-"

        public Expression Parse(Stack<Token> tokens)
        {
            var nextToken = tokens.Peek();

            // if the next token is a variable
            if (nextToken.Name == TokenLibrary.Words.Identifier)
            {
                var var = tokens.Pop();

                nextToken = tokens.Peek();

                // if the variable is being assigned to something
                if (nextToken.Name == TokenLibrary.Words.Assignment)
                {
                    var assignment = Assignment.New(Scope, tokens.Pop()).Add((string) var.Value, new Expression(Scope).Parse(tokens));
                    // tokens.Pop();
                    return assignment;
                }

                tokens.Push(var);
            }

            var exp = new LogicalOrExpression(Scope).Parse(tokens);

            return exp;
        }

        public Expression(Scope scope) : base(scope)
        {
        }
    }
}