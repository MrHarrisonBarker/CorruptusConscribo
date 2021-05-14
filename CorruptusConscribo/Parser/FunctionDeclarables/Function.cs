using System;
using System.Collections.Generic;
using System.Linq;

namespace CorruptusConscribo.Parser
{
    public class Function : ASTNode
    {
        public string Name { get; set; }
        public List<Declare> Params { get; set; } = new();
        private string ReturnType { get; set; }
        public Block Block { get; set; }

        public Function(Scope scope) : base(scope)
        {
        }

        // <function> ::= "int" <id> "(" [ "int" <id> { "," "int" <id> } ] ")" ( "{" { <block-item> } "}" | ";" )
        public Function Parse(Stack<Token> tokens)
        {
            var token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.Int) throw new SyntaxException("expected type int");

            ReturnType = token.Name;

            token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.Identifier) throw new SyntaxException("expected function identifier");

            Name = (string) token.Value;

            // Open close parenthesis
            token = tokens.Pop();
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

            Block = new Block(Scope).Parse(tokens);

            return this;
        }

        public override string Template()
        {
            const string prologue = "push\t%rbp\t# push stack" +
                                    "\nmovq\t%rsp,%rbp\t# move call stack\n";

            var template = $".globl _{Name}\n_{Name}:\n" + prologue;

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
            return $"Func {ReturnType} {Name}:\n\t{Block}";
        }
    }
}