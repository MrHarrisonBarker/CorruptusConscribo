using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Breaking : CompilerTest
    {
        public When_Breaking() : base(15,"./stage_8/valid/break.c","./stage_8/valid/") {}
    }

    [TestFixture]
    public class When_Empty_Expression : CompilerTest
    {
        public When_Empty_Expression() : base(3,"./stage_8/valid/empty_expression.c","./stage_8/valid/") {}
    }
    
    [TestFixture]
    public class When_Nested_While : CompilerTest
    {
        public When_Nested_While() : base(65,"./stage_8/valid/nested_while.c","./stage_8/valid/") {}
    }
    
    [TestFixture]
    public class When_Continuing : CompilerTest
    {
        public When_Continuing() : base(-1,"./stage_8/valid/continue.c","./stage_8/valid/") {}
    }
}