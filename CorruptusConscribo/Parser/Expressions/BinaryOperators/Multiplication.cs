using CorruptusConscribo.Parser;

namespace CorruptusConscribo
{
    public class Multiplication : BinaryOperator
    {
        public Multiplication(Scope scope) : base(scope,"*", "imulq\t%rcx,%rax")
        {
        }
        
        public override int AbsoluteValue()
        {
            return LeftExpression.AbsoluteValue() * RightExpression.AbsoluteValue();
        }
    }
}