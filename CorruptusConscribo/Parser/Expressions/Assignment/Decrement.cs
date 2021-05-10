namespace CorruptusConscribo.Parser
{
    public class Decrement : Assignment
    {
        public Decrement(Scope scope) : base(scope, "--")
        {
        }

        public override string Template()
        {
            var varIndex = Scope.VariableArchive[Variable].StackIndex;
            
            var retrieve = $"movq\t{varIndex}(%rbp),%rax\n";
            const string decrement = "subq\t$1,%rax\n";
            var assign = $"movq\t%rax,{varIndex}(%rbp)";

            return $"\n{retrieve}{decrement}{assign}";
        }
    }
}