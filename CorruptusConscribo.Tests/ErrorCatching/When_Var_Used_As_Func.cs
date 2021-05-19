using NUnit.Framework;

namespace CorruptusConscribo.Tests.ErrorCatching
{
    [TestFixture]
    public class When_Var_Used_As_Func : FailureTest<CompileException>
    {
        public When_Var_Used_As_Func() : base("function is never defined or declared","./stage_10/invalid/variable_used_as_fun.c") {}
    }
}