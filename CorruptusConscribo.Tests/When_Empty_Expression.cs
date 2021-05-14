using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Empty_Expression : CompilerTest
    {
        public When_Empty_Expression() : base(3,"./stage_8/valid/empty_expression.c","./stage_8/valid/") {}
    }
}