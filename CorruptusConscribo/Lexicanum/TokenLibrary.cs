using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;

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
            public const string AND = "AND";
            public const string OR = "OR";
            public const string Equal = "Equal";
            public const string NotEqual = "NotEqual";
            public const string LessThan = "LessThan";
            public const string LessThanOrEqual = "LessThanOrEqual";
            public const string GreaterThan = "GreaterThan";
            public const string GreaterThanOrEqual = "GreaterThanOrEqual";
            public const string Modulo = "Modulo";
            public const string BitwiseAnd = "BitwiseAnd";
            public const string BitwiseOr = "BitwiseOr";
            public const string BitwiseXor = "BitwiseXor";
            public const string BitwiseLeft = "BitwiseLeft";
            public const string BitwiseRight = "BitwiseRight";
            public const string Assignment = "Assignment";

            public const string Int = "Int";
            public const string Return = "Return";
        }

        private static readonly List<Operator> Operators = new()
        {
            new Operator(Words.Negation, new Regex("-")),
            new Operator(Words.BitwiseComplement, new Regex("~")),
            new Operator(Words.LogicalNegation, new Regex("!(?!=)")),
            new Operator(Words.Addition, new Regex("[+]")),
            new Operator(Words.Division, new Regex("[/]")),
            new Operator(Words.Multiplication, new Regex("[*]")),
            new Operator(Words.AND, new Regex("&&")),
            new Operator(Words.OR, new Regex("(\\|\\|)")),
            new Operator(Words.Equal, new Regex("==")),
            new Operator(Words.NotEqual, new Regex("(!=)")),
            new Operator(Words.LessThan, new Regex("(?<![<,=])<(?![<,=])")),
            new Operator(Words.LessThanOrEqual, new Regex("<=")),
            new Operator(Words.GreaterThan, new Regex("(?<![>,=])>(?![>,=])")),
            new Operator(Words.GreaterThanOrEqual, new Regex(">=(?!>)")),
            new Operator(Words.Modulo, new Regex("%")),
            new Operator(Words.BitwiseAnd, new Regex("(?<!&)&(?!&)")),
            new Operator(Words.BitwiseOr, new Regex("(?<!\\|)\\|(?!\\|)")),
            new Operator(Words.BitwiseXor, new Regex("(\\^)")),
            new Operator(Words.BitwiseLeft, new Regex("<<")),
            new Operator(Words.BitwiseRight, new Regex(">>")),
            new Operator(Words.Assignment, new Regex("=")),
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