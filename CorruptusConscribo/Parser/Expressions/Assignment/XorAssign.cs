namespace CorruptusConscribo.Parser
{
    public class XorAssign : Assignment
    {
        public XorAssign(Scope scope) : base(scope, "^=","xor\t%rax,%rcx")
        {
        }

        public override string Template()
        {
            return $"{LeftExpression.Template()}\nmovq\t%rax,%rcx\n{RightExpression.Template()}\n{AssignmentTemplate}\n{LeftExpression.Save()}";
        }
    }
}