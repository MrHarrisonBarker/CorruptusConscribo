using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Function_Precedence : CompilerTest
    {
        public When_Function_Precedence(): base(0,"./stage_9/valid/precedence.c","./stage_9/valid/") {}
    }
}