using System;
using System.Collections.Generic;
using System.Linq;

namespace CorruptusConscribo.Parser
{
    public class Statement : ASTNode
    {
        // <statement> ::= "return" <exp> "; | <exp> ";" | "int" <id> [ = <exp> ] ";"
        public Statement Parse(Stack<Token> tokens)
        {
            var token = tokens.Peek();

            if (token.Name == TokenLibrary.Words.Return)
            {
                tokens.Pop();
                
                var expression = new Expression(Scope).Parse(tokens);

                var statement = new Return(Scope,expression);

                token = tokens.Pop();

                if (token.Name != TokenLibrary.Words.Semicolon) throw new Exception("invalid syntax");

                return statement;
            }

            if (token.Name == TokenLibrary.Words.Int)
            {
                return new Declare(Scope).Parse(tokens);
            }
            
            var exp = new Expression(Scope).Parse(tokens);
            
            token = tokens.Pop();
            
            if (token.Name != TokenLibrary.Words.Semicolon) throw new Exception("invalid syntax");

            return exp;
        }

        public Statement(Scope scope) : base(scope)
        {
        }
    }
}