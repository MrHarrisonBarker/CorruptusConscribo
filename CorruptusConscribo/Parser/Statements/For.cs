using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class For : Statement
    {
        protected Slice Option1 { get; set; }
        protected Expression Option2 { get; set; }
        protected Expression Option3 { get; set; }
        
        protected Block Statement { get; set; }
        
        public For(Scope scope) : base(scope)
        {
        }
        
        // "for" "(" <exp-option> ";" <exp-option> ";" <exp-option> ")" <statement>
        public For Parse(Stack<Token> tokens)
        {
            tokens.Pop();
            var token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.OpenParenthesis) throw new SyntaxException("expected (");

            var nextToken = tokens.Peek();
            
            // if the next token is a variable type
            if (nextToken.Name == TokenLibrary.Words.Int) return new ForDeclare(Scope).Parse(tokens);
            

            Option1 = new OptionalSemicolon(Scope).Parse(tokens);
            
            Option2 = new OptionalSemicolon(Scope).Parse(tokens);

            // ensuring non zero expression
            if (Option2.GetType() == typeof(OptionalSemicolon)) Option2 = new Constant(Scope,1);

            Option3 = new OptionalCloseParam(Scope).Parse(tokens);

            Statement = new Statement(Scope).Parse(tokens);

            return this;
        }

        public override string ToString()
        {
            return $"for ({Option1};{Option2};{Option3}) {{\n\t{Statement}\n\t}}";
        }
    }
}