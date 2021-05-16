using NUnit.Framework;

namespace CorruptusConscribo.Tests.ErrorCatching
{
    [TestFixture]
    public class When_Func_Has_Bad_Args : FailureTest<CompileException>
    {
        public When_Func_Has_Bad_Args() : base("param err", "./stage_9/invalid/bad_arg.c")
        {
        }
    }
}