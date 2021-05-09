using CorruptusConscribo.Parser;

namespace CorruptusConscribo
{
    public class BitwiseComplement : UnaryOperator
    {
        public BitwiseComplement(Scope scope) : base(scope,"~", "not\t%rax")
        {
        }
    }
}