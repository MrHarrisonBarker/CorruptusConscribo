using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Not_Equals : CompilerTest
    {
        public When_Not_Equals() : base(1, "./stage_4/ne_true.c", "./stage_4/", "int main() {return -1 != -2;}")
        {
        }
    }
}