using NUnit.Framework;

namespace CorruptusConscribo.Tests.ErrorCatching
{
    [TestFixture]
    public class When_Global_Init_Is_Invalid : FailureTest<CompileException>
    {
        public When_Global_Init_Is_Invalid() : base("that expression doesn't have an absolute value at compile time","./stage_10/invalid/non_constant_init.c") {}
    }
}