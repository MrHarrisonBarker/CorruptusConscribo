using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Assigning : CompilerTest
    {
        public When_Assigning() : base(2, "./stage_5/assign.c", "./stage_5/")
        {
        }
    }
}