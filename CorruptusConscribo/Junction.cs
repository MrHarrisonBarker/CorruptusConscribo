using System.Collections.Generic;
using CorruptusConscribo.Parser;
using CorruptusConscribo.Parser.Expressions.BinaryOperators;

namespace CorruptusConscribo
{
    public static class Junction
    {
        public static Dictionary<string, BinaryOperator> BinaryOperators = new()
        {
            {TokenLibrary.Words.Addition, new Addition()},
            {TokenLibrary.Words.Division, new Division()},
            {TokenLibrary.Words.Multiplication, new Multiplication()},
            {TokenLibrary.Words.Negation, new BinaryNegation()},
            {TokenLibrary.Words.AND, new And()},
            {TokenLibrary.Words.OR, new Or()},
            {TokenLibrary.Words.Equal, new Equal()},
            {TokenLibrary.Words.NotEqual, new NotEqual()},
            {TokenLibrary.Words.LessThan, new LessThan()},
            {TokenLibrary.Words.LessThanOrEqual, new LessThanOrEqual()},
            {TokenLibrary.Words.GreaterThan, new GreaterThan()},
            {TokenLibrary.Words.GreaterThanOrEqual, new GreaterThanOrEqual()},
            {TokenLibrary.Words.Modulo, new Modulo()},
            {TokenLibrary.Words.BitwiseAnd, new BitwiseOr()},
            {TokenLibrary.Words.BitwiseOr, new BitwiseOr()},
            {TokenLibrary.Words.BitwiseXor, new BitwiseXor()},
            {TokenLibrary.Words.BitwiseLeft, new BitwiseLeft()},
            {TokenLibrary.Words.BitwiseRight, new BitwiseRight()},
        };
    }
}