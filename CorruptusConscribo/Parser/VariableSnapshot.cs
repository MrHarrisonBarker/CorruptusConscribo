using System;

namespace CorruptusConscribo.Parser
{
    public class VariableSnapshot
    {
        public VariableSnapshot(string type)
        {
            Type = type;
        }

        public VariableSnapshot(string type, IConvertible value)
        {
            Type = type;
            Value = value;
        }

        private string Type { get; }
        public IConvertible Value { get; set; }
        public int StackIndex { get; set; }
    }
}