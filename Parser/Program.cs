using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Program : ASTNode
    {
        public FunctionDeclare Function { get; }
        
        public Program(Queue<Token> tokens)
        {
            Function = new FunctionDeclare().Parse(tokens);
        }
    }
}