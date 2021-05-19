using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Forward_Decl_Global_Var : CompilerTest
    {
        public When_Forward_Decl_Global_Var() : base(3,"./stage_10/valid/forward_declaration.c","./stage_10/valid/") {}
    }
}