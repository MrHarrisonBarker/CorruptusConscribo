using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Not_If : CompilerTest
    {
        public When_Not_If() : base(0, "./stage_6/statement/if_not_taken.c", "./stage_6/statement/")
        {
        }
    }
}