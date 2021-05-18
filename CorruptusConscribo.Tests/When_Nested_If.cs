using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Nested_If : CompilerTest
    {
        public When_Nested_If() : base(4, "./stage_7/valid/nested_if.c", "./stage_7/valid/")
        {
        }
    }
}