using System;
using System.Collections.Generic;
using System.Linq;

namespace CorruptusConscribo.Parser
{
    public class Statement : ASTNode
    {
        public Statement Parse(Stack<Token> tokens)
        {
            var token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.Return) throw new Exception("invalid syntax");

            // token = tokens.Pop();
            //
            // if (token.Name != TokenLibrary.Words.IntegerLiteral) throw new Exception("invalid syntax");

            var expression = new Expression().Parse(tokens);

            var statement = new Return(expression);
            
            token = tokens.Pop();
            
            if (token.Name != TokenLibrary.Words.Semicolon) throw new Exception("invalid syntax");

            return statement;
        }
    }
    
    public class Return : Statement
    {
        private Expression Expression { get; }
        public Return(Expression expression)
        {
            Expression = expression;
        }

        public override string Template()
        {
            return $"{Expression.Template()}\nret";
        }

        public override string ToString()
        {
            return $"\tReturn {Expression.ToString()}";
        }
    }
}