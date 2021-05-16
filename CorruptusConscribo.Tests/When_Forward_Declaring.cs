using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Forward_Declaring : CompilerTest
    {
        public When_Forward_Declaring(): base(-1,"./stage_9/valid/forward_decl.c","./stage_9/valid/") {}
    }
}