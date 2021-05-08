using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Adding_And_Multiplying : CompilerTest
    {
        public When_Adding_And_Multiplying() : base(14, "./stage_3/precedence.c", "./stage_3/", "int main() {return 2 + 3 * 4;}")
        {
        }
    }
}