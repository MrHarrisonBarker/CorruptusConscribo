using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class WhenUsingMultipleVars : CompilerTest
    {
        public WhenUsingMultipleVars() : base(3, "./stage_5/multiple_vars.c", "./stage_5/")
        {
        }
    }
}