using System;
using System.Collections.Generic;
using System.Linq;

namespace CorruptusConscribo.Parser
{
    public class VirtualRegisters
    {
        public int StackIndex { get; set; } = -8;
    }

    public class Scope
    {
        private VirtualRegisters VirtualRegisters { get; }
        private int StackIndex { get; set; }
        private readonly Scope ParentScope;
        private readonly int ScopeLevel;
        private Dictionary<string, VariableSnapshot> VariableArchive { get; }

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
            VirtualRegisters = scope.VirtualRegisters;
            VariableArchive = new Dictionary<string, VariableSnapshot>();
            ParentScope = scope;
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

        public int GetScopeLevel(string id)
        {
            if (LocallyExists(id)) return ScopeLevel;

            if (ParentScope == null) throw new SyntaxException($"{id} was not found!");

            return ParentScope.GetScopeLevel(id);
        }

        private int GetParentStackIndex()
        {
            return ParentScope == null ? 0 : Math.Abs(ParentScope.GetParentStackIndex() + ParentScope.StackIndex);
        }

        public int Access(Variable variable)
        {
            if (!Exists(variable.VariableId)) throw new SyntaxException($"'{variable.VariableId}' doesn't exist");

            if (ParentScope != null && variable.ScopeLevel != ScopeLevel)
            {
                return ParentScope.Access(variable);
            }
            
            if (ParentScope == null)
            {
                return -VariableArchive[variable.VariableId].StackIndex;
            }
            
            return ScopeLevel > 1
                ? -Math.Abs(GetParentStackIndex() - VariableArchive[variable.VariableId].StackIndex - 8)
                : -Math.Abs(GetParentStackIndex() - VariableArchive[variable.VariableId].StackIndex);
        }

        public string Deallocate()
        {
            return string.Concat(Enumerable.Repeat("\npop\t\t%rax", VariableArchive.Count));
        }
    }
}