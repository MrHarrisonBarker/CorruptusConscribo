namespace CorruptusConscribo.Parser.Expressions.BinaryOperators
{
    public class BitwiseXor : BinaryOperator
    {
        public BitwiseXor(Scope scope) : base(scope,"^", "xor\t%rax,%rcx")
        {
        }
    }
}