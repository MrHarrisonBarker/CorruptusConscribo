using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Recursion : CompilerTest
    {
        public When_Recursion(): base(-1,"./stage_9/valid/mutual_recursion.c","./stage_9/valid/") {}
    }
}