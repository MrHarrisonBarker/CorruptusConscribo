using System;
using System.Collections.Generic;
using System.Globalization;

namespace CorruptusConscribo.Parser
{
    public class FunctionDeclare : Block
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
            var slices = new List<Slice>();

            while (nextToken.Name != TokenLibrary.Words.CloseBracket)
            {
                slices.Add(new Slice(Scope).Parse(tokens));
                nextToken = tokens.Peek();
            }

            return new Function(Scope, returnType, id.ToString(CultureInfo.InvariantCulture), slices);
        }

        public FunctionDeclare(Scope scope) : base(scope)
        {
        }
    }
}