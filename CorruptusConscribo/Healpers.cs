using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace CorruptusConscribo
{
    public static class Healpers
    {
        private static Int64 FuncInc;
        private static Int64 BreakInc;
        private static Int64 ContinueInc;

        public static string GetFunctionId()
        {
            return $"_Func_{FuncInc++}";
        }

        public static string GetBreakPointId()
        {
            return $"_Break_{BreakInc++}";
        }

        public static string GetContinueId()
        {
            return $"_Continue_{ContinueInc++}";
        }

        public static string Compile(string sourcePath)
        {
            var source = Healpers.GetSource(sourcePath);
            Console.WriteLine($"The source code looks like this\n {source}");

            var lexResult = new Stack<Token>(new Lexicanum(source).Tokens);

            Console.WriteLine("Program has been lexed");

            var program = new Parser.Program(lexResult);

            Console.WriteLine($"Program parsed to AST\n {program}");

            if (!new Inquisition.Inquisition(program).IsClean()) throw new SyntaxException("HERESY !!");

            var asm = program.Template();

            Console.WriteLine($"Assembly generated\n{asm}");

            return asm;
        }

        public static string GetSource(string path)
        {
            return File.ReadAllText(path);
        }

        public static void WriteAsm(string filename, string source)
        {
            File.WriteAllText(filename, source);
        }

        public static int GenerateExecutable(string filename, string asmSource)
        {
            var command = $"gcc -m64 -g {asmSource} -o {filename}".Replace("\"", "\\\"");
            ;

            Console.WriteLine($"starting gcc with {command}");

            var gcc = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{command}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };

            gcc.Start();
            gcc.WaitForExit();

            Console.WriteLine($"gcc exited with exit code {gcc.ExitCode}");
            return gcc.ExitCode;
        }

        public static int RunExecutable(string path)
        {
            var command = $"{path}".Replace("\"", "\\\"");

            var exe = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{command}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };

            exe.Start();
            exe.WaitForExit();

            Console.WriteLine($"the executable exited with exit code {exe.ExitCode}");
            return exe.ExitCode;
        }
    }
}