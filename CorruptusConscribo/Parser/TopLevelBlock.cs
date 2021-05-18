using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class TopLevelBlock : ASTNode
    {
        protected string ReturnType { get; set; }
        public string Identifier { get; set; }

        public TopLevelBlock(Scope scope) : base(scope)
        {
        }

        public TopLevelBlock Parse(Stack<Token> tokens)
        {
            var token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.Int) throw new SyntaxException("type required");

            ReturnType = (string) token.Value;

            token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.Identifier) throw new SyntaxException("expected identifier");

            Identifier = (string) token.Value;

            token = tokens.Peek();

            // if function
            if (token.Name == TokenLibrary.Words.OpenParenthesis)
            {
                return new Function(Scope).Parse(tokens, ReturnType, Identifier);
            }

            return new GlobalVariable(Scope).Parse(tokens, ReturnType, Identifier);
        }
    }
}