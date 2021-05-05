using System;
using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public class Expression : ASTNode
    {
        public Expression Parse(Queue<Token> tokens)
        {
            var token = tokens.Dequeue();

            if (token.Name != TokenLibrary.Words.IntegerLiteral) throw new Exception("invalid syntax");

            // token.Value.ToInt32(null)
            var expression = new Constant(token.Value.ToInt32(null));

            return expression;
        }
    }

    public class Constant : Expression
    {
        private int Value { get; }

        public Constant(int value)
        {
            Value = value;
        }

        public override string Template()
        {
            return Value.ToString();
        }
    }
}