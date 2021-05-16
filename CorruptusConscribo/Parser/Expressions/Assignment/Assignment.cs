using System;
using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public abstract class Assignment : Expression
    {
        public Expression LeftExpression { get; private set; }
        public Expression RightExpression { get; private set; }
        private string AssignmentOperator { get; }
        protected string AssignmentTemplate { get; }

        protected Assignment(Scope scope, string assignmentOperator, string assignmentTemplate) : base(scope)
        {
            AssignmentTemplate = assignmentTemplate;
            AssignmentOperator = assignmentOperator;
        }

        protected Assignment(Scope scope, string assignmentOperator) : base(scope)
        {
            AssignmentOperator = assignmentOperator;
        }

        public Assignment Add(Expression leftExpression, Expression rightExpression)
        {
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
            return this;
        }

        public Assignment Add(Expression variable)
        {
            LeftExpression = variable;

            return this;
        }

        public static Assignment New(Scope scope, Token token)
        {
            return token.Name switch
            {
                TokenLibrary.Words.Assignment => new Assign(scope),
                TokenLibrary.Words.AdditionAssign => new AdditionAssign(scope),
                TokenLibrary.Words.SubtractionAssign => new SubtractionAssign(scope),
                TokenLibrary.Words.MultiplicationAssign => new MultiplicationAssign(scope),
                TokenLibrary.Words.DivisionAssign => new DivisionAssign(scope),
                TokenLibrary.Words.ModuloAssign => new ModuloAssign(scope),
                TokenLibrary.Words.AndAssign => new AndAssign(scope),
                TokenLibrary.Words.OrAssign => new OrAssign(scope),
                TokenLibrary.Words.XorAssign => new XorAssign(scope),
                TokenLibrary.Words.Increment => new Increment(scope),
                TokenLibrary.Words.Decrement => new Decrement(scope),
                _ => throw new InvalidOperationException()
            };
        }

        public override string Template()
        {
            if (LeftExpression.GetType() == typeof(Assign))
            {
                return $"{LeftExpression.Template()}" +
                       $"\n{RightExpression.Template()}" +
                       $"\n{AssignmentTemplate}" +
                       $"\n{LeftExpression.Save()}";
            }
            
            return $"{RightExpression.Template()}" +
                   $"\n{AssignmentTemplate}" +
                   $"\n{LeftExpression.Save()}";
        }
        
        public override string Save()
        {
            return RightExpression.Save();
        }

        public override string ToString()
        {
            return $"\t{LeftExpression} {AssignmentOperator} {RightExpression}";
        }
    }
}