namespace CorruptusConscribo.Parser.Expressions.BinaryOperators
{
    public class GreaterThan : BinaryOperator
    {
        public GreaterThan(Scope scope) : base(scope,">", "cmpq\t%rax,%rcx\nmovq\t$0,%rax\nsetg\t%al")
        {
        }
    }
}