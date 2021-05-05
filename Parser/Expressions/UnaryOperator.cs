namespace CorruptusConscribo.Parser
{
    public class UnaryOperator : Expression
    {
        private Expression Expression { get; }
        private Operator Operator { get; }

        // TODO: check input token type is operator
        // Token == operator , Expression == operand
        public UnaryOperator(Token op, Expression expression)
        {
            Expression = expression;

            Operator = op.Name switch
            {
                TokenLibrary.Words.Negation => new Negation(),
                TokenLibrary.Words.BitwiseComplement => new BitwiseComplement(),
                TokenLibrary.Words.LogicalNegation => new LogicalNegation(),
                _ => Operator
            };
        }

        public override string Template()
        {
            return $"{Expression.Template()}\n{Operator.Template()}";
        }
    }
}