namespace CorruptusConscribo.Parser
{
    public class OrAssign : Assignment
    {
        public OrAssign(Scope scope) : base(scope, "|=","or\t%rax,%rcx")
        {
        }

        public override string Template()
        {
            return $"{LeftExpression.Template()}\nmovq\t%rax,%rcx\n{RightExpression.Template()}\n{AssignmentTemplate}\n{LeftExpression.Save()}";

        }
    }
}