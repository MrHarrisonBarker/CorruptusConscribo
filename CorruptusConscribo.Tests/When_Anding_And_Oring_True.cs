using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Anding_And_Oring_True : CompilerTest
    {
        public When_Anding_And_Oring_True() : base(1, "./stage_4/precedence_true.c", "./stage_4/", "int main() {return 1 || 0 && 2;")
        {
        }
    }
}