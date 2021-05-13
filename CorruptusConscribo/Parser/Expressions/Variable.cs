namespace CorruptusConscribo.Parser
{
    public class Variable : Expression
    {
        public string VariableId { get; }
        public int ScopeLevel { get; }

        public Variable(Scope scope, string id) : base(scope)
        {
            ScopeLevel = Scope.GetScopeLevel(id);
            VariableId = id;
        }

        public override string Template()
        {
            return $"\nmovq\t{Scope.Access(this)}(%rbp), %rax";
        }

        public override string Save()
        {
            return $"\nmovq\t%rax,{Scope.Access(this)}(%rbp)";
        }

        public override string ToString()
        {
            return $"{VariableId}";
        }
    }
}