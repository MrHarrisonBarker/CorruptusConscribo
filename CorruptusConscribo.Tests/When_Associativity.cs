using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Associativity : CompilerTest
    {
        public When_Associativity() : base(252,"./stage_3/associativity.c","./stage_3/") {}
    }
}