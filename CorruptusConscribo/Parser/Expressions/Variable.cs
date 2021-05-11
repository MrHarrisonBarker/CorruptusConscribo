namespace CorruptusConscribo.Parser
{
    public class Variable : Expression
    {
        public string VariableId { get; }

        public Variable(Scope scope,string id) : base(scope)
        {
            VariableId = id;
        }

        public override string Template()
        {
            var varIndex = Scope.VariableArchive[VariableId].StackIndex;
            return $"\nmovq\t{varIndex}(%rbp), %rax";
        }

        public override string Save()
        {
            var varIndex = Scope.VariableArchive[VariableId].StackIndex;
            return $"\nmovq\t%rax,{varIndex}(%rbp)";
        }

        public override string ToString()
        {
            return $"{VariableId}";
        }
    }
}