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

            switch (token.Name)
            {
                case TokenLibrary.Words.Continue:
                    return new Continue(Scope).Parse(tokens);
                case TokenLibrary.Words.Break:
                    return new Break(Scope).Parse(tokens);
                case TokenLibrary.Words.Do:
                    return new Do(Scope).Parse(tokens);
                case TokenLibrary.Words.While:
                    return new While(Scope).Parse(tokens);
                case TokenLibrary.Words.For:
                    // TODO: decide between normal for and declare for
                    return new For(Scope).Parse(tokens);
                case TokenLibrary.Words.OpenBracket:
                    return new Block(new Scope(Scope)).Parse(tokens);
                case TokenLibrary.Words.If:
                    tokens.Pop();
                    return new If(Scope).Parse(tokens);
                case TokenLibrary.Words.Return:
                    return new Return(Scope).Parse(tokens);
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