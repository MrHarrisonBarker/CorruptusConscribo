namespace CorruptusConscribo.Parser.Expressions.BinaryOperators
{
    public class Or : BinaryOperator
    {
        public Or(Scope scope) : base(scope,"||", "")
        {
        }

        public override string Template()
        {
            var branchName = Healpers.GetFunctionId();
            var endName = Healpers.GetFunctionId();

            var main =
                $"{LeftExpression.Template()}" +
                "\ncmpq\t$0,%rax" +
                $"\nje\t{branchName}\t# OR ({LeftExpression} || {RightExpression})" +
                "\nmovq\t$1,%rax" +
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