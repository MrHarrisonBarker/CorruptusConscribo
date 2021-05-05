using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CorruptusConscribo
{
    public class Lexicanum
    {
        public readonly List<Token> Tokens = new();
        private readonly string Source;

        public Lexicanum(string source)
        {
            Source = source;

            FindTokens();
            RemoveChaff();

            // Sort all the tokens by their placement in the source
            Tokens = Tokens.OrderBy(x => x.Start).ToList();
            Console.WriteLine($"Sorted the source\n {string.Join("\n", Tokens)}");
        }

        // Find all the token in the source code
        // returned as a list of Tokens
        private void FindTokens()
        {
            // Check each token type in the library for matches
            // TODO: Feels a bit inefficient
            TokenLibrary.Tokens.ForEach(token =>
            {
                var matches = token.Expression.Matches(Source);

                Console.WriteLine($"Found {matches.Count} for {token.Name}");

                foreach (Match match in matches)
                {
                    Tokens.Add(new Token(token, match.Index, match.Index + match.Length, match.Value));
                }
            });

            Console.WriteLine($"added {Tokens.Count} tokens");
        }

        private void RemoveChaff()
        {
            var chaff = new List<Token>();
            Tokens.ForEach(token =>
            {
                if (token.Name == TokenLibrary.Words.Identifier)
                {
                    if (TokenLibrary.Keywords.Any(x => string.Equals(x.Name, token.Value.ToString(), StringComparison.CurrentCultureIgnoreCase)))
                    {
                        chaff.Add(token);
                    }
                }
            });
            chaff.ForEach(c => Tokens.Remove(c));
        }
    }
}