using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Declaring_After_Block : CompilerTest
    {
        public When_Declaring_After_Block() : base(3, "./stage_7/valid/declare_after_block.c", "./stage_7/valid/")
        {
        }
    }
}