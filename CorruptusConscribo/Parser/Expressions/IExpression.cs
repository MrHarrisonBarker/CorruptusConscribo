using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public interface IExpression
    {
        public Expression Parse(Stack<Token> tokens);
    }
}