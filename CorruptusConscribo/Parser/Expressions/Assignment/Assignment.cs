using System;
using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public abstract class Assignment : Expression
    {
        protected string Variable { get; set; }
        protected Expression Expression { get; set; }
        private string AssignmentOperator { get; }
        private string AssignmentTemplate { get; }

        protected Assignment(Scope scope, string assignmentOperator, string assignmentTemplate) : base(scope)
        {
            AssignmentTemplate = assignmentTemplate;
            AssignmentOperator = assignmentOperator;
        }

        protected Assignment(Scope scope, string assignmentOperator) : base(scope)
        {
            AssignmentOperator = assignmentOperator;
        }

        public Assignment Add(string variableId, Expression expression)
        {
            Variable = variableId;
            Expression = expression;
            return this;
        }

        public Assignment Add(string variableId)
        {
            Variable = variableId;
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

        public override string ToString()
        {
            return $"\t{Variable} {AssignmentOperator} {Expression}";
        }
    }
}