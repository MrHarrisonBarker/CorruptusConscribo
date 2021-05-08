using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Equals : CompilerTest
    {
        public When_Equals() : base(1, "./stage_4/eq_true.c", "./stage_4/", "int main() {return 1 == 1;}")
        {
        }
    }
}