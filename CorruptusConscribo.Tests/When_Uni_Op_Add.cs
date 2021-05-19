using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public class When_Uni_Op_Add : CompilerTest
    {
        public When_Uni_Op_Add() : base(0,"./stage_3/unop_add.c","./stage_3/") {}
    }
}