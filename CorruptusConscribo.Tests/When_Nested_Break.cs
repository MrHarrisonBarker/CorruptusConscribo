using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Nested_Break : CompilerTest
    {
        public When_Nested_Break() : base(250,"./stage_8/valid/nested_break.c","./stage_8/valid/") {}
    }
}