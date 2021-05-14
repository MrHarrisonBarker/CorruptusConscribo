using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_While : CompilerTest
    {
        public When_While() : base(6, "./stage_8/valid/while_single_statement.c", "./stage_8/valid/")
        {
        }
    }
}