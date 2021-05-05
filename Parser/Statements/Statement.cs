using System;
using System.Collections.Generic;
using System.Linq;

namespace CorruptusConscribo.Parser
{
    public class Statement : ASTNode
    {
        public Statement Parse(Queue<Token> tokens)
        {
            var token = tokens.Dequeue();

            if (token.Name != TokenLibrary.Words.Return) throw new Exception("invalid syntax");

            // token = tokens.Dequeue();
            //
            // if (token.Name != TokenLibrary.Words.IntegerLiteral) throw new Exception("invalid syntax");

            var expression = new Expression().Parse(tokens);

            var statement = new Return(expression);
            
            token = tokens.Dequeue();
            
            if (token.Name != TokenLibrary.Words.Semicolon) throw new Exception("invalid syntax");

            return statement;
        }
    }

    public class Return : Statement
    {
        public Expression Expression { get; }
        public Return(Expression expression)
        {
            Expression = expression;
        }
    }
}