using CorruptusConscribo.Parser;

namespace CorruptusConscribo
{
    public class Negation : UnaryOperator
    {
        public Negation() : base("-", "neg\t%rax")
        {
        }
    }
}