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

            Scope.Add(Identifier, new VariableSnapshot(true, ReturnType));

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
                if (Initialise.GetType() == typeof(Constant))
                {
                    return $"\n.globl _{Identifier}\n\t.data\n\t.align\t4\n_{Identifier}:\n\t.long {((Constant) Initialise).Value}\n.text\t\t# initialising {Identifier} globally with declare\n";
                }

                // return $"\n{Initialise.Template()}\npushq\t%rax\t\t# initialising {Identifier} globally with declare\n";
            }

            return $"\n.globl _{Identifier}\n.data\n.align\t4\n.text\n";
        }

        public override string Save()
        {
            return "SAVE NOT ";
        }
    }
}