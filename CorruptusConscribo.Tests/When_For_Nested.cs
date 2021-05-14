using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_For_Nested : CompilerTest
    {
        public When_For_Nested() : base(3, "./stage_8/valid/for_nested_scope.c", "./stage_8/valid/")
        {
        }
    }
}