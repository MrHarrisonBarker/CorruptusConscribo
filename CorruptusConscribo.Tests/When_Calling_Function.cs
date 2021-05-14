using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Calling_Function : CompilerTest
    {
        public When_Calling_Function(): base(3,"./stage_9/valid/no_arg.c","./stage_9/valid/") {}
    }
    
    [TestFixture]
    public class When_Calling_Fib : CompilerTest
    {
        public When_Calling_Fib(): base(-1,"./stage_9/valid/fib.c","./stage_9/valid/") {}
    }
    
    [TestFixture]
    public class When_Calling_With_Arg : CompilerTest
    {
        public When_Calling_With_Arg(): base(-1,"./stage_9/valid/single_arg.c","./stage_9/valid/") {}
    }
    
    [TestFixture]
    public class When_Calling_Multiple_Args : CompilerTest
    {
        public When_Calling_Multiple_Args(): base(-1,"./stage_9/valid/multi_arg.c","./stage_9/valid/") {}
    }
    
    [TestFixture]
    public class When_Calling_With_Var_Arg : CompilerTest
    {
        public When_Calling_With_Var_Arg(): base(-1,"./stage_9/valid/variable_as_arg.c","./stage_9/valid/") {}
    }
    
    [TestFixture]
    public class When_Calling_With_Expression_Arg : CompilerTest
    {
        public When_Calling_With_Expression_Arg(): base(-1,"./stage_9/valid/expression_args.c","./stage_9/valid/") {}
    }
    
    [TestFixture]
    public class When_Recursion : CompilerTest
    {
        public When_Recursion(): base(-1,"./stage_9/valid/mutual_recursion.c","./stage_9/valid/") {}
    }
    
    [TestFixture]
    public class When_Forward_Declaring : CompilerTest
    {
        public When_Forward_Declaring(): base(-1,"./stage_9/valid/forward_decl.c","./stage_9/valid/") {}
    }
    
    [TestFixture]
    public class When_Hello_World : CompilerTest
    {
        public When_Hello_World(): base(-1,"./stage_9/valid/hello_world.c","./stage_9/valid/") {}
    }
    
    [TestFixture]
    public class When_Function_Precedence : CompilerTest
    {
        public When_Function_Precedence(): base(-1,"./stage_9/valid/precedence.c","./stage_9/valid/") {}
    }
}