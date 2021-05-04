using System;
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
            var lexResult = new Lexicanum(source).Tokens;
        }

        
    }
}
