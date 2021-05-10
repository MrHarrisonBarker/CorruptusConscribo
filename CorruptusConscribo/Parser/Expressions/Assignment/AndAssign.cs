namespace CorruptusConscribo.Parser
{
    public class AndAssign : Assignment
    {
        public AndAssign(Scope scope) : base(scope, "&=")
        {
        }

        public override string Template()
        {
            var varIndex = Scope.VariableArchive[Variable].StackIndex;

            var retrieve = $"movq\t{varIndex}(%rbp),%rcx\n";
            const string and = "and\t%rax,%rcx\n";
            var assign = $"movq\t%rax,{varIndex}(%rbp)";

            return $"{Expression.Template()}\n{retrieve}{and}{assign}";
        }
    }
}