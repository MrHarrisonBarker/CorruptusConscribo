using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Declaring_Block : CompilerTest
    {
        public When_Declaring_Block() : base(0, "./stage_7/valid/declare_block.c", "./stage_7/valid/")
        {
        }
    }
}