using System;
using System.IO;
using System.Text;

namespace Cat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Begin: Cat");

            var shell = new Shell(@"D:\programming\CSharpResearch\ConsoleSample\ConsoleSample\FileService");
            shell.Cat("FileProcessingService.cs", 25, Encoding.GetEncoding("shift_jis"));

            Console.WriteLine("End: Cat");
            Console.ReadKey();
        }
    }

    public class Shell
    {
        public static readonly int DefaultCount = 10;
        public string Dir { get; private set; }

        public Shell(string dir)
        {
            if (!Directory.Exists(dir))
            {
                throw new ArgumentException($"Directory \"{dir}\" does not exist.");
            }
            this.Dir = dir;
        }

        public void Cat(string fileName, int count)
        {
            Cat(fileName, count, Encoding.UTF8);
        }
        public void Cat(string fileName, int count, Encoding enc)
        {
            string path = Path.Combine(this.Dir, fileName);
            if (!File.Exists(path))
            {
                Console.WriteLine($"File \"{path}\" does not exist.");
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