using System;
using System.IO;
using System.Text;

namespace Cat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var shell = new Shell(@"D:\programming\CSharpResearch\ConsoleSample\ConsoleSample\FileService");
            shell.Cat("FileProcessingService.cs", -1, Encoding.GetEncoding("shift_jis"));

            Console.ReadKey();
        }
    }

    public class Shell
    {
        public static readonly int DefaultCount = 10;
        public string Dir { get; private set; }

        public Shell(string dir)
        {
            this.Dir = dir;
        }

        public void Cat(string file, int count)
        {
            Cat(file, count, Encoding.UTF8);
        }
        public void Cat(string file, int count, Encoding enc)
        {
            string path = Path.Combine(this.Dir, file);
            if (!File.Exists(path))
            {
                Console.WriteLine($"File {path} does not exist.");
                return;
            }
            int maxLine = (0 < count) ? count : DefaultCount;

            try
            {
                using(var sr = new StreamReader(path, enc ?? Encoding.UTF8))
                {
                    int lineNumber = 1;
                    while (!sr.EndOfStream)
                    {
                        if (maxLine < lineNumber)
                        {
                            return;
                        }
                        
                        Console.WriteLine($"[{lineNumber:0000}] {sr.ReadLine()}");
                        lineNumber++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}