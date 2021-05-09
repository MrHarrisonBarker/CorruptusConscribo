namespace CorruptusConscribo.Parser.Expressions.BinaryOperators
{
    public class GreaterThanOrEqual : BinaryOperator
    {
        public GreaterThanOrEqual(Scope scope) : base(scope,">=", "cmpq\t%rax,%rcx\nmovq\t$0,%rax\nsetge\t%al")
        {
        }
    }
}