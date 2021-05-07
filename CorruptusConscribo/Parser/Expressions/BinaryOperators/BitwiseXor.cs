namespace CorruptusConscribo.Parser.Expressions.BinaryOperators
{
    public class BitwiseXor : BinaryOperator
    {
        public BitwiseXor() : base("^", "xor\t%rax,%rcx")
        {
        }
    }
}