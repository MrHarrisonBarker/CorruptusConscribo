using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Multi_Nesting : CompilerTest
    {
        public When_Multi_Nesting() : base(3, "./stage_7/valid/multi_nesting.c", "./stage_7/valid/")
        {
        }
    }
}