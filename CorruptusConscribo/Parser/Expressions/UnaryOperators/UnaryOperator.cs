using System;

namespace CorruptusConscribo.Parser
{
    public abstract class UnaryOperator : Expression
    {
        private Expression Expression { get; set; }
        private string UnaryTemplate { get; }
        private string OperatorAsString { get; }

        public UnaryOperator Add(Expression expression)
        {
            Expression = expression;
            return this;
        }

        public static UnaryOperator New(Token token)
        {
            return token.Name switch
            {
                TokenLibrary.Words.Negation => new Negation(),
                TokenLibrary.Words.BitwiseComplement => new BitwiseComplement(),
                TokenLibrary.Words.LogicalNegation => new LogicalNegation(),
                _ => throw new InvalidOperationException()
            };
        }

        public static bool IsUnary()
        {
            // TODO
            return false;
        }

        protected UnaryOperator(string operatorAsString, string unaryTemplate)
        {
            OperatorAsString = operatorAsString;
            UnaryTemplate = unaryTemplate;
        }

        public override string Template()
        {
            return $"{Expression.Template()}\n{UnaryTemplate}";
        }

        public override string ToString()
        {
            return $"{OperatorAsString}{Expression}";
        }
    }
}