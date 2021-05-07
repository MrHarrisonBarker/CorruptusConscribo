using CorruptusConscribo.Parser;

namespace CorruptusConscribo
{
    public class BinaryNegation : BinaryOperator
    {
        public BinaryNegation() : base("-", "subq\t%rcx,%rax")
        {
        }
    }
}