using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Adding : CompilerTest
    {
        public When_Adding() : base(3, "./stage_3/add.c", "./stage_3/", "int main() {return 1 + 2;}")
        {
        }
    }
}