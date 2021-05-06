using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CorruptusConscribo
{
    public static class TokenLibrary
    {
        public static class Words
        {
            public const string OpenBracket = "OpenBracket";
            public const string CloseBracket = "CloseBracket";
            public const string OpenParenthesis = "OpenParenthesis";
            public const string CloseParenthesis = "CloseParenthesis";
            public const string Semicolon = "Semicolon";
            public const string Identifier = "Identifier";
            public const string IntegerLiteral = "IntegerLiteral";
            
            public const string Negation = "Negation";
            public const string BitwiseComplement = "BitwiseComplement";
            public const string LogicalNegation = "LogicalNegation";

            public const string Addition = "Addition";
            public const string Division = "Division";
            public const string Multiplication = "Multiplication";

            public const string Int = "Int";
            public const string Return = "Return";
        }

        private static readonly List<Operator> Operators = new()
        {
            new Negation(),
            new BitwiseComplement(),
            new LogicalNegation(),
            new Addition(),
            new Division(),
            new Multiplication()
        };
        
        public static readonly List<Keyword> Keywords = new()
        {
            new Keyword(Words.Int, new Regex("int")),
            new Keyword(Words.Return, new Regex("return"))
        };

        private static readonly List<Syntax> Syntax = new()
        {
            new Syntax(Words.OpenBracket, new Regex("{")),
            new Syntax(Words.CloseBracket, new Regex("}")),
            new Syntax(Words.OpenParenthesis, new Regex("[(]")),
            new Syntax(Words.CloseParenthesis, new Regex("[)]")),
            new Syntax(Words.Semicolon, new Regex(";")),
            new Syntax(Words.Identifier, new Regex("([a-zA-Z]\\w*)")),
            new Syntax(Words.IntegerLiteral, new Regex("[0-9]+")),
        };

        private static List<Token> GenerateTokens()
        {
            var tokens = new List<Token>();
            tokens.AddRange(Keywords);
            tokens.AddRange(Syntax);
            tokens.AddRange(Operators);
            return tokens;
        }

        public static List<Token> Tokens { get; } = GenerateTokens();
    }
}