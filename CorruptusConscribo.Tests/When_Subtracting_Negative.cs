using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Subtracting_Negative : CompilerTest
    {
        public When_Subtracting_Negative() : base(3,"./stage_3/sub_neg.c","./stage_3/") {}
    }
}