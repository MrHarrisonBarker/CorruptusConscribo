using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Assigning_Vars_To_Vars : CompilerTest
    {
        public When_Assigning_Vars_To_Vars() : base(2, "./stage_5/assign_var.c", "./stage_5/")
        {
        }
    }
}