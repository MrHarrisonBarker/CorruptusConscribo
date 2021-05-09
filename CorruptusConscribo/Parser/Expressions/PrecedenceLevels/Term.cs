using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Term : Expression
    {
        // <term> ::= <factor> { ("*" | "/" | "%") <factor> }
        public Expression Parse(Stack<Token> tokens)
        {
            // get the factor before checking for operators
            Expression term = new Factor(Scope).Parse(tokens);

            var nextToken = tokens.Peek();

            while (nextToken.Name == TokenLibrary.Words.Multiplication || nextToken.Name == TokenLibrary.Words.Division || nextToken.Name == TokenLibrary.Words.Modulo)
            {
                // create the binary operator using token
                var op = BinaryOperator.New(Scope, tokens.Pop());

                var nextTerm = new Factor(Scope).Parse(tokens);

                term = op.Add(term, nextTerm);

                nextToken = tokens.Peek();
            }

            // might be wrong   
            return term;
        }

        public Term(Scope scope) : base(scope)
        {
        }
    }
}