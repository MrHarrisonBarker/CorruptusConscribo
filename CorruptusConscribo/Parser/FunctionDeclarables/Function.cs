using System;
using System.Collections.Generic;
using System.Linq;

namespace CorruptusConscribo.Parser
{
    public class Function : FunctionDeclare
    {
        private string Name { get; }
        private string ReturnType { get; }
        private List<Slice> Slices { get; }

        public Function(Scope scope, string returnType, string name, List<Slice> slices) : base(scope)
        {
            Name = name;
            ReturnType = returnType;
            Slices = slices;
        }

        public override string Template()
        {
            const string prologue = "push\t%rbp\nmovq\t%rsp,%rbp\n \n";

            var template = $".globl _{Name}\n_{Name}:\n" + prologue;

            // if the function doesn't have a return statement
            if (Slices.All(x => x.GetType() != typeof(Return)))
            {
                Console.WriteLine("Function doesn't have a return statement");
                Slices.Add(new Return(Scope, new Constant(Scope, 0)));
            }

            Slices.ForEach(s => template += s.Template());

            return template;
        }

        public override string ToString()
        {
            return $"Func {ReturnType} {Name}:\n\t{string.Join("\n\t", Slices)}";
        }
    }
}