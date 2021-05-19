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

            if (Scope.LocallyExists(Identifier) && Identifier == null) throw new SyntaxException($"a variable called \"{Identifier}\" already exists");

            var token = tokens.Pop();

            if (token.Name == TokenLibrary.Words.Assignment)
            {
                Initialise = new Expression(Scope).Parse(tokens);
                token = tokens.Pop();
            }

            if (token.Name != TokenLibrary.Words.Semicolon) throw new SyntaxException("; expected");

            if (!Scope.LocallyExists(Identifier))
            {
                Scope.AddGlobal(Identifier, new VariableSnapshot(true, ReturnType, Initialise != null));
            }
            else if (Scope.LocallyExists(Identifier) && Initialise != null)
            {
                Scope.DefineGlobal(Identifier);
            }

            return this;
        }

        public override string ToString()
        {
            return Initialise == null ? $"int {Identifier}" : $"int {Identifier} = {Initialise}";
        }

        public override string Template()
        {
            if (Initialise == null && Scope.HasGlobalBeenDefined(Identifier)) return null;
            if (Initialise == null) return $"\n.globl _{Identifier}\n\t.bss\n\t.align\t4\n_{Identifier}:\n\t.zero 8\n.text\t\t# initialising {Identifier} globally";
            return $"\n.globl _{Identifier}\n\t.data\n\t.align\t4\n_{Identifier}:\n\t.long {Initialise.AbsoluteValue()}\n.text\t\t# initialising {Identifier} globally with declare\n";
        }

        public override string Save()
        {
            return "SAVE NOT ";
        }
    }
}