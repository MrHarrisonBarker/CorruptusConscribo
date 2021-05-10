using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Subbing_Assign : CompilerTest
    {
        public When_Subbing_Assign() : base(1, "./stage_5/sub_assign.c", "./stage_5/")
        {
        }
    }
}