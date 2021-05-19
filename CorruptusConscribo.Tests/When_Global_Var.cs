using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Global_Var : CompilerTest
    {
        public When_Global_Var() : base(12,"./stage_10/valid/global.c","./stage_10/valid/") {}
    }
    
    [TestFixture]
    public class When_Multiple_Global_Var : CompilerTest
    {
        public When_Multiple_Global_Var() : base(12,"./stage_10/valid/multiple_global.c","./stage_10/valid/") {}
    }
    
    [TestFixture]
    public class When_Forward_Decl_Global_Var : CompilerTest
    {
        public When_Forward_Decl_Global_Var() : base(3,"./stage_10/valid/forward_declaration.c","./stage_10/valid/") {}
    }
    
    [TestFixture]
    public class When_Var_Has_Same_Name_As_Func : CompilerTest
    {
        public When_Var_Has_Same_Name_As_Func() : base(5,"./stage_10/valid/fun_shadowed_by_variable.c","./stage_10/valid/") {}
    }
    
    [TestFixture]
    public class When_Global_Var_Not_Init : CompilerTest
    {
        public When_Global_Var_Not_Init() : base(3,"./stage_10/valid/global_not_initialized.c","./stage_10/valid/") {}
    }
}