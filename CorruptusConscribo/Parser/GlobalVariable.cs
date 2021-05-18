using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class GlobalVariable : TopLevelBlock
    {
        private Expression Initialise { get; set; }
        
        public GlobalVariable(Scope scope) : base(scope)
        {
        }

        public GlobalVariable Parse(Stack<Token> tokens, string returnType, string identifier)
        {
            ReturnType = returnType;
            Identifier = identifier;

            if (Scope.LocallyExists(Identifier)) throw new SyntaxException($"a variable called \"{Identifier}\" already exists");

            var token = tokens.Pop();

            if (token.Name == TokenLibrary.Words.Assignment)
            {
                Initialise = new Expression(Scope).Parse(tokens);
                token = tokens.Pop();
            }

            if (token.Name != TokenLibrary.Words.Semicolon) throw new SyntaxException("; expected");

            Scope.Add(Identifier, new VariableSnapshot(ReturnType));

            return this;
        }
        
        public override string ToString()
        {
            return Initialise == null ? $"int {Identifier}" : $"int {Identifier} = {Initialise}";
        }

        // public override string Template()
        // {
        //     if (Initialise != null)
        //     {
        //         return $"\n{Initialise.Template()}\npushq\t%rax\t\t# initialising {Identifier} globally with declare\n";
        //     }
        //
        //     return "\nmovq\t$0,%rax\npushq\t%rax\t# initialising {Identifier} globally as 0\n";
        // }
    }
}