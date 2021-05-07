namespace CorruptusConscribo.Parser.Expressions.BinaryOperators
{
    public class Modulo : BinaryOperator
    {
        public Modulo() : base("%")
        {
        }
        
        public override string Template()
        {
            var data =
                $"{LeftExpression.Template()}" +
                "\npush\t%rax" +
                $"\n{RightExpression.Template()}" +
                "\nmovq\t%rax,%rbx" +
                "\npop\t%rax" +
                "\ncqo";
            return
                data +
                "\nidivq\t%rbx" +
                "\nmovq\t$0,%rax" +
                "\nmovq\t%rdx,%rax";
        }
    }
}