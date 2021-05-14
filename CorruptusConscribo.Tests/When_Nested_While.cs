using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Nested_While : CompilerTest
    {
        public When_Nested_While() : base(65,"./stage_8/valid/nested_while.c","./stage_8/valid/") {}
    }
}