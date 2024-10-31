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
            string input = "start";
            string filename = args[0];
            File.Copy(filename, filename + ".bak", true);
            string[] lines = File.ReadAllLines(filename,
                System.Text.Encoding.GetEncoding(1252));
            while (input != "stop")
            {
                input = Console.ReadLine();
                if (input == "?")
                {
                    Console.WriteLine("conv == Conversie Diacritice\nsync == Sincronizare subtitrare\nstop == Oprire Program");
                }
                if (input == "conv")
                {
                    ConversieDiacritice.Conversion(lines, filename);
                }
                if (input == "sync")
                {
                    Synchronizer.Synchronize(lines, filename);
                }
                //Console.WriteLine(input);
            }
        }
    }
}
