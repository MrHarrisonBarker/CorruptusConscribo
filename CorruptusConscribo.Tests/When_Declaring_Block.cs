using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Declaring_Block : CompilerTest
    {
        public When_Declaring_Block() : base(0, "./stage_7/valid/declare_block.c", "./stage_7/valid/")
        {
        }
    }

    [TestFixture]
    public class When_Declaring_After_Block : CompilerTest
    {
        public When_Declaring_After_Block() : base(3, "./stage_7/valid/declare_after_block.c", "./stage_7/valid/")
        {
        }
    }

    [TestFixture]
    public class When_Declaring_Late : CompilerTest
    {
        public When_Declaring_Late() : base(3, "./stage_7/valid/declare_late.c", "./stage_7/valid/")
        {
        }
    }

    [TestFixture]
    public class When_Nested_Scope : CompilerTest
    {
        public When_Nested_Scope() : base(4, "./stage_7/valid/nested_scope.c", "./stage_7/valid/")
        {
        }
    }

    [TestFixture]
    public class When_Declaring_Consecutively : CompilerTest
    {
        public When_Declaring_Consecutively() : base(3, "./stage_7/valid/consecutive_declarations.c", "./stage_7/valid/")
        {
        }
    }
    
    [TestFixture]
    public class When_Nesting_Ifs : CompilerTest
    {
        public When_Nesting_Ifs() : base(4, "./stage_7/valid/nested_if.c", "./stage_7/valid/")
        {
        }
    }
    
    [TestFixture]
    public class When_Multi_Nesting : CompilerTest
    {
        public When_Multi_Nesting() : base(3, "./stage_7/valid/multi_nesting.c", "./stage_7/valid/")
        {
        }
    }
}