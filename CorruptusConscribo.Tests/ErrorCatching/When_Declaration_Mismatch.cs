using NUnit.Framework;

namespace CorruptusConscribo.Tests.ErrorCatching
{
    [TestFixture]
    public class When_Declaration_Mismatch : FailureTest<CompileException>
    {
        public When_Declaration_Mismatch() : base("the function declaration doesn't match the definition", "./stage_9/invalid/declaration_mismatch.c")
        {
        }
    }
}