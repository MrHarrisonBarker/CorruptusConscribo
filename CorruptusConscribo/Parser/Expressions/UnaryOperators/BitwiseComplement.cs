using CorruptusConscribo.Parser;

namespace CorruptusConscribo
{
    public class BitwiseComplement : UnaryOperator
    {
        public BitwiseComplement() : base("~", "not\t%rax")
        {
        }
    }
}