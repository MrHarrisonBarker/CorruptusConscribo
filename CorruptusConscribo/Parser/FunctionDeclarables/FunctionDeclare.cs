using System;
using System.Collections.Generic;
using System.Globalization;

namespace CorruptusConscribo.Parser
{
    public class FunctionDeclare : ASTNode
    {
        // <function> ::= "int" <id> "(" ")" "{" { <statement> } "}"
        public FunctionDeclare Parse(Stack<Token> tokens)
        {
            var token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.Int) throw new Exception("invalid syntax");

            var returnType = token.Name;

            token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.Identifier) throw new Exception("invalid syntax");

            var id = token.Value;

            // Open close parenthesis
            token = tokens.Pop();
            if (token.Name != TokenLibrary.Words.OpenParenthesis) throw new Exception("invalid syntax");
            token = tokens.Pop();
            if (token.Name != TokenLibrary.Words.CloseParenthesis) throw new Exception("invalid syntax");

            token = tokens.Pop();
            if (token.Name != TokenLibrary.Words.OpenBracket) throw new Exception("invalid syntax");

            var nextToken = tokens.Peek();
            var statements = new List<Statement>();

            while (nextToken.Name != TokenLibrary.Words.CloseBracket)
            {
                statements.Add(new Statement().Parse(tokens));
                nextToken = tokens.Peek();
            }
            
            return new Function(returnType, id.ToString(CultureInfo.InvariantCulture), statements);
        }
    }

    public class Function : FunctionDeclare
    {
        private string Name { get; }
        private string ReturnType { get; }
        private List<Statement> Statements { get; }

        public Function(string returnType, string name, List<Statement> statements)
        {
            Name = name;
            ReturnType = returnType;
            Statements = statements;
        }

        public override string Template()
        {
            var template = $".globl _{Name}\n_{Name}:\n";

            Statements.ForEach(s => template += s.Template());

            return template;
        }

        public override string ToString()
        {
            return $"Func {ReturnType} {Name}:\n{string.Join("\n", Statements)}";
        }
    }
}