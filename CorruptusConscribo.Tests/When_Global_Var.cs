using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Global_Var : CompilerTest
    {
        public When_Global_Var() : base(12,"./stage_10/valid/global.c","./stage_10/valid/") {}
    }
}