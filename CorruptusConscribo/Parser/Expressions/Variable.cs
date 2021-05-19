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
            if (!IsGlobal) AccessIndex = Scope.Access(this);
        }

        public override string Template()
        {
            if (IsGlobal) return $"movq\t_{VariableId}(%rip), %rax\t# moving global {VariableId} onto rax\n";
            return $"movq\t{AccessIndex}(%rbp), %rax\t# moving {VariableId} onto rax, {ScopeLevel}\n";
        }

        public override string Save()
        {
            if (IsGlobal) return $"movq\t%rax, _{VariableId}(%rip)\t# saving global variable\n";
            return $"movq\t%rax,{AccessIndex}(%rbp)\t# moving rax to {VariableId}, {ScopeLevel}\n";
        }

        public override string ToString()
        {
            return $"{ReturnType} {VariableId};";
        }
    }
}