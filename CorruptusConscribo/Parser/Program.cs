using System.Collections.Generic;
using System.Linq;

namespace CorruptusConscribo.Parser
{
    public class Program
    {
        public List<TopLevelBlock> TopLevelBlocks { get; set; } = new();
        private Scope GlobalScope { get; } = new();

        public Program(Stack<Token> tokens)
        {
            var nextToken = tokens.Peek();

            while (nextToken != null)
            {
                TopLevelBlocks.Add(new TopLevelBlock(GlobalScope).Parse(tokens));
                if (!tokens.TryPeek(out nextToken)) break;
            }
            
            // // if there is a type keyword
            // while (nextToken.Name == TokenLibrary.Words.Int)
            // {
            //     var token = tokens.Pop();
            //     
            //     
            //     // TODO: adding global scope breaks things for some reason?
            //     TopLevelBlocks.Add(new Function(new Scope()).Parse(tokens,(string)token.Value));
            //     if (!tokens.TryPeek(out nextToken)) break;
            // }
        }

        public string Template()
        {
            return string.Join("\n", TopLevelBlocks.Select(x => x.Template()));
        }

        public override string ToString()
        {
            return $"**** Program ****\n{string.Join("\n", TopLevelBlocks)}";
        }
    }
}