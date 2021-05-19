using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Global_Var_Not_Init : CompilerTest
    {
        public When_Global_Var_Not_Init() : base(3,"./stage_10/valid/global_not_initialized.c","./stage_10/valid/") {}
    }
}