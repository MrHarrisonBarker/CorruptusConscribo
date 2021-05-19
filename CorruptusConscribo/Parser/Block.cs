using System;
using System.Collections.Generic;
using System.Linq;

namespace CorruptusConscribo.Parser
{
    public class Block : TopLevelBlock
    {
        public List<ASTNode> Slices = new();

        public Block(Scope scope) : base(scope)
        {
        }

        public Block Parse(Stack<Token> tokens)
        {
            var token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.OpenBracket) throw new SyntaxException("expected {");

            token = tokens.Peek();

            while (token.Name != TokenLibrary.Words.CloseBracket)
            {
                Slices.Add(new Slice(Scope).Parse(tokens));
                token = tokens.Peek();
            }

            tokens.Pop();

            return this;
        }

        public override string Template()
        {
            var tmp = string.Join("\n", Slices.Select(x => x.Template())) + Scope.Deallocate();
            return tmp;
        }

        public override string ToString()
        {
            return $"{string.Join("\n\t", Slices)}";
        }
    }
}