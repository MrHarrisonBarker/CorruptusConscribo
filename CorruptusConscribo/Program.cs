using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CorruptusConscribo
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new[] {"./stage_9/valid/forward_decl.c"};

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

            try
            {
                var asm = Healpers.Compile(sourcePath);
                
                var asmPath = outputPath + "out.s";
                
                Healpers.WriteAsm(asmPath, asm);
                
                Console.WriteLine($"Assembly saved to {asmPath}");
                
                Healpers.GenerateExecutable(outputPath + "program", asmPath);
            }
            catch (SyntaxException syntaxException)
            {
                Console.WriteLine(syntaxException);
            }
            catch (CompileException compileException)
            {
                Console.WriteLine(compileException);
            }
        }
    }
}