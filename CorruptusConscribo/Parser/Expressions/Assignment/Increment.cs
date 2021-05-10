namespace CorruptusConscribo.Parser
{
    public class Increment : Assignment
    {
        public Increment(Scope scope) : base(scope, "++")
        {
        }

        public override string Template()
        {
            var varIndex = Scope.VariableArchive[Variable].StackIndex;
            
            var retrieve = $"movq\t{varIndex}(%rbp),%rax\n";
            const string increment = "addq\t$1,%rax\n";
            var assign = $"movq\t%rax,{varIndex}(%rbp)";

            return $"\n{retrieve}{increment}{assign}";
        }
    }
}