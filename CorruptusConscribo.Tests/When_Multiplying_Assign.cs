using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Multiplying_Assign : CompilerTest
    {
        public When_Multiplying_Assign() : base(4, "./stage_5/multi_assign.c", "./stage_5/")
        {
        }
    }
}