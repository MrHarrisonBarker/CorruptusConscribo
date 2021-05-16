using NUnit.Framework;

namespace CorruptusConscribo.Tests.ErrorCatching
{
    [TestFixture]
    public class When_Declaration_Mismatch : FailureTest<CompileException>
    {
        public When_Declaration_Mismatch() : base("foo has already been initialised", "./stage_9/invalid/declaration_mismatch.c")
        {
        }
    }
}