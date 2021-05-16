using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Hello_World : CompilerTest
    {
        public When_Hello_World(): base(-1,"./stage_9/valid/hello_world.c","./stage_9/valid/") {}
    }
}