using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Expressing_Vars : CompilerTest
    {
        public When_Expressing_Vars() : base(5, "./stage_5/exp_return_val.c", "./stage_5/")
        {
        }
    }
}