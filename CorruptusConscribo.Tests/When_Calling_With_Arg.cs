using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Calling_With_Arg : CompilerTest
    {
        public When_Calling_With_Arg(): base(-1,"./stage_9/valid/single_arg.c","./stage_9/valid/") {}
    }
}