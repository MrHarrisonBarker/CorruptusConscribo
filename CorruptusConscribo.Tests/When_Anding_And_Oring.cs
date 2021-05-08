using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Anding_And_Oring : CompilerTest
    {
        public When_Anding_And_Oring() : base(0, "./stage_4/precedence_2.c", "./stage_4/", "int main() {return (1 || 0) && 0;")
        {
        }
    }
}