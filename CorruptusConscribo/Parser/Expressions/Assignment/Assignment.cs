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

        public Assignment Add(string variableId, Expression expression)
        {
            Variable = variableId;
            Expression = expression;
            return this;
        }

        public static Assignment New(Scope scope, Token token)
        {
            return token.Name switch
            {
                TokenLibrary.Words.Assignment => new Assign(scope),
                _ => throw new InvalidOperationException()
            };
        }

        public override string ToString()
        {
            return $"\t{Variable} {AssignmentOperator} {Expression}";
        }
    }
}