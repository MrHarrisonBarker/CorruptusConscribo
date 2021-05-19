using NUnit.Framework;

namespace CorruptusConscribo.Tests.ErrorCatching
{
    [TestFixture]
    public class When_Global_Is_Defined_Multiple_Times : FailureTest<SyntaxException>
    {
        public When_Global_Is_Defined_Multiple_Times() : base("invalid syntax: global variable foo has already been defined","./stage_10/invalid/multiple_global_defs.c") {}
    }
}