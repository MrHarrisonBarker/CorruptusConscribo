using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Function : FunctionDeclare
    {
        private string Name { get; }
        private string ReturnType { get; }
        private List<Statement> Statements { get; }

        public Function(Scope scope, string returnType, string name, List<Statement> statements) : base(scope)
        {
            Name = name;
            ReturnType = returnType;
            Statements = statements;
        }

        public override string Template()
        {
            const string prologue = "push\t%rbp\nmovq\t%rsp,%rbp\n \n";

            var template = $".globl _{Name}\n_{Name}:\n" + prologue;

            Statements.ForEach(s => template += s.Template());

            return template;
        }

        public override string ToString()
        {
            return $"Func {ReturnType} {Name}:\n{string.Join("\n", Statements)}";
        }
    }
}