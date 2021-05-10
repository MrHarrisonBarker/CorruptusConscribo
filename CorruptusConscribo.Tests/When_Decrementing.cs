using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Decrementing : CompilerTest
    {
        public When_Decrementing() : base(3, "./stage_5/decrement.c", "./stage_5/")
        {
        }
    }
}