namespace CorruptusConscribo.Parser
{
    public class AdditionAssign : Assignment
    {
        public AdditionAssign(Scope scope) : base(scope, "+=","addq\t%rcx,%rax")
        {
        }

        public override string Template()
        {
            return $"{LeftExpression.Template()}\nmovq\t%rax,%rcx\n{RightExpression.Template()}\n{AssignmentTemplate}\n{LeftExpression.Save()}";
        }
    }
}