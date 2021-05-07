namespace CorruptusConscribo.Parser.Expressions.BinaryOperators
{
    public class NotEqual : BinaryOperator
    {
        public NotEqual() : base("!=", "cmpq\t%rax,%rcx\nmovq\t$0,%rax\nsetne\t%al")
        {
        }
    }
}