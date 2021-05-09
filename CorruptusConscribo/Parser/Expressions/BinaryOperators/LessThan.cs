namespace CorruptusConscribo.Parser.Expressions.BinaryOperators
{
    public class LessThan : BinaryOperator
    {
        public LessThan(Scope scope) : base(scope,"<", "cmpq\t%rax,%rcx\nmovq\t$0,%rax\nsetl\t%al")
        {
        }
    }
}