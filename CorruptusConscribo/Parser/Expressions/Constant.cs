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
            return $"movl    ${Value.ToString()}, %eax";
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}