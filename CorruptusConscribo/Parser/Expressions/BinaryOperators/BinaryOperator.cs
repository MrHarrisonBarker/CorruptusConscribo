using System;
using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public abstract class BinaryOperator : Expression
    {
        protected Expression LeftExpression { get; private set; }
        protected Expression RightExpression { get; private set; }
        protected string BinaryTemplate { get; }
        private string OperatorAsString { get; }

        public BinaryOperator Add(Expression leftExpression, Expression rightExpression)
        {
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
            return this;
        }

        public static BinaryOperator New(Token token)
        {
            return token.Name switch
            {
                TokenLibrary.Words.Addition => new Addition(),
                TokenLibrary.Words.Multiplication => new Multiplication(),
                TokenLibrary.Words.Division => new Division(),
                TokenLibrary.Words.Negation => new BinaryNegation(),
                _ => throw new InvalidOperationException()
            };
        }

        protected BinaryOperator(string operatorAsString, string binaryTemplate)
        {
            OperatorAsString = operatorAsString;
            BinaryTemplate = binaryTemplate;
        }

        public override string Template()
        {
            return $"{LeftExpression.Template()}\npush\t%rax\n{RightExpression.Template()}\npop\t%rcx\n{BinaryTemplate}";
        }

        public override string ToString()
        {
            return $"({LeftExpression} {OperatorAsString} {RightExpression})";
        }
    }
}