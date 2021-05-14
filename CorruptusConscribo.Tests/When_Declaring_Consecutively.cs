using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Declaring_Consecutively : CompilerTest
    {
        public When_Declaring_Consecutively() : base(3, "./stage_7/valid/consecutive_declarations.c", "./stage_7/valid/")
        {
        }
    }
}