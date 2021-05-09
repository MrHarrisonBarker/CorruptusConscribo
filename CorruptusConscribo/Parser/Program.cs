using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Program
    {
        private FunctionDeclare Function { get; }
        
        public Program(Stack<Token> tokens)
        {
            Function = new FunctionDeclare(new Scope()).Parse(tokens);
        }

        public string Template()
        {
            return Function.Template();
        }

        public override string ToString()
        {
            return $"**** Program ****\n{Function.ToString()}";
        }
    }
}