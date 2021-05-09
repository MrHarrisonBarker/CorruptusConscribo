using CorruptusConscribo.Parser;

namespace CorruptusConscribo
{
    public class BinaryNegation : BinaryOperator
    {
        public BinaryNegation(Scope scope) : base(scope,"-", "subq\t%rcx,%rax")
        {
        }
        
        public override string Template()
        {
            return $"{RightExpression.Template()}\npush\t%rax\n{LeftExpression.Template()}\npop\t%rcx\n{BinaryTemplate}";
        }
    }
}