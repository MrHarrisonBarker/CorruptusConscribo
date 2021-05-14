using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class For : Statement
    {
        protected Slice Initialise { get; set; }
        protected Expression Condition { get; set; }
        protected Expression PostExpression { get; set; }

        protected Block Statement { get; set; }

        public For(Scope scope) : base(scope)
        {
        }

        // "for" "(" <exp-option> ";" <exp-option> ";" <exp-option> ")" <statement>
        public For Parse(Stack<Token> tokens)
        {
            tokens.Pop();
            var token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.OpenParenthesis) throw new SyntaxException("expected (");

            var nextToken = tokens.Peek();

            // if the next token is a variable type
            if (nextToken.Name == TokenLibrary.Words.Int) return new ForDeclare(Scope).Parse(tokens);


            Initialise = new OptionalSemicolon(Scope).Parse(tokens);

            Condition = new OptionalSemicolon(Scope).Parse(tokens);

            // ensuring non zero expression
            if (Condition.GetType() == typeof(OptionalSemicolon)) Condition = new Constant(Scope, 1);

            PostExpression = new OptionalCloseParam(Scope).Parse(tokens);

            Statement = new Statement(Scope).Parse(tokens);

            return this;
        }

        public override string ToString()
        {
            return $"for ({Initialise};{Condition};{PostExpression}) {{\n\t{Statement}\n\t}}";
        }

        public override string Template()
        {
            var conditionFunc = Healpers.GetFunctionId();
            var endFunc = Healpers.GetFunctionId();
            return $"{Initialise.Template()}\n{conditionFunc}:\n{Condition.Template()}\ncmpq\t$0,%rax\nje\t{endFunc}\n{Statement.Template()}\n{PostExpression.Template()}\njmp\t{conditionFunc}\n{endFunc}:";
        }
    }
}