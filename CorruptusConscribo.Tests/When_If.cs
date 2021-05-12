using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_If : CompilerTest
    {
        public When_If() : base(1, "./stage_6/statement/if_taken.c", "./stage_6/statement/")
        {
        }
    }
}