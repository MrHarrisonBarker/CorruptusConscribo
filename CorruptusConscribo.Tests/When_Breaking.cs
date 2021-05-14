using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Breaking : CompilerTest
    {
        public When_Breaking() : base(15,"./stage_8/valid/break.c","./stage_8/valid/") {}
    }
}