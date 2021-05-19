using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Dividing_Negative : CompilerTest
    {
        public When_Dividing_Negative() : base(254,"./stage_3/div_neg.c","./stage_3/") {}
    }
}