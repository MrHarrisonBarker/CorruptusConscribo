using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    public abstract class FailureTest<T> where T : Exception
    {
        private readonly string SourcePath;
        private readonly string ExpectedMessage;
        protected FailureTest(string expectedMessage,string sourcePath)
        {
            ExpectedMessage = expectedMessage;
            SourcePath = sourcePath;
        }

        [Test]
        public async Task Should_Throw_Exception()
        {

            FluentActions.Invoking(() => Healpers.Compile(SourcePath)).Should().Throw<T>().WithMessage(ExpectedMessage);

            // try
            // {
            //     var asm = Healpers.Compile(SourcePath);
            //
            //     FU
            //     
            //     var asmPath = OutputPath + "out.s";
            //
            //     Healpers.WriteAsm(asmPath, asm);
            //
            //     Console.WriteLine($"Assembly saved to {asmPath}");
            //
            //     Healpers.GenerateExecutable(OutputPath + "program", asmPath);
            //
            //     Healpers.RunExecutable(OutputPath + "program");
            // }
            // catch (Exception e)
            // {
            //     e.Should().Be(Expected);
            // }
        }
    }
}