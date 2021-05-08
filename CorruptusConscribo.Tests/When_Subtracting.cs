using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Subtracting : CompilerTest
    {
        public When_Subtracting() : base(1, "./stage_3/sub.c", "./stage_3/", "int main() {return 1 - 2;}")
        {
        }
    }
}