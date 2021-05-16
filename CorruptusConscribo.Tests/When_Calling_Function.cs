using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Calling_Function : CompilerTest
    {
        public When_Calling_Function(): base(3,"./stage_9/valid/no_arg.c","./stage_9/valid/") {}
    }
}