namespace CorruptusConscribo.Parser
{
    public class Constant : Expression
    {
        public int Value { get; }

        public Constant(Scope scope, int value) : base(scope)
        {
            Value = value;
        }

        public override string Template()
        {
            return $"movq\t${Value.ToString()}, %rax";
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}