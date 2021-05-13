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
            Option1 = new Declare(Scope).Parse(tokens);

            Option2 = new OptionalSemicolon(Scope).Parse(tokens);

            Option3 = new OptionalCloseParam(Scope).Parse(tokens);

            Statement = new Statement(Scope).Parse(tokens);

            return this;
        }

        public override string ToString()
        {
            return $"for ({Option1};{Option2};{Option3}) {{\n\t{Statement}\n\t}}";
        }
    }
}