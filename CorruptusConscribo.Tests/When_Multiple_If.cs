using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Multiple_If : CompilerTest
    {
        public When_Multiple_If() : base(8, "./stage_6/statement/multiple_if.c", "./stage_6/statement/")
        {
        }
    }
}