using System;
using System.Collections.Generic;
using System.Linq;

namespace CorruptusConscribo.Parser
{
    public class Function : ASTNode
    {
        private string Name { get; set; }
        private string ReturnType { get; set; }

        private Block Block { get; set; }

        public Function(Scope scope) : base(scope)
        {
        }

        public Function Parse(Stack<Token> tokens)
        {
            var token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.Int) throw new Exception("invalid syntax");

            ReturnType = token.Name;

            token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.Identifier) throw new Exception("invalid syntax");

            Name = (string) token.Value;

            // Open close parenthesis
            token = tokens.Pop();
            if (token.Name != TokenLibrary.Words.OpenParenthesis) throw new Exception("invalid syntax");
            token = tokens.Pop();
            if (token.Name != TokenLibrary.Words.CloseParenthesis) throw new Exception("invalid syntax");

            Block = new Block(Scope).Parse(tokens);

            return this;
        }

        public override string Template()
        {
            const string prologue = "push\t%rbp\t# push stack" +
                                    "\nmovq\t%rsp,%rbp\t# move call stack\n";

            var template = $".globl _{Name}\n_{Name}:\n" + prologue;

            // if the function doesn't have a return statement
            if (Block.Slices.All(x => x.GetType() != typeof(Return)))
            {
                Console.WriteLine("Function doesn't have a return statement");
                Block.Slices.Add(new Return(Scope, new Constant(Scope, 0)));
            }

            Block.Slices.ForEach(s => template += s.Template());

            return template;
        }

        public override string ToString()
        {
            return $"Func {ReturnType} {Name}:\n\t{Block}";
        }
    }
}