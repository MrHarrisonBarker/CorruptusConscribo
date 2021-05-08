using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Dividing : CompilerTest
    {
        public When_Dividing() : base(2, "./stage_3/div.c", "./stage_3/", "int main() {return 4 / 2;}")
        {
        }
    }
}