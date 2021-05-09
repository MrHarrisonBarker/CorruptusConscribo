using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Using_Multiple_Vars : CompilerTest
    {
        public When_Using_Multiple_Vars() : base(3, "./stage_5/multiple_vars.c", "./stage_5/")
        {
        }
    }
}