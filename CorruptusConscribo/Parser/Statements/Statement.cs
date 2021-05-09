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
                
                var expression = new Expression().Parse(tokens);

                var statement = new Return(expression);

                token = tokens.Pop();

                if (token.Name != TokenLibrary.Words.Semicolon) throw new Exception("invalid syntax");

                return statement;
            }

            if (token.Name == TokenLibrary.Words.Int)
            {
                return new Declare().Parse(tokens);
            }
            
            var exp = new Expression().Parse(tokens);
            
            token = tokens.Pop();
            
            if (token.Name != TokenLibrary.Words.Semicolon) throw new Exception("invalid syntax");

            return exp;
        }
    }
}