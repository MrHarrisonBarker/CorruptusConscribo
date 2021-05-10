namespace CorruptusConscribo.Parser
{
    public class ModuloAssign : Assignment
    {
        public ModuloAssign(Scope scope) : base(scope, "%=")
        {
        }

        public override string Template()
        {
            var varIndex = Scope.VariableArchive[Variable].StackIndex;
            
            var retrieve = $"\nmovq\t{varIndex}(%rbp),%rax";
            const string div = "\nidiv\t%rbx";
            var assign = $"\nmovq\t%rax,{varIndex}(%rbp)";

            return $"{Expression.Template()}" +
                   "\nmovq\t%rax,%rbx" +
                   retrieve +
                   "\ncqo" +
                   div +
                   "\nmovq\t$0,%rax" +
                   "\nmovq\t%rdx,%rax" +
                   assign;
        }
    }
}