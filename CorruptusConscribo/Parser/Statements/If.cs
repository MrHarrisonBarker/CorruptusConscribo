using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class If : Statement
    {
        private Expression Expression { get; set; }
        private Statement Statement { get; set; }
        private Statement Else { get; set; }

        public If(Scope scope) : base(scope)
        {
        }

        // "if" "(" <exp> ")" <statement> [ "else" <statement> ]
        public If Parse(Stack<Token> tokens)
        {
            var token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.OpenParenthesis) throw new SyntaxException("expected (");

            Expression = new Expression(Scope).Parse(tokens);

            token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.CloseParenthesis) throw new SyntaxException("expected )");

            // TODO: should be list of block items
            Statement = new Statement(Scope).Parse(tokens);

            token = tokens.Peek();

            if (token.Name == TokenLibrary.Words.Else)
            {
                tokens.Pop();

                Else = new Statement(Scope).Parse(tokens);
            }

            return this;
        }

        public override string Template()
        {
            var endFunc = Healpers.GetFunctionId();

            string compare;
            
            if (Else != null)
            {
                var elseFunc = Healpers.GetFunctionId();
                compare = $"cmpq\t$0, %rax\nje\t{elseFunc}";
                return $"{Expression.Template()}\n{compare}\n{Statement.Template()}\njmp\t{endFunc}\n{elseFunc}:\n{Else.Template()}\njmp\t{endFunc}\n{endFunc}:";
            }
            
            compare = $"cmpq\t$0, %rax\nje\t{endFunc}";
            return $"{Expression.Template()}\n{compare}\n{Statement.Template()}\n{endFunc}:";
        }

        public override string ToString()
        {
            if (Else != null) return $"if ({Expression})\n\t{Statement}\n\telse\n\t{Else}";
            return $"if ({Expression})\n\t{Statement}";
        }
    }
}