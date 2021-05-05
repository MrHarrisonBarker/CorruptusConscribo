using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Program : ASTNode
    {
        private FunctionDeclare Function { get; }
        
        public Program(Queue<Token> tokens)
        {
            Function = new FunctionDeclare().Parse(tokens);
        }

        public override string Template()
        {
            return Function.Template();
        }
    }
}