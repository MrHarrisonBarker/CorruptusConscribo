using CorruptusConscribo.Parser;

namespace CorruptusConscribo
{
    public class Multiplication : BinaryOperator
    {
        public Multiplication() : base("*", "imul\t%rcx,%rax")
        {
        }
    }
}