using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_And : CompilerTest
    {
        public When_And() : base(1, "./stage_4/and_true.c", "./stage_4/", "int main() {return 1 && -1;}")
        {
        }
    }
}