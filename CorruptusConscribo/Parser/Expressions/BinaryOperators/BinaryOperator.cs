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
            return Junction.BinaryOperators[token.Name];
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