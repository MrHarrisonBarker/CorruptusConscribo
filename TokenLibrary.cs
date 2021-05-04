using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CorruptusConscribo
{
    public static class TokenLibrary
    {
        private static readonly List<Keyword> Keywords = new()
        {
            new Keyword("Int", new Regex("int")),
            new Keyword("Return", new Regex("return"))
        };
        
        private static readonly List<Syntax> Syntax = new()
        {
            new Syntax("OpenBracket", new Regex("{")),
            new Syntax("CloseBracket", new Regex("}")),
            new Syntax("OpenParenthesis", new Regex("[(]")),
            new Syntax("CloseParenthesis", new Regex("[)]")),
            new Syntax("Semicolon", new Regex(";")),
            new Syntax("Identifier", new Regex("([a-zA-Z]\\w*)")),
            new Syntax("IntegerLiteral", new Regex("[0-9]+"))
        };

        private static List<Token> GenerateTokens()
        {
            var tokens = new List<Token>();
            tokens.AddRange(Keywords);
            tokens.AddRange(Syntax);
            return tokens;
        }

        public static List<Token> Tokens { get; } = GenerateTokens();
    }
}