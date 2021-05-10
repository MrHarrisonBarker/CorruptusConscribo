namespace CorruptusConscribo.Parser
{
    public class SubtractionAssign : Assignment
    {
        public SubtractionAssign(Scope scope) : base(scope, "-=")
        {
        }
        
        public override string Template()
        {
            var varIndex = Scope.VariableArchive[Variable].StackIndex;

            var retrieve = $"movq\t{varIndex}(%rbp),%rcx\n";
            const string sub = "subq\t%rax,%rcx\n";
            var assign = $"movq\t%rcx,{varIndex}(%rbp)";

            return $"{Expression.Template()}\n{retrieve}{sub}{assign}";
        }
    }
}