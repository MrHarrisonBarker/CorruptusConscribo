using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class FunctionCall : Expression
    {
        private string FunctionId { get; set; }
        private List<Expression> Params { get; set; } = new();

        public FunctionCall(Scope scope) : base(scope)
        {
        }

        // <function-call> ::= id "(" [ <exp> { "," <exp> } ] ")"
        public FunctionCall Parse(Stack<Token> tokens, string functionId)
        {
            FunctionId = functionId;

            var token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.OpenParenthesis) throw new SyntaxException("expected (");

            var nextToken = tokens.Peek();

            while (nextToken.Name != TokenLibrary.Words.CloseParenthesis)
            {
                Params.Add(new Expression(Scope).Parse(tokens));
                nextToken = tokens.Peek();
            }

            token = tokens.Pop();

            if (token.Name != TokenLibrary.Words.CloseParenthesis) throw new SyntaxException("expected )");

            return this;
        }

        public override string ToString()
        {
            return $"{FunctionId}({string.Join(",",Params)})";
        }
    }
}