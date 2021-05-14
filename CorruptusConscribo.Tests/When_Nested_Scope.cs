using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Nested_Scope : CompilerTest
    {
        public When_Nested_Scope() : base(4, "./stage_7/valid/nested_scope.c", "./stage_7/valid/")
        {
        }
    }
}