using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Calling_With_Expression_Arg : CompilerTest
    {
        public When_Calling_With_Expression_Arg(): base(-1,"./stage_9/valid/expression_args.c","./stage_9/valid/") {}
    }
}