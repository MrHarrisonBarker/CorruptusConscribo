using System;
using System.Collections.Generic;
using System.Linq;

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

            // if the function doesn't have a return statement
            if (Statements.All(x => x.GetType() != typeof(Return)))
            {
                Console.WriteLine("Function doesn't have a return statement");
                Statements.Add(new Return(Scope, new Constant(Scope, 0)));
            }

            Statements.ForEach(s => template += s.Template());

            return template;
        }

        public override string ToString()
        {
            return $"Func {ReturnType} {Name}:\n{string.Join("\n", Statements)}";
        }
    }
}