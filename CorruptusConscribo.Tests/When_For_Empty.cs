using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_For_Empty : CompilerTest
    {
        public When_For_Empty() : base(4, "./stage_8/valid/for_empty.c", "./stage_8/valid/")
        {
        }
    }
}