using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Scope
    {
        private readonly Scope ParentScope = null;
        private int StackIndex = 0;
        public Dictionary<string, VariableSnapshot> VariableArchive { get; }

        public Scope()
        {
            VariableArchive = new Dictionary<string, VariableSnapshot>();
        }

        public Scope(Scope scope)
        {
            VariableArchive = new Dictionary<string, VariableSnapshot>();
            ParentScope = scope;
        }

        public bool Exists(string id)
        {
            if (ParentScope == null)
            {
                return VariableArchive.ContainsKey(id);
            }

            return VariableArchive.ContainsKey(id) || ParentScope.Exists(id);
        }

        public void Add(string id, VariableSnapshot variable)
        {
            StackIndex -= 4;
            variable.StackIndex = StackIndex;
            VariableArchive.Add(id, variable);
        }
    }
}