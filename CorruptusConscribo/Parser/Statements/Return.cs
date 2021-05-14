using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Return : Statement
    {
        private Expression Expression { get; set; }

        public Return(Scope scope) : base(scope)
        {
        }

        public Return(Scope scope, Expression expression) : base(scope)
        {
            Expression = expression;
        }

        public Return Parse(Stack<Token> tokens)
        {
            tokens.Pop();

            Expression = new Expression(Scope).Parse(tokens);

            var token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.Semicolon) throw new SyntaxException("expected ;");

            return this;
        }

        public override string Template()
        {
            const string epilogue = "movq\t%rbp,%rsp\t# clear stack" +
                                    "\npop\t%rbp\t# pop previous stack";

            return $"{Expression.Template()}\n\n{epilogue}\nret";
        }

        public override string ToString()
        {
            return $"Return {Expression};";
        }
    }
}