using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class ForDeclare : For
    {
        public ForDeclare(Scope scope) : base(scope)
        {
        }

        public ForDeclare Parse(Stack<Token> tokens)
        {
            Initialise = new Declare(Scope).Parse(tokens);

            Condition = new OptionalSemicolon(Scope).Parse(tokens);

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
            return base.Template() + Scope.Deallocate();
        }
    }
}