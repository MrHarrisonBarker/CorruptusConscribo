using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Greater_Than : CompilerTest
    {
        public When_Greater_Than() : base(1, "./stage_4/gt_true.c", "./stage_4/", "int main() {return 1 > 0;}")
        {
        }
    }
}