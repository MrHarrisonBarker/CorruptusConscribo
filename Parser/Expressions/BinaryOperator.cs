namespace CorruptusConscribo.Parser
{
    public class BinaryOperator : Expression
    {
        private Expression LeftExpression { get; set; }
        private Expression RightExpression { get; set; }
        private Operator Operator { get; }
        
        private BinaryOperator BinOp { get; }

        protected BinaryOperator()
        {
        }

        public BinaryOperator(BinaryOperator op, Expression leftExpression, Expression rightExpression)
        {
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
            BinOp = op;
            
            // Operator = op.Name switch
            // {
            //     TokenLibrary.Words.Addition => new Addition(),
            //     TokenLibrary.Words.Division => new Division(),
            //     TokenLibrary.Words.Multiplication => new Multiplication(),
            //     TokenLibrary.Words.Negation => new Negation(),
            //     _ => Operator
            // };
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
    }
}