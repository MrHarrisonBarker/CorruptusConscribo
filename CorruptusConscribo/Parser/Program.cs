using System.Collections.Generic;
using System.Linq;

namespace CorruptusConscribo.Parser
{
    public class Program
    {
        public List<Function> Functions { get; set; } = new List<Function>();
        private Scope GlobalScope { get; } = new();

        public Program(Stack<Token> tokens)
        {
            var nextToken = tokens.Peek();

            // if there is a type keyword
            while (nextToken.Name == TokenLibrary.Words.Int)
            {
                Functions.Add(new Function(new Scope()).Parse(tokens));
                if (!tokens.TryPeek(out nextToken)) break;
            }
        }

        public string Template()
        {
            var jmp = "jmp\t_main\t\t# calling main method\n\n";
            return string.Join("\n", Functions.Select(x => x.Template()));
        }

        public override string ToString()
        {
            return $"**** Program ****\n{string.Join("\n", Functions)}";
        }
    }
}