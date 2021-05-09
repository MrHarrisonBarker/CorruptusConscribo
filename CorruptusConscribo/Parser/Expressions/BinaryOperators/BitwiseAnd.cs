namespace CorruptusConscribo.Parser.Expressions.BinaryOperators
{
    public class BitwiseAnd : BinaryOperator
    {
        public BitwiseAnd(Scope scope) : base(scope,"&","and\t%rax,%rcx")
        {
        }
    }
}