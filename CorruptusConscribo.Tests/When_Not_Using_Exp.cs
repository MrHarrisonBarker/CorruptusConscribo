using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Not_Using_Exp : CompilerTest
    {
        public When_Not_Using_Exp() : base(0, "./stage_5/unused_exp.c", "./stage_5/")
        {
        }
    }
}