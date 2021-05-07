namespace CorruptusConscribo.Parser
{
    public class BinaryOperator : Expression
    {
        private Expression LeftExpression { get; set; }
        private Expression RightExpression { get; set; }
        private Operator Operator { get; }

        public BinaryOperator Add(Expression leftExpression, Expression rightExpression)
        {
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
            return this;
        }

        public BinaryOperator(Token op)
        {
            Operator = op.Name switch
            {
                TokenLibrary.Words.Addition => new Addition(),
                TokenLibrary.Words.Division => new Division(),
                TokenLibrary.Words.Multiplication => new Multiplication(),
                TokenLibrary.Words.Negation => new Negation(),
                _ => Operator
            };
        }

        public override string Template()
        {
            if (Operator.Name == TokenLibrary.Words.Division)
            {
                return $"{LeftExpression.Template()}\npush\t%rax\n{RightExpression.Template()}\nmovq\t%rax,%rbx\npop\t%rax\ncqo\n{Operator.Template()}";
            }

            var tmp = $"{LeftExpression.Template()}\npush\t%rax\n{RightExpression.Template()}\npop\t%rcx\n";

            tmp += Operator.BinaryTemplate();

            return tmp;
        }

        public override string ToString()
        {
            return $"({LeftExpression.ToString()} {Operator.ToString()} {RightExpression.ToString()})";
        }
    }
}