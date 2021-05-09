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

        public static UnaryOperator New(Scope scope, Token token)
        {
            return token.Name switch
            {
                TokenLibrary.Words.Negation => new Negation(scope),
                TokenLibrary.Words.BitwiseComplement => new BitwiseComplement(scope),
                TokenLibrary.Words.LogicalNegation => new LogicalNegation(scope),
                _ => throw new InvalidOperationException()
            };
        }

        public static bool IsUnary()
        {
            // TODO
            return false;
        }

        protected UnaryOperator(Scope scope,string operatorAsString, string unaryTemplate) : base(scope)
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