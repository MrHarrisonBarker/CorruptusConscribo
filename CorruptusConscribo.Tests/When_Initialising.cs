using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Initialising : CompilerTest
    {
        public When_Initialising() : base(2, "./stage_5/init.c", "./stage_5/")
        {
        }
    }
}