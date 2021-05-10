namespace CorruptusConscribo.Parser
{
    public class AdditionAssign : Assignment
    {
        public AdditionAssign(Scope scope) : base(scope, "+=")
        {
        }

        public override string Template()
        {
            var varIndex = Scope.VariableArchive[Variable].StackIndex;

            var retrieve = $"movq\t{varIndex}(%rbp),%rcx\n";
            const string add = "addq\t%rcx,%rax\n";
            var assign = $"movq\t%rax,{varIndex}(%rbp)";

            return $"{Expression.Template()}\n{retrieve}{add}{assign}";
        }
    }
}