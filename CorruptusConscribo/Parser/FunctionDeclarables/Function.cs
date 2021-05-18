using System;
using System.Collections.Generic;
using System.Linq;

namespace CorruptusConscribo.Parser
{
    public class Function : TopLevelBlock
    {
        private readonly Stack<string> ParamStack = new(new[]
        {
            "r9", "r8", "rcx", "%rdx", "%rsi", "%rdi"
        });
        
        public List<Declare> Params { get; set; } = new();
        public Block Block { get; set; }

        public Function(Scope scope) : base(scope)
        {
        }

        // <function> ::= "int" <id> "(" [ "int" <id> { "," "int" <id> } ] ")" ( "{" { <block-item> } "}" | ";" )
        public Function Parse(Stack<Token> tokens, string returnType, string identifier)
        {
            ReturnType = returnType;
            Identifier = identifier;
            
            var token = tokens.Pop();
            
            if (token.Name != TokenLibrary.Words.OpenParenthesis) throw new SyntaxException("expected (");

            token = tokens.Pop();
            // while there is another param
            while (token.Name == TokenLibrary.Words.Int)
            {
                var paramType = (string) token.Value;

                token = tokens.Pop();

                if (token.Name != TokenLibrary.Words.Identifier) throw new SyntaxException("expected parameter identifier");

                var paramId = (string) token.Value;

                Params.Add(new Declare(Scope, paramId, paramType));

                token = tokens.Peek();

                if (token.Name != TokenLibrary.Words.Comma)
                {
                    token = tokens.Pop();
                    break;
                }

                tokens.Pop();
                token = tokens.Pop();
            }

            if (token.Name != TokenLibrary.Words.CloseParenthesis) throw new SyntaxException($"expected )");

            var nextToken = tokens.Peek();

            if (nextToken.Name == TokenLibrary.Words.Semicolon)
            {
                tokens.Pop();
                return this;
            }

            Block = new Block(Scope).Parse(tokens);

            return this;
        }

        public override string Template()
        {
            if (Block == null) return null;

            const string prologue = "push\t%rbp\t\t# push stack" +
                                    "\nmovq\t%rsp,%rbp\t# move call stack\n\n";

            var parameters = string.Join("\n", Params.Select(param => $"push\t{ParamStack.Pop()}\t\t# pushing parameter {param} onto stack"));

            var template = $".globl _{Identifier}\n_{Identifier}:\n" + prologue + parameters + "\n";

            // if the function doesn't have a return statement
            if (Block.Slices.All(x => x.GetType() != typeof(Return)))
            {
                Console.WriteLine("Function doesn't have a return statement");
                Block.Slices.Add(new Return(Scope, new Constant(Scope, 0)));
            }

            Block.Slices.ForEach(s => template += s.Template());

            return template;
        }

        public override string ToString()
        {
            if (Block == null) return $"Func {ReturnType} {Identifier} ({string.Join(",", Params)})\n";
            return $"Func {ReturnType} {Identifier}:\n\t{Block}";
        }
    }
}