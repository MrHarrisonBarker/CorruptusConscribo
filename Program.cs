using System;
using System.Collections.Generic;
using System.IO;

namespace CorruptusConscribo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var source = Healpers.GetSource("./TestPrograms/return_69.c");
            Console.WriteLine($"The source code looks like this\n {source}");
            var lexResult = new Queue<Token>(new Lexicanum(source).Tokens);
            var program = new Parser.Program(lexResult);
            Console.WriteLine($"Program parsed to AST");
        }
    }
}