namespace CorruptusConscribo.Parser.Expressions.BinaryOperators
{
    public class LessThanOrEqual : BinaryOperator
    {
        public LessThanOrEqual(Scope scope) : base(scope,"<=", "cmpq\t%rax,%rcx\nmovq\t$0,%rax\nsetle\t%al")
        {
        }
        
        public override string ControlTemplate()
        {
            BinaryTemplate = "cmpq\t%rax,%rcx\njg";
            return base.Template();
        }
    }
}