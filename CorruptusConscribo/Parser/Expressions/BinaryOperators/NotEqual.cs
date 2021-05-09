namespace CorruptusConscribo.Parser.Expressions.BinaryOperators
{
    public class NotEqual : BinaryOperator
    {
        public NotEqual(Scope scope) : base(scope,"!=", "cmpq\t%rax,%rcx\nmovq\t$0,%rax\nsetne\t%al")
        {
        }
    }
}