using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Nesting_Ifs : CompilerTest
    {
        public When_Nesting_Ifs() : base(4, "./stage_7/valid/nested_if.c", "./stage_7/valid/")
        {
        }
    }
}