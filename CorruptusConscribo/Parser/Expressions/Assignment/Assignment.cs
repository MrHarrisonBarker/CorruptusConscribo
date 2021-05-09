using System;
using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public abstract class Assignment : Expression
    {
        private string Variable { get; set; }
        private Expression Expression { get; set; }
        private string AssignmentOperator { get; }
        private string AssignmentTemplate { get; }

        protected Assignment(string assignmentOperator, string assignmentTemplate)
        {
            AssignmentTemplate = assignmentTemplate;
            AssignmentOperator = assignmentOperator;
        }

        public Assignment Add(string variableId,Expression expression)
        {
            Variable = variableId;
            Expression = expression;
            return this;
        }

        public static Assignment New(Token token)
        {
            return token.Name switch
            {
                TokenLibrary.Words.Assignment => new Assign(),
                _ => throw new InvalidOperationException()
            };
        }

        public override string ToString()
        {
            return $"\t{Variable} {AssignmentOperator} {Expression}";
        }
    }
}