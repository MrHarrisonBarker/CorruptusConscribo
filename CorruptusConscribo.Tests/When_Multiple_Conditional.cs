using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Multiple_Conditional : CompilerTest
    {
        public When_Multiple_Conditional() : base(10, "./stage_6/expression/multiple_ternary.c", "./stage_6/expression/")
        {
        }
    }
}