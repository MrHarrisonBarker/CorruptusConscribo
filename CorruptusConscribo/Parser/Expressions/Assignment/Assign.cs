namespace CorruptusConscribo.Parser
{
    public class Assign : Assignment
    {
        public Assign(Scope scope) : base(scope, "=", "")
        {
        }

        public override string Template()
        {
            var varIndex = Scope.VariableArchive[Variable].StackIndex;
            return $"{Expression.Template()}\nmovq\t%rax,{varIndex}(%rbp)";
        }
    }
}