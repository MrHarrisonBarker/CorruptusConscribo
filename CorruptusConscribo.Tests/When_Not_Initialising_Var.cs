using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Not_Initialising_Var : CompilerTest
    {
        public When_Not_Initialising_Var() : base(0, "./stage_5/no_initialize.c", "./stage_5/")
        {
        }
    }
}