using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Handling_Comma : CompilerTest
    {
        public When_Handling_Comma() : base(10, "./stage_5/comma.c", "./stage_5/")
        {
        }
    }
}