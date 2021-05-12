using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Nested_Else_If : CompilerTest
    {
        public When_Nested_Else_If() : base(1, "./stage_6/statement/if_nested.c", "./stage_6/statement/")
        {
        }
    }
}