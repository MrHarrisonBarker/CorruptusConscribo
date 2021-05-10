namespace CorruptusConscribo.Parser
{
    public class XorAssign : Assignment
    {
        public XorAssign(Scope scope) : base(scope, "^=")
        {
        }

        public override string Template()
        {
            var varIndex = Scope.VariableArchive[Variable].StackIndex;

            var retrieve = $"movq\t{varIndex}(%rbp),%rcx\n";
            const string xor = "xor\t%rax,%rcx\n";
            var assign = $"movq\t%rax,{varIndex}(%rbp)";

            return $"{Expression.Template()}\n{retrieve}{xor}{assign}";
        }
    }
}