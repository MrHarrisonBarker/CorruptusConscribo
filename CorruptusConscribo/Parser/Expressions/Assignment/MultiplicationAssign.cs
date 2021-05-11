namespace CorruptusConscribo.Parser
{
    public class MultiplicationAssign : Assignment
    {
        public MultiplicationAssign(Scope scope) : base(scope, "*=","imulq\t%rcx,%rax")
        {
        }
        
        public override string Template()
        {
            return $"{LeftExpression.Template()}\nmovq\t%rax,%rcx\n{RightExpression.Template()}\n{AssignmentTemplate}\n{LeftExpression.Save()}";
        }
    }
}