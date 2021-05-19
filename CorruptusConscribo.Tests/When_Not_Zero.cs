using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Not_Zero : CompilerTest
    {
        public When_Not_Zero() : base(1,"./stage_2/not_zero.c","./stage_2/") {}
    }
}