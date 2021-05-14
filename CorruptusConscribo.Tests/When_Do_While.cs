using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Do_While : CompilerTest
    {
        public When_Do_While() : base(16, "./stage_8/valid/do_while.c", "./stage_8/valid/")
        {
        }
    }
}