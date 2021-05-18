using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Nested_If_3 : CompilerTest
    {
        public When_Nested_If_3() : base(3, "./stage_6/statement/if_nested_3.c", "./stage_6/statement/")
        {
        }
    }
}