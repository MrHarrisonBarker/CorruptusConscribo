namespace CorruptusConscribo.Parser
{
    public class AndAssign : Assignment
    {
        public AndAssign(Scope scope) : base(scope, "&=","and\t%rax,%rcx")
        {
        }

        public override string Template()
        {
            return $"{LeftExpression.Template()}\nmovq\t%rax,%rcx\n{RightExpression.Template()}\n{AssignmentTemplate}\n{LeftExpression.Save()}";
        }
    }
}