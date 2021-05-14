using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Break : Statement
    {
        public string BreakPoint { get; private set; }
        
        public Break(Scope scope) : base(scope)
        {
        }

        public Break Parse(Stack<Token> tokens)
        {
            tokens.Pop();
            
            var token = tokens.Pop();
            
            if (token.Name != TokenLibrary.Words.Semicolon) throw new SyntaxException("expected ;");
            
            // TODO: This could lead to a better solution!
            Scope.AddBreakpoint();
            
            return this;
        }

        public override string ToString()
        {
            return "break;";
        }

        public override string Template()
        {
            return $"jmp\t{Scope.BreakpointId()}\t# jump to breakpoint\n";
        }
    }
}