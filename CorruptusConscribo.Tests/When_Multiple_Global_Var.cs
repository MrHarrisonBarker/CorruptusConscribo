using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Multiple_Global_Var : CompilerTest
    {
        public When_Multiple_Global_Var() : base(12,"./stage_10/valid/multiple_global.c","./stage_10/valid/") {}
    }
}