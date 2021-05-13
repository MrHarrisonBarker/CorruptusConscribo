using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Continue : Statement
    {
        public Continue(Scope scope) : base(scope)
        {
        }

        public Continue Parse(Stack<Token> tokens)
        {
            tokens.Pop();

            var token = tokens.Pop();
            
            if (token.Name != TokenLibrary.Words.Semicolon) throw new SyntaxException("expected ;");
            
            return this;
        }
        
        public override string ToString()
        {
            return "continue;";
        }
    }
}