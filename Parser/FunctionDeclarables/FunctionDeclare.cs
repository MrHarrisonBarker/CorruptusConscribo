using System;
using System.Collections.Generic;
using System.Globalization;

namespace CorruptusConscribo.Parser
{
    public class FunctionDeclare : ASTNode
    {
        public FunctionDeclare Parse(Queue<Token> tokens)
        {
            var token = tokens.Dequeue();

            if (token.Name != TokenLibrary.Words.Int) throw new Exception("invalid syntax");

            token = tokens.Dequeue();

            if (token.Name != TokenLibrary.Words.Identifier) throw new Exception("invalid syntax");

            var id = token.Value;

            // Open close parenthesis
            token = tokens.Dequeue();
            if (token.Name != TokenLibrary.Words.OpenParenthesis) throw new Exception("invalid syntax");
            token = tokens.Dequeue();
            if (token.Name != TokenLibrary.Words.CloseParenthesis) throw new Exception("invalid syntax");

            token = tokens.Dequeue();
            if (token.Name != TokenLibrary.Words.OpenBracket) throw new Exception("invalid syntax");

            // parse the function body statement
            var statement = new Statement().Parse(tokens);

            token = tokens.Dequeue();
            if (token.Name != TokenLibrary.Words.CloseBracket) throw new Exception("invalid syntax");

            return new Function(id.ToString(CultureInfo.InvariantCulture), statement);
        }
    }

    public class Function : FunctionDeclare
    {
        private string Name { get; }
        private Statement Statement { get; }
        
        public Function(string name, Statement statement)
        {
            Name = name;
            Statement = statement;
        }
        
        public override string Template()
        {
            var template = $".globl _{Name}\n_{Name}:\n";
            template += Statement.Template();
            return template;
        }
    }
}