using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Nested_If : CompilerTest
    {
        public When_Nested_If() : base(3, "./stage_6/statement/if_nested_3.c", "./stage_6/statement/")
        {
        }
    }
}