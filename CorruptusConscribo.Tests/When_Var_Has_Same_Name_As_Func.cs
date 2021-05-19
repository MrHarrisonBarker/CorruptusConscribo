using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Var_Has_Same_Name_As_Func : CompilerTest
    {
        public When_Var_Has_Same_Name_As_Func() : base(5,"./stage_10/valid/fun_shadowed_by_variable.c","./stage_10/valid/") {}
    }
}