using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_No_Return : CompilerTest
    {
        public When_No_Return() : base(0, "./stage_5/no_return.c", "./stage_5/")
        {
        }
    }
}