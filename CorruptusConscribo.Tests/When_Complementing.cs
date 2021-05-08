using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Complementing : CompilerTest
    {
        public When_Complementing() : base(255, "./stage_2/bitwise_zero.c", "./stage_2/", "int main() {return ~5}")
        {
        }
    }
}