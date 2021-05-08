using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Or : CompilerTest
    {
        public When_Or() : base(1, "./stage_4/or_true.c", "./stage_4/", "int main() {return 1 || 0;}")
        {
        }
    }
}