using NUnit.Framework;

namespace CorruptusConscribo.Tests.ErrorCatching
{
    [TestFixture]
    public class When_Redefining_Param : FailureTest<SyntaxException>
    {
        public When_Redefining_Param() : base("invalid syntax: a variable called \"x\" already exists", "./stage_9/invalid/redefine_variable.c")
        {
        }
    }
}