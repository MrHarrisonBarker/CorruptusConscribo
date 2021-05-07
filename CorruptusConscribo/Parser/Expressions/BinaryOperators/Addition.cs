using CorruptusConscribo.Parser;

namespace CorruptusConscribo
{
    public class Addition : BinaryOperator
    {
        public Addition() : base("+", "addq\t%rcx,%rax")
        {
        }
    }
}