using System;
using System.Collections.Generic;
using CorruptusConscribo.Parser.Expressions.BinaryOperators;

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
                TokenLibrary.Words.AND => new And(),
                TokenLibrary.Words.OR => new Or(),
                TokenLibrary.Words.Equal => new Equal(),
                TokenLibrary.Words.NotEqual => new NotEqual(),
                TokenLibrary.Words.LessThan => new LessThan(),
                TokenLibrary.Words.LessThanOrEqual => new LessThanOrEqual(),
                TokenLibrary.Words.GreaterThan => new GreaterThan(),
                TokenLibrary.Words.GreaterThanOrEqual => new GreaterThanOrEqual(),
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