using System;
using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Declare : Slice
    {
        private Expression Initialise { get; set; }
        private string Identifier { get; set; }
        private string Type { get; set; }

        public Declare Parse(Stack<Token> tokens)
        {
            Type = (string) tokens.Pop().Value;

            var token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.Identifier) throw new SyntaxException("expected identifier");

            Identifier = (string) token.Value;

            if (Scope.LocallyExists(Identifier)) throw new SyntaxException($"a variable called \"{Identifier}\" already exists");

            token = tokens.Pop();

            if (token.Name == TokenLibrary.Words.Assignment)
            {
                Initialise = new Expression(Scope).Parse(tokens);
                token = tokens.Pop();
            }

            if (token.Name != TokenLibrary.Words.Semicolon) throw new SyntaxException("expected ;");

            // add variable to the scope TODO: value not set to init
            Scope.Add(Identifier, new VariableSnapshot(Type));

            return this;
        }

        public override string ToString()
        {
            return Initialise == null ? $"int {Identifier}" : $"int {Identifier} = {Initialise}";
        }

        public override string Template()
        {
            if (Initialise != null)
            {
                return $"\n{Initialise.Template()}\npushq\t%rax\t# initialising {Identifier} with declare\n";
            }

            return "\nmovq\t$0,%rax\npushq\t%rax\t# initialising {Identifier} as 0\n";
        }

        public Declare(Scope scope) : base(scope)
        {
        }
    }
}