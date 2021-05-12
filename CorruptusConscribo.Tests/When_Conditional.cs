using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Conditional : CompilerTest
    {
        public When_Conditional() : base(2, "./stage_6/expression/assign_ternary.c", "./stage_6/expression/")
        {
        }
    }
}