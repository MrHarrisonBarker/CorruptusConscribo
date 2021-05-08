using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Negating : CompilerTest
    {
        public When_Negating() : base(251, "./stage_2/neg.c", "./stage_2/", "int main() {return !5;}")
        {
        }
    }
}