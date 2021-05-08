using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Logically_Negating : CompilerTest
    {
        public When_Logically_Negating() : base(0, "./stage_2/not_five.c", "./stage_2/", "int main() {return !5;}")
        {
        }
    }
}