using System.Collections.Generic;
using System.Linq;

namespace CorruptusConscribo.Parser
{
    public class FunctionCall : Expression
    {
        private readonly Stack<string> ArgsStack = new(new[]
        {
            "r9", "r8", "rcx", "%rdx", "%rsi", "%rdi"
        });

        public string FunctionId { get; set; }
        public List<Expression> Args { get; set; } = new();

        public FunctionCall(Scope scope) : base(scope)
        {
        }

        // <function-call> ::= id "(" [ <exp> { "," <exp> } ] ")"
        public FunctionCall Parse(Stack<Token> tokens, string functionId)
        {
            FunctionId = functionId;

            var token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.OpenParenthesis) throw new SyntaxException("expected (");

            var nextToken = tokens.Peek();

            while (nextToken.Name != TokenLibrary.Words.CloseParenthesis)
            {
                Args.Add(new Conditional(Scope).Parse(tokens));
                nextToken = tokens.Peek();
                if (nextToken.Name == TokenLibrary.Words.Comma)
                {
                    tokens.Pop();
                    nextToken = tokens.Peek();
                }
            }

            token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.CloseParenthesis) throw new SyntaxException("expected )");

            return this;
        }

        public override string ToString()
        {
            return $"{FunctionId}({string.Join(",", Args)})";
        }

        public override string Template()
        {
            var arguments = string.Join("\n", Args.Select(arg => $"{arg.Template()}\nmovq\t%rax, {ArgsStack.Pop()}\t# moving argument {arg}"));
            
            var addArgsCallAndPopArgs =
                "\nsubq\t$16, %rsp\t#offsetting" +
                $"\n{arguments}" +
                $"\ncall\t_{FunctionId}" +
                $"\naddq\t${Args.Count * 8}, %rsp\t# removing arguments from stack";

            return addArgsCallAndPopArgs;
        }
    }
}