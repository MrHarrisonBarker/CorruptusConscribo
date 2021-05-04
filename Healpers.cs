using System.IO;

namespace CorruptusConscribo
{
    public static class Healpers
    {
        public static string GetSource(string path)
        {
            return File.ReadAllText(path);
        }
    }
}