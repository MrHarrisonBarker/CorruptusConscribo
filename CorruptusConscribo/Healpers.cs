using System;
using System.Diagnostics;
using System.IO;

namespace CorruptusConscribo
{
    public static class Healpers
    {
        public static string GetSource(string path)
        {
            return File.ReadAllText(path);
        }

        public static void WriteAsm(string filename, string source)
        {
            File.WriteAllText(filename,source);
        }

        public static void GenerateExecutable(string filename, string asmSource)
        {
            var command = $"gcc {asmSource} -o {filename}".Replace("\"", "\\\"");;
            
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
        }
    }
}