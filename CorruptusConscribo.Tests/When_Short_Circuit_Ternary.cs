using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Short_Circuit_Ternary : CompilerTest
    {
        public When_Short_Circuit_Ternary() : base(1, "./stage_6/expression/ternary_short_circuit.c", "./stage_6/expression/")
        {
        }
    }
}