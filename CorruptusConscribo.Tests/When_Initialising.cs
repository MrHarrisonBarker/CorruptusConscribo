using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Initialising : CompilerTest
    {
        public When_Initialising() : base(0, "./stage_5/initialize.c", "./stage_5/")
        {
        }
    }
}