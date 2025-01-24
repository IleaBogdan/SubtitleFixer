using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace SubtitleFixer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Missing file!");
                return;
            }
            Console.WriteLine("Subtitle Program active. Press '?' for info or one of the following commands");
            Console.WriteLine("cd == Conversie Diacritice\nsc == Sincronizare subtitrare\nasd == Oprire Program");
            string input = "start";
            string filename = args[0];
            File.Copy(filename, filename + ".bak", true);
            string[] lines = File.ReadAllLines(filename,
                System.Text.Encoding.GetEncoding(1252));
            while (input != "asd")
            {
                input = Console.ReadLine();
                if (input == "?")
                {
                    Console.Clear();
                    Console.WriteLine("cd == Conversie Diacritice\nsc == Sincronizare subtitrare\nasd == Oprire Program");
                }
                else if (input == "cd")
                {
                    ConversieDiacritice.Conversion(lines, filename);
                }
                else if (input == "sc")
                {
                    Synchronizer.Synchronize(lines, filename);
                } else if (input !="asd")Console.WriteLine("Wrong input!");
                //Console.WriteLine(input);
            }
        }
    }
}
