using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Do : Statement
    {
        private Block Statement { get; set; }
        private Expression Expression { get; set; }
        
        public Do(Scope scope) : base(scope)
        {
        }

        // "do" <statement> "while" <exp> ";"
        public Do Parse(Stack<Token> tokens)
        {
            tokens.Pop();

            Statement = new Statement(Scope).Parse(tokens);

            var token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.While) throw new SyntaxException("expected while statement");

            Expression = new Expression(Scope).Parse(tokens);

            token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.Semicolon) throw new SyntaxException("expected ;");
            
            return this;
        }

        public override string ToString()
        {
            return $"do {{\n\t{Statement}\n\t}} while({Expression})";
        }
    }
}