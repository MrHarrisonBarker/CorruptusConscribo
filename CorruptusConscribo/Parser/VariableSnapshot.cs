using System;

namespace CorruptusConscribo.Parser
{
    public class VariableSnapshot
    {
        public VariableSnapshot(string type)
        {
            Type = type;
        }

        public VariableSnapshot(string type, int scopeLevel)
        {
            Type = type;
            ScopeLevel = scopeLevel;
        }

        private string Type { get; }
        public int ScopeLevel { get; set; }
        public int StackIndex { get; set; }
    }
}