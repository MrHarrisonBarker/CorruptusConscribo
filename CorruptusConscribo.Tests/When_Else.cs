using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Else : CompilerTest
    {
        public When_Else() : base(2, "./stage_6/statement/else.c", "./stage_6/statement/")
        {
        }
    }
}