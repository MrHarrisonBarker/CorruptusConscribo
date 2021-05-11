namespace CorruptusConscribo.Parser
{
    public class Increment : Assignment
    {
        public Increment(Scope scope) : base(scope, "++","addq\t$1,%rax")
        {
        }

        public override string Template()
        {
            return $"{LeftExpression.Template()}\n{AssignmentTemplate}\n{LeftExpression.Save()}";
        }
    }
}