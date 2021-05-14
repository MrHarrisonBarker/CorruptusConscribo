using System;
using System.Collections.Generic;
using CorruptusConscribo.Parser.Expressions.BinaryOperators;

namespace CorruptusConscribo.Parser
{
    public abstract class BinaryOperator : Expression
    {
        protected Expression LeftExpression { get; private set; }
        protected Expression RightExpression { get; private set; }
        protected string BinaryTemplate { get; set; }
        private string OperatorAsString { get; }

        public BinaryOperator Add(Expression leftExpression, Expression rightExpression)
        {
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
            return this;
        }

        public static BinaryOperator New(Scope scope, Token token)
        {
            return token.Name switch
            {
                TokenLibrary.Words.Addition => new Addition(scope),
                TokenLibrary.Words.Multiplication => new Multiplication(scope),
                TokenLibrary.Words.Division => new Division(scope),
                TokenLibrary.Words.Negation => new BinaryNegation(scope),
                TokenLibrary.Words.AND => new And(scope),
                TokenLibrary.Words.OR => new Or(scope),
                TokenLibrary.Words.Equal => new Equal(scope),
                TokenLibrary.Words.NotEqual => new NotEqual(scope),
                TokenLibrary.Words.LessThan => new LessThan(scope),
                TokenLibrary.Words.LessThanOrEqual => new LessThanOrEqual(scope),
                TokenLibrary.Words.GreaterThan => new GreaterThan(scope),
                TokenLibrary.Words.GreaterThanOrEqual => new GreaterThanOrEqual(scope),
                TokenLibrary.Words.Modulo => new Modulo(scope),
                TokenLibrary.Words.BitwiseAnd => new BitwiseAnd(scope),
                TokenLibrary.Words.BitwiseOr => new BitwiseOr(scope),
                TokenLibrary.Words.BitwiseXor => new BitwiseXor(scope),
                TokenLibrary.Words.BitwiseLeft => new BitwiseLeft(scope),
                TokenLibrary.Words.BitwiseRight => new BitwiseRight(scope),
                TokenLibrary.Words.Comma => new Comma(scope),
                _ => throw new InvalidOperationException()
            };
        }

        protected BinaryOperator(Scope scope, string operatorAsString, string binaryTemplate) : base(scope)
        {
            OperatorAsString = operatorAsString;
            BinaryTemplate = binaryTemplate;
        }

        protected BinaryOperator(Scope scope, string operatorAsString) : base(scope)
        {
            OperatorAsString = operatorAsString;
        }

        public override string Template()
        {
            return $"{LeftExpression.Template()}" +
                   "\npush\t%rax\t# pushing left of operator into stack" +
                   $"\n{RightExpression.Template()}" +
                   "\npop\t%rcx\t# popping left of operator onto rcx" +
                   $"\n{BinaryTemplate}";
        }

        public override string ToString()
        {
            return $"({LeftExpression} {OperatorAsString} {RightExpression})";
        }
    }
}