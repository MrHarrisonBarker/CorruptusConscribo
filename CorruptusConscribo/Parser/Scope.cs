using System;
using System.Collections.Generic;
using System.Linq;

namespace CorruptusConscribo.Parser
{
    public class Scope
    {
        private int StackIndex { get; set; }
        private readonly Scope ParentScope;
        private List<Scope> ChildScopes { get; set; } = new List<Scope>();
        private readonly int ScopeLevel;
        private Dictionary<string, VariableSnapshot> VariableArchive { get; }
        private string BreakPoint { get; set; } = null;

        public Scope()
        {
            ScopeLevel = 0;
            StackIndex = 8;
            VariableArchive = new Dictionary<string, VariableSnapshot>();
        }

        public Scope(Scope scope)
        {
            ScopeLevel = scope.ScopeLevel + 1;
            StackIndex = 0;
            VariableArchive = new Dictionary<string, VariableSnapshot>();
            ParentScope = scope;
            scope.ChildScopes.Add(this);
        }

        private bool Exists(string id)
        {
            if (ParentScope == null)
            {
                return VariableArchive.ContainsKey(id);
            }

            return VariableArchive.ContainsKey(id) || ParentScope.Exists(id);
        }

        public bool LocallyExists(string id)
        {
            return VariableArchive.ContainsKey(id);
        }

        public void Add(string id, VariableSnapshot variable)
        {
            variable.StackIndex = StackIndex;
            variable.ScopeLevel = ScopeLevel;

            VariableArchive.Add(id, variable);

            StackIndex += 8;
        }

        public void AddBreakpoint()
        {
            BreakPoint = Healpers.GetBreakPointId();
        }

        public string BreakpointId()
        {
            return BreakPoint;
        }

        public string UseBreakpoint()
        {
            if (BreakPoint == null && ChildScopes.Count > 0)
            {
                foreach (var childScope in ChildScopes)
                {
                    return childScope.UseBreakpoint();
                }
            }

            var b = BreakPoint;
            BreakPoint = null;
            return b;
        }

        public int GetScopeLevel(string id)
        {
            if (LocallyExists(id)) return ScopeLevel;

            if (ParentScope == null) throw new SyntaxException($"{id} was not found!");

            return ParentScope.GetScopeLevel(id);
        }

        private int GetParentStackIndex()
        {
            return ParentScope == null ? 0 : Math.Abs((ParentScope.GetParentStackIndex() + ParentScope.StackIndex) - (VariableArchive.Count > 1 ? 8 : 0));
        }

        public int Access(Variable variable)
        {
            if (!Exists(variable.VariableId)) throw new SyntaxException($"'{variable.VariableId}' doesn't exist");

            if (ParentScope != null && variable.ScopeLevel != ScopeLevel)
            {
                return ParentScope.Access(variable);
            }

            return -Math.Abs(GetParentStackIndex() - VariableArchive[variable.VariableId].StackIndex);
        }

        public string Deallocate()
        {
            return string.Concat(Enumerable.Repeat("\npop\t\t%rax\t# deallocating var", VariableArchive.Count)) + "\n";
        }
    }
}