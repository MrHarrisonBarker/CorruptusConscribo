using CorruptusConscribo.Parser;

namespace CorruptusConscribo
{
    public class Division : BinaryOperator
    {
        public Division(Scope scope) : base(scope,"/", "idivq\t%rbx")
        {
        }

        public override string Template()
        {
            return $"{LeftExpression.Template()}\npush\t%rax\n{RightExpression.Template()}\nmovq\t%rax,%rbx\npop\t%rax\ncqo\n{BinaryTemplate}";
        }
    }
}