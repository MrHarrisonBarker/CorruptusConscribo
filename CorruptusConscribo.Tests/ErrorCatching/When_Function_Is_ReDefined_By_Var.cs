using NUnit.Framework;

namespace CorruptusConscribo.Tests.ErrorCatching
{
    [TestFixture]
    public class When_Function_Is_ReDefined_By_Var : FailureTest<CompileException>
    {
        public When_Function_Is_ReDefined_By_Var() : base("something called foo already exists!","./stage_10/invalid/fun_redefined_as_var.c") {}
    }
}