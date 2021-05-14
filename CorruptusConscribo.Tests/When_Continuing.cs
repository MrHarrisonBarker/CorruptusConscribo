using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Continuing : CompilerTest
    {
        public When_Continuing() : base(1,"./stage_8/valid/continue.c","./stage_8/valid/") {}
    }
}