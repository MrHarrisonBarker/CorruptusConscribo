using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Declaring_Late : CompilerTest
    {
        public When_Declaring_Late() : base(3, "./stage_7/valid/declare_late.c", "./stage_7/valid/")
        {
        }
    }
}