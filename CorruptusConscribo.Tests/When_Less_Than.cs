using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Less_Than : CompilerTest
    {
        public When_Less_Than() : base(1, "./stage_4/lt_true.c", "./stage_4/", "int main() {return 1 < 2;}")
        {
        }
    }
}