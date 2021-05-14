using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_For_Declare : CompilerTest
    {
        public When_For_Declare() : base(3, "./stage_8/valid/for_decl.c", "./stage_8/valid/")
        {
        }
    }
}