using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_For : CompilerTest
    {
        public When_For() : base(3, "./stage_8/valid/for.c", "./stage_8/valid/")
        {
        }
    }
    
    [TestFixture]
    public class When_For_Empty : CompilerTest
    {
        public When_For_Empty() : base(4, "./stage_8/valid/for_empty.c", "./stage_8/valid/")
        {
        }
    }
    
    [TestFixture]
    public class When_For_Declare : CompilerTest
    {
        public When_For_Declare() : base(3, "./stage_8/valid/for_decl.c", "./stage_8/valid/")
        {
        }
    }
    
    [TestFixture]
    public class When_Do_While : CompilerTest
    {
        public When_Do_While() : base(16, "./stage_8/valid/do_while.c", "./stage_8/valid/")
        {
        }
    }
    
    [TestFixture]
    public class When_For_Nested : CompilerTest
    {
        public When_For_Nested() : base(3, "./stage_8/valid/for_nested_scope.c", "./stage_8/valid/")
        {
        }
    }
    
    [TestFixture]
    public class When_While : CompilerTest
    {
        public When_While() : base(6, "./stage_8/valid/while_single_statement.c", "./stage_8/valid/")
        {
        }
    }
}