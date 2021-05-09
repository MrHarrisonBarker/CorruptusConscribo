namespace CorruptusConscribo.Parser
{
    public class Variable : Expression
    {
        private string VariableId { get; }

        public Variable(Scope scope,string id) : base(scope)
        {
            VariableId = id;
        }

        public override string Template()
        {
            var varIndex = Scope.VariableArchive[VariableId].StackIndex;
            return $"\nmovq\t{varIndex}(%rbp), %rax";
            return "\nVariable call\n";
        }

        public override string ToString()
        {
            return $"{VariableId}";
        }
    }
}