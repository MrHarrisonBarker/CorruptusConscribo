using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Dividing_Assign : CompilerTest
    {
        public When_Dividing_Assign() : base(2, "./stage_5/div_assign.c", "./stage_5/")
        {
        }
    }
}