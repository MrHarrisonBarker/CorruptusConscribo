using System;
using System.Collections.Generic;
using System.Linq;

namespace CorruptusConscribo.Parser
{
    public class Statement : Slice
    {
        // <statement> ::= "return" <exp> ";"
        //  | <exp> ";"
        //  | "if" "(" <exp> ")" <statement> [ "else" <statement> ]
        //  | "{" { <block-item> } "}
        public Block Parse(Stack<Token> tokens)
        {
            var token = tokens.Peek();
            
            if (token.Name == TokenLibrary.Words.OpenBracket)
            {
                return new Block(new Scope(Scope)).Parse(tokens);
            }

            if (token.Name == TokenLibrary.Words.If)
            {
                tokens.Pop();
                return new If(Scope).Parse(tokens);
            }

            if (token.Name == TokenLibrary.Words.Return)
            {
                tokens.Pop();

                var expression = new Expression(Scope).Parse(tokens);

                var statement = new Return(Scope, expression);

                token = tokens.Pop();

                if (token.Name != TokenLibrary.Words.Semicolon) throw new SyntaxException("expected ;");

                return statement;
            }

            var exp = new Expression(Scope).Parse(tokens);

            token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.Semicolon) throw new SyntaxException("expected ;");

            return exp;
        }

        public Statement(Scope scope) : base(scope)
        {
        }
    }
}