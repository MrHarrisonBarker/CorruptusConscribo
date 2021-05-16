using NUnit.Framework;

namespace CorruptusConscribo.Tests.ErrorCatching
{
    [TestFixture]
    public class When_Too_Many_Args : FailureTest<CompileException>
    {
        public When_Too_Many_Args() : base("param err", "./stage_9/invalid/too_many_args.c")
        {
        }
    }
}