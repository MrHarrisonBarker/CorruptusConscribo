using System.Collections.Generic;
using System.Linq;

namespace CorruptusConscribo.Parser
{
    public class FunctionCall : Expression
    {
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
            // var offsetHackStart =
            //     "movq %rsp, %rax" +
            //     $"\nsubq\t${(8*(Args.Count + 1))}, %rax\t# n = (4*(arg_count + 1)), # of bytes allocated for arguments + padding value itself" +
            //     "\n\t\t\t#; eax now contains the value ESP will have when call instruction is executed " +
            //     "\nxorq\t% rdx, %rdx\t# zero out EDX, which will contain remainder of division" +
            //     "\nmovq\t$0x20, %rcx" +
            //     // "\nmovq\t$0x20, %rcx\t# 0x20 = 16" +
            //     "\nidivq\t%rcx\t\t# calculate eax / 16.EDX contains remainder, i.e. # of bytes to subtract from ESP" +
            //     "\nsubq\t%rdx, %rsp\t# pad ESP" +
            //     "\npushq\t%rdx\t\t# push padding result onto stack; we'll need it to deallocate padding later";

            var addArgsCallAndPopArgs =
                $"\n{string.Join("\n", Args.Select(param => $"{param.Template()}\npush\t%rax\t\t# pushing argument {param} to stack"))}" +
                $"\ncall\t_{FunctionId}" +
                $"\naddq\t${Args.Count * 8}, %rsp\t# removing arguments from stack";

            // var offsetHackEnd =
            //     "\npopq\t%rdx\t\t# pop padding result" +
            //     "\naddq\t%rdx, %rsp\t# remove padding";

            return addArgsCallAndPopArgs;
        }
    }
}