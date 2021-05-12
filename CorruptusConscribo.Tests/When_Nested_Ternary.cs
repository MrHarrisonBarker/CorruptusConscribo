using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Nested_Ternary : CompilerTest
    {
        public When_Nested_Ternary() : base(7, "./stage_6/expression/nested_ternary.c", "./stage_6/expression/")
        {
        }
    }
}