using System;
using System.Collections.Generic;
using CorruptusConscribo.Parser.Expressions.BinaryOperators;

namespace CorruptusConscribo.Parser
{
    public class Expression : Statement
    {
        public virtual int AbsoluteValue()
        {
            return Int32.MinValue;
        }
        
        // <exp> ::= <id> "=" <exp> | <exp> , <exp> | <conditional-exp>
        // <conditional-exp> ::= <logical-or-exp> [ "?" <exp> ":" <conditional-exp> ]
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
        // <factor> ::= <function-call> | "(" <exp> ")" | <unary_op> <factor> | <int> | <id>
        // <function-call> ::= id "(" [ <exp> { "," <exp> } ] ")"
        // <unary_op> ::= "!" | "~" | "-"

        public Expression Parse(Stack<Token> tokens)
        {
            var expression = new Conditional(Scope).Parse(tokens);

            var nextToken = tokens.Peek();

            if (nextToken.Name == TokenLibrary.Words.Comma)
            {
                var op = BinaryOperator.New(Scope, tokens.Pop());

                var nextExpression = new Conditional(Scope).Parse(tokens);

                expression = op.Add(expression, nextExpression);

                return expression;
            }

            while (nextToken.Name == TokenLibrary.Words.Assignment ||
                   nextToken.Name == TokenLibrary.Words.AdditionAssign ||
                   nextToken.Name == TokenLibrary.Words.SubtractionAssign ||
                   nextToken.Name == TokenLibrary.Words.MultiplicationAssign ||
                   nextToken.Name == TokenLibrary.Words.DivisionAssign ||
                   nextToken.Name == TokenLibrary.Words.ModuloAssign ||
                   nextToken.Name == TokenLibrary.Words.AndAssign ||
                   nextToken.Name == TokenLibrary.Words.OrAssign ||
                   nextToken.Name == TokenLibrary.Words.XorAssign)
            {
                var assignment = Assignment.New(Scope, tokens.Pop());
                var nextExpression = new Conditional(Scope).Parse(tokens);
                expression = assignment.Add(expression, nextExpression);

                nextToken = tokens.Peek();
            }

            if (nextToken.Name == TokenLibrary.Words.Increment || nextToken.Name == TokenLibrary.Words.Decrement)
            {
                return Assignment.New(Scope, tokens.Pop()).Add(expression);
            }

            return expression;
        }

        public Expression(Scope scope) : base(scope)
        {
        }

        public virtual string ControlTemplate()
        {
            return "NO Control Template";
        }
    }
}