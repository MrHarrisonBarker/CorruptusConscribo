using NUnit.Framework;

namespace CorruptusConscribo.Tests.ErrorCatching
{
    [TestFixture]
    public class When_Function_Redefined : FailureTest<CompileException>
    {
        public When_Function_Redefined() : base("foo has already been initialised", "./stage_9/invalid/redefine_function.c")
        {
        }
    }
}