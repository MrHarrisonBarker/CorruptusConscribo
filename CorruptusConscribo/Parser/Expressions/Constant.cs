namespace CorruptusConscribo.Parser
{
    public class Constant : Expression
    {
        private int Value { get; }

        public Constant(Scope scope, int value) : base(scope)
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