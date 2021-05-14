namespace CorruptusConscribo.Parser
{
    public class Variable : Expression
    {
        public string VariableId { get; }
        public int ScopeLevel { get; }
        private int AccessIndex { get; }

        public Variable(Scope scope, string id) : base(scope)
        {
            ScopeLevel = Scope.GetScopeLevel(id);
            VariableId = id;
            AccessIndex = Scope.Access(this);
        }

        public override string Template()
        {
            return $"movq\t{AccessIndex}(%rbp), %rax\t# moving {VariableId} onto rax, {ScopeLevel}";
        }

        public override string Save()
        {
            return $"movq\t%rax,{AccessIndex}(%rbp)\t# moving rax to {VariableId}, {ScopeLevel}";
        }

        public override string ToString()
        {
            return $"{VariableId}";
        }
    }
}