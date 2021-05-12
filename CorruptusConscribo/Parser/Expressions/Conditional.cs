using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Conditional : Expression
    {
        private Expression Expression { get; set; }
        private Expression TrueResult { get; set; }
        private Expression FalseResult { get; set; }

        public Conditional(Scope scope) : base(scope)
        {
        }

        // <conditional-exp> ::= <logical-or-exp> [ "?" <exp> ":" <conditional-exp> ]
        public Expression Parse(Stack<Token> tokens)
        {
            Expression = new LogicalOrExpression(Scope).Parse(tokens);

            var token = tokens.Peek();

            if (token.Name == TokenLibrary.Words.Question)
            {
                tokens.Pop();

                TrueResult = new Expression(Scope).Parse(tokens);

                token = tokens.Pop();

                if (token.Name != TokenLibrary.Words.Colon) throw new SyntaxException("expected :");

                FalseResult = new Conditional(Scope).Parse(tokens);

                return this;
            }

            return Expression;
        }

        public override string Template()
        {
            var endFunc = Healpers.GetFunctionId();
            var falseFunc = Healpers.GetFunctionId();
            var compare = $"cmpq\t$0, %rax\nje\t{falseFunc}";
            return $"{Expression.Template()}\n{compare}\n{TrueResult.Template()}\njmp\t{endFunc}\n{falseFunc}:\n{FalseResult.Template()}\n{endFunc}:";
        }

        public override string ToString()
        {
            if (TrueResult != null) return $"{Expression} ? {TrueResult} : {FalseResult}";
            return $"{Expression}";
        }
    }
}