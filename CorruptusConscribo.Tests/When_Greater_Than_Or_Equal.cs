using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Greater_Than_Or_Equal : CompilerTest
    {
        public When_Greater_Than_Or_Equal() : base(1, "./stage_4/ge_true.c", "./stage_4/", "int main() {return 1 >= 1;}")
        {
        }
    }
}