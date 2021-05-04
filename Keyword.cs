using System.Text.RegularExpressions;

namespace CorruptusConscribo
{
    public class Keyword : Token
    {
        public Keyword(string name, Regex expression) : base(name, expression)
        {
        }
    }
}