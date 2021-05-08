using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Less_Than_Or_Equal : CompilerTest
    {
        public When_Less_Than_Or_Equal() : base(1, "./stage_4/le_true.c", "./stage_4/", "int main() {return 0 <= 2;}")
        {
        }
    }
}