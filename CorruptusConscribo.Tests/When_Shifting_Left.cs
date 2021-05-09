using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Shifting_Left : CompilerTest
    {
        public When_Shifting_Left() : base(1, "./stage_4/left_shift.c", "./stage_4/")
        {
        }
    }
}