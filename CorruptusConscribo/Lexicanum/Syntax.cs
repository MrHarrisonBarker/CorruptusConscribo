using System.Text.RegularExpressions;

namespace CorruptusConscribo
{
    public class Syntax : Token
    {
        public Syntax(string name, Regex expression) : base(name, expression)
        {
        }
    }
}