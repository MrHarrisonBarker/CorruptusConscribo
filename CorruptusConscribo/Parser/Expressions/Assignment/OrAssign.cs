namespace CorruptusConscribo.Parser
{
    public class OrAssign : Assignment
    {
        public OrAssign(Scope scope) : base(scope, "|=")
        {
        }

        public override string Template()
        {
            return null;
            // var varIndex = Scope.VariableArchive[Variable].StackIndex;
            //
            // var retrieve = $"movq\t{varIndex}(%rbp),%rcx\n";
            // const string or = "or\t%rax,%rcx\n";
            // var assign = $"movq\t%rax,{varIndex}(%rbp)";
            //
            // return $"{Expression.Template()}\n{retrieve}{or}{assign}";
        }
    }
}