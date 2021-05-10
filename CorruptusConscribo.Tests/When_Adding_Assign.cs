using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Adding_Assign : CompilerTest
    {
        public When_Adding_Assign(): base(12,"./stage_5/addition_assign.c","./stage_5/") {}
    }
}