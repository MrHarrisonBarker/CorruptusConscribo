using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Nested_Uni_Ops : CompilerTest
    {
        public When_Nested_Uni_Ops() : base(0,"./stage_2/nested_ops.c","./stage_2/") {}
    }
}