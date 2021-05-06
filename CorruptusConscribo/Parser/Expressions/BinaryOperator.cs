namespace CorruptusConscribo.Parser
{
    public class BinaryOperator : Expression
    {
        private Expression LeftExpression { get; set; }
        private Expression RightExpression { get; set; }
        private Operator Operator { get; }

        public BinaryOperator Add( Expression leftExpression, Expression rightExpression)
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

        public override string ToString()
        {
            return $"({LeftExpression.ToString()} {Operator.ToString()} {RightExpression.ToString()})";
        }
    }
}