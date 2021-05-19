using System;

namespace CorruptusConscribo.Parser
{
    public class VariableSnapshot
    {
        public VariableSnapshot(string type)
        {
            Type = type;
        }

        public VariableSnapshot(bool isGlobal, string type, bool defined)
        {
            Type = type;
            IsGlobal = isGlobal;
            Defined = defined;
        }

        public VariableSnapshot(string type, bool isParam)
        {
            Type = type;
            IsParam = isParam;
        }

        public VariableSnapshot(string type, int scopeLevel, bool isParam)
        {
            Type = type;
            ScopeLevel = scopeLevel;
            IsParam = isParam;
        }

        private string Type { get; }
        public int ScopeLevel { get; set; }
        public int StackIndex { get; set; }
        public bool IsParam { get; set; }
        public bool IsGlobal { get; set; }
        public bool Defined { get; set; }
    }
}