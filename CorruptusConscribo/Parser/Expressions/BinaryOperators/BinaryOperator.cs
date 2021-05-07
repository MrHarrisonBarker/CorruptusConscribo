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

        // TODO: add operator to token instead of this switch statement
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
                TokenLibrary.Words.Modulo => new Modulo(),
                TokenLibrary.Words.BitwiseAnd => new BitwiseAnd(),
                TokenLibrary.Words.BitwiseOr => new BitwiseOr(),
                TokenLibrary.Words.BitwiseXor => new BitwiseXor(),
                TokenLibrary.Words.BitwiseLeft => new BitwiseLeft(),
                TokenLibrary.Words.BitwiseRight => new BitwiseRight(),
                _ => throw new InvalidOperationException()
            };
        }

        protected BinaryOperator(string operatorAsString, string binaryTemplate)
        {
            OperatorAsString = operatorAsString;
            BinaryTemplate = binaryTemplate;
        }

        protected BinaryOperator(string operatorAsString)
        {
            OperatorAsString = operatorAsString;
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