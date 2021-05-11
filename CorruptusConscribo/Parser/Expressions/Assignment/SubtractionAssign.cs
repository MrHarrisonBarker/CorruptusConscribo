namespace CorruptusConscribo.Parser
{
    public class SubtractionAssign : Assignment
    {
        public SubtractionAssign(Scope scope) : base(scope, "-=","subq\t%rax,%rcx")
        {
        }

        public override string Template()
        {
            return $"{LeftExpression.Template()}\nmovq\t%rax,%rcx\n{RightExpression.Template()}\n{AssignmentTemplate}\n{LeftExpression.Save()}";
        }
    }
}