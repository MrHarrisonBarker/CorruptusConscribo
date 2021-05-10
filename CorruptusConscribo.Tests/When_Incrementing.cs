using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Incrementing : CompilerTest
    {
        public When_Incrementing() : base(6, "./stage_5/increment.c", "./stage_5/")
        {
        }
    }
}