namespace CorruptusConscribo.Parser
{
    public class Variable : Expression
    {
        public string VariableId { get; }
        public int ScopeLevel { get; }
        private int AccessIndex { get; }
        private bool IsGlobal { get; }

        public Variable(Scope scope, string id) : base(scope)
        {
            IsGlobal = Scope.IsGlobal(id);
            ScopeLevel = Scope.GetScopeLevel(id);
            VariableId = id;
            AccessIndex = Scope.Access(this);
        }

        public override string Template()
        {
            if (IsGlobal) return $"movq\t_{VariableId}(%rip), %rax\t\t# moving global {VariableId} onto rax";
            return $"movq\t{AccessIndex}(%rbp), %rax\t# moving {VariableId} onto rax, {ScopeLevel}";
        }

        public override string Save()
        {
            if (IsGlobal) return "global save";
            return $"movq\t%rax,{AccessIndex}(%rbp)\t# moving rax to {VariableId}, {ScopeLevel}";
        }

        public override string ToString()
        {
            return $"{ReturnType} {VariableId};";
        }
    }
}