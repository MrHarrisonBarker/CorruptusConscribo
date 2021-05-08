using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Multiplying : CompilerTest
    {
        public When_Multiplying() : base(6, "./stage_3/mult.c", "./stage_3/", "int main() {return 2 * 3;}")
        {
        }
    }
}