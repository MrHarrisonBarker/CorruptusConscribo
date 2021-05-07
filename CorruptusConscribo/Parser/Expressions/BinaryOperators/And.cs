namespace CorruptusConscribo.Parser.Expressions.BinaryOperators
{
    public class And : BinaryOperator
    {
        public And() : base("&&", "NOT IMPLEMENTED")
        {
        }

        public override string Template()
        {
            var branchName = Healpers.GetFunctionId();
            var endName = Healpers.GetFunctionId();

            var main =
                $"{LeftExpression.Template()}" +
                "\ncmpq\t$0,%rax" +
                $"\njnz\t{branchName}" +
                "\nmovq\t$0,%rax" +
                $"\njmp\t{endName}";

            var branch = 
                $"\n{branchName}:" +
                $"\n{RightExpression.Template()}" +
                "\ncmpq\t$0,%rax" +
                "\nmovq\t$0,%rax" +
                "\nsetne\t%al";

            var end = $"\n{endName}:";

            return main + branch + end;
        }
    }
}