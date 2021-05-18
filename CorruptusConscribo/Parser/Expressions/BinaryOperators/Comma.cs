namespace CorruptusConscribo.Parser.Expressions.BinaryOperators
{
    public class Comma : BinaryOperator
    {
        public Comma(Scope scope) : base(scope, ",")
        {
        }

        public override string Template()
        {
            return $"{RightExpression.Template()}";
        }
        
        public override int AbsoluteValue()
        {
            return RightExpression.AbsoluteValue();
        }
    }
}