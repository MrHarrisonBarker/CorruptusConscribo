using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class While : Statement
    {
        private Expression Expression { get; set; }
        private Block Statement { get; set; }
        
        public While(Scope scope) : base(scope)
        {
        }

        // "while" "(" <exp> ")" <statement>
        public While Parse(Stack<Token> tokens)
        {
            tokens.Pop();
            var token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.OpenParenthesis) throw new SyntaxException("expected (");

            Expression = new Expression(Scope).Parse(tokens);
            
            token = tokens.Pop();
            
            if (token.Name != TokenLibrary.Words.CloseParenthesis) throw new SyntaxException("expected )");

            Statement = new Statement(Scope).Parse(tokens);
            
            return this;
        }

        public override string ToString()
        {
            return $"while ({Expression})\n\t{Statement}";
        }

        public override string Template()
        {
            var whileFunc = Healpers.GetFunctionId();
            var endFunc = Healpers.GetFunctionId();
            
            var breakPoint = Scope.UseBreakpoint();
            var tmp = $"{whileFunc}:\n{Expression.Template()}\ncmpq\t$0,%rax\nje\t{endFunc}\n{Statement.Template()}\njmp\t{whileFunc}\n{endFunc}:";

            return breakPoint != null ? tmp + $"{breakPoint}:\t# Breakpoint\n" : tmp;
        }
    }
}