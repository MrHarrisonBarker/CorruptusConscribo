namespace CorruptusConscribo.Parser.Expressions.BinaryOperators
{
    public class BitwiseOr : BinaryOperator
    {
        public BitwiseOr(Scope scope) : base(scope,"|", "or\t%rax,%rcx")
        {
        }
    }
}