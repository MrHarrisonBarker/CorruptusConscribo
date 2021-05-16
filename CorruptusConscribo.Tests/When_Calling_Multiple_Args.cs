using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Calling_Multiple_Args : CompilerTest
    {
        public When_Calling_Multiple_Args(): base(-1,"./stage_9/valid/multi_arg.c","./stage_9/valid/") {}
    }
}