using CorruptusConscribo.Parser;

namespace CorruptusConscribo
{
    public class Negation : UnaryOperator
    {
        public Negation(Scope scope) : base(scope,"-", "neg\t%rax")
        {
        }
    }
}