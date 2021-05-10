namespace CorruptusConscribo.Parser
{
    public class MultiplicationAssign : Assignment
    {
        public MultiplicationAssign(Scope scope) : base(scope, "*=")
        {
        }
        
        public override string Template()
        {
            var varIndex = Scope.VariableArchive[Variable].StackIndex;

            var retrieve = $"movq\t{varIndex}(%rbp),%rcx\n";
            const string multi = "imulq\t%rcx,%rax\n";
            var assign = $"movq\t%rax,{varIndex}(%rbp)";

            return $"{Expression.Template()}\n{retrieve}{multi}{assign}";
        }
    }
}