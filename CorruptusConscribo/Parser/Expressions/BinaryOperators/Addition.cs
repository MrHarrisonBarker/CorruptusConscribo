using CorruptusConscribo.Parser;

namespace CorruptusConscribo
{
    public class Addition : BinaryOperator
    {
        public Addition(Scope scope) : base(scope, "+", "addq\t%rcx,%rax\t# adding\n")
        {
        }
    }
}