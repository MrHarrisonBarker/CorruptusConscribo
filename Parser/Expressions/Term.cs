using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Term : BinaryOperator
    {
        private BinaryOperator Operator { get; }
        
        public Term()
        {
        }

        public Term(BinaryOperator op)
        {
            Operator = op;
        }

        public Term Parse(Queue<Token> tokens)
        {
            var factor = new Factor().Parse(tokens);

            var nextToken = tokens.Peek();
            
            while (nextToken.Name == TokenLibrary.Words.Multiplication || nextToken.Name == TokenLibrary.Words.Division)
            {
                var op = new BinaryOperator(tokens.Dequeue());
                var nextTerm = new Factor().Parse(tokens);
                factor = new Factor(new BinaryOperator(op, factor, nextTerm));
                nextToken = tokens.Peek();
            }
            
            // might be wrong   
            return this;
        }
    }
}