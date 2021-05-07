namespace CorruptusConscribo.Parser
{
    public class Constant : Expression
    {
        private int Value { get; }

        public Constant(int value)
        {
            Value = value;
        }

        public override string Template()
        {
            return $"movq    ${Value.ToString()}, %rax";
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}