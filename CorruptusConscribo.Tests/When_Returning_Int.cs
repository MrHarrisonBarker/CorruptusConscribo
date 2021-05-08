using System.Collections.Generic;
using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Returning_Int : CompilerTest
    {
        public When_Returning_Int() : base(2, "./stage_1/return_2.c", "./stage_1/", "int main()\n{\n   return 2;\n}",
            new List<Token>
            {
                new Token(TokenLibrary.Tokens.Find(x => x.Name == TokenLibrary.Words.CloseBracket), 26, 27, "}"),
                new Token(TokenLibrary.Tokens.Find(x => x.Name == TokenLibrary.Words.Semicolon), 24, 25, ";"),
                new Token(TokenLibrary.Tokens.Find(x => x.Name == TokenLibrary.Words.IntegerLiteral), 23, 24, "2"),
                new Token(TokenLibrary.Tokens.Find(x => x.Name == TokenLibrary.Words.Return), 16, 22, "return"),
                new Token(TokenLibrary.Tokens.Find(x => x.Name == TokenLibrary.Words.OpenBracket), 11, 12, "{"),
                new Token(TokenLibrary.Tokens.Find(x => x.Name == TokenLibrary.Words.CloseParenthesis), 9, 10, ")"),
                new Token(TokenLibrary.Tokens.Find(x => x.Name == TokenLibrary.Words.OpenParenthesis), 8, 9, "("),
                new Token(TokenLibrary.Tokens.Find(x => x.Name == TokenLibrary.Words.Identifier), 4, 8, "main"),
                new Token(TokenLibrary.Tokens.Find(x => x.Name == TokenLibrary.Words.Int), 0, 3, "int"),
            })
        {
        }
    }
}