using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Program : ASTNode
    {
        private FunctionDeclare Function { get; }
        
        public Program(Stack<Token> tokens)
        {
            Function = new FunctionDeclare().Parse(tokens);
        }

        public override string Template()
        {
            return Function.Template();
        }

        public override string ToString()
        {
            return $"**** Program ****\n{Function.ToString()}";
        }
    }
}