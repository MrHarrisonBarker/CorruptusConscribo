using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Calling_Fib : CompilerTest
    {
        public When_Calling_Fib(): base(-1,"./stage_9/valid/fib.c","./stage_9/valid/") {}
    }
}