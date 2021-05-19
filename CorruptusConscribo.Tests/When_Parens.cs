using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Parens : CompilerTest
    {
        public When_Parens() : base(14,"./stage_3/parens.c","./stage_3/") {}
    }
}