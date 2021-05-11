namespace CorruptusConscribo.Parser
{
    public class Decrement : Assignment
    {
        public Decrement(Scope scope) : base(scope, "--", "subq\t$1,%rax")
        {
        }

        public override string Template()
        {
            return $"{LeftExpression.Template()}\n{AssignmentTemplate}\n{LeftExpression.Save()}";
        }
    }
}