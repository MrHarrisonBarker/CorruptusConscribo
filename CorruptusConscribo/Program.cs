using System;
using System.Collections.Generic;
using System.Linq;

namespace CorruptusConscribo
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new[] {"./TestPrograms/precedence.c"};

            string sourcePath;
            string outputPath;

            if (args.Length != 0)
            {
                if (args.Length == 1)
                {
                    sourcePath = args[0];
                    var pathSplit = args[0].Split("/");
                    pathSplit[^1] = null;
                    outputPath = String.Join("/", pathSplit);
                }
                else if (args.Length == 2)
                {
                    sourcePath = args[0];
                    outputPath = args[1];
                }
                else
                {
                    Console.WriteLine("Not enough arguments");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Not enough arguments");
                return;
            }

            var source = Healpers.GetSource(sourcePath);
            Console.WriteLine($"The source code looks like this\n {source}");

            var lexResult = new Queue<Token>(new Lexicanum(source).Tokens);

            Console.WriteLine("Program has been lexed");

            var program = new Parser.Program(lexResult);

            Console.WriteLine($"Program parsed to AST\n {program.ToString()}");
            
            // var asm = program.Template();
            
            // Console.WriteLine($"Assembly generated\n{asm}");
            //
            // var asmPath = outputPath + "out.s";
            //
            // Healpers.WriteAsm(asmPath, asm);
            //
            // Console.WriteLine($"Assembly saved to {asmPath}");
            //
            // Healpers.GenerateExecutable(outputPath + "program", asmPath);
        }
    }
}