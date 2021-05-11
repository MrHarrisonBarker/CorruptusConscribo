namespace CorruptusConscribo.Parser
{
    public class ModuloAssign : Assignment
    {
        public ModuloAssign(Scope scope) : base(scope, "%=","cqo\nidiv\t%rbx")
        {
        }

        public override string Template()
        {
            return $"{RightExpression.Template()}\nmovq\t%rax,%rbx\n{LeftExpression.Template()}\n{AssignmentTemplate}\nmovq\t$0,%rax\nmovq\t%rdx,%rax\n{LeftExpression.Save()}";
        }
    }
}