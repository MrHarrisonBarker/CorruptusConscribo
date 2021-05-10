using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Modulo_Assign : CompilerTest
    {
        public When_Modulo_Assign() : base(1, "./stage_5/modulo_assign.c", "./stage_5/")
        {
        }
    }
}