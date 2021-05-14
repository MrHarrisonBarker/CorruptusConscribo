using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_For : CompilerTest
    {
        public When_For() : base(3, "./stage_8/valid/for.c", "./stage_8/valid/")
        {
        }
    }
}