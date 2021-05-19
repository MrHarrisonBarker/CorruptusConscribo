using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace CorruptusConscribo.Tests
{
    [TestFixture]
    public abstract class CompilerTest
    {
        private readonly string SourcePath;
        private readonly string OutputPath;
        private readonly string Source;
        private readonly List<Token> SourceTokens;
        private readonly int ReturnValue;

        protected CompilerTest(int returnValue, string sourcePath, string outputPath)
        {
            ReturnValue = returnValue;
            SourcePath = sourcePath;
            OutputPath = outputPath;
        }

        protected CompilerTest(int returnValue, string sourcePath, string outputPath, string source)
        {
            ReturnValue = returnValue;
            SourcePath = sourcePath;
            OutputPath = outputPath;
            Source = source;
        }

        protected CompilerTest(int returnValue, string sourcePath, string outputPath, string source, List<Token> tokens)
        {
            ReturnValue = returnValue;
            SourcePath = sourcePath;
            OutputPath = outputPath;
            Source = source;
            SourceTokens = tokens;
        }

        [Test]
        public async Task Should_Complete()
        {
            var asm = Healpers.Compile(SourcePath);

            var asmPath = OutputPath + "out.s";

            Healpers.WriteAsm(asmPath, asm);

            Console.WriteLine($"Assembly saved to {asmPath}");

            Healpers.GenerateExecutable(OutputPath + "program", asmPath).Should().Be(0);

            Healpers.RunExecutable(OutputPath + "program").Should().Be(ReturnValue);
        }
    }
}