using System;
using System.Text;

namespace TestAppSimCorp
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new FileProcessor();
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(processor.CalcWordOccurencesInFile("file.txt"));


            Console.ReadLine();
        }
    }
}
