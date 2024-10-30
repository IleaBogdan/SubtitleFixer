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
            string input="start", filename=args[0];
            File.Copy(filename, filename + ".bak", true);
            string[] lines= File.ReadAllLines(filename,
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
                    Console.WriteLine("Conversie Diacritice!");
                    ConversieDiacritice.Conversion(lines, filename);
                    Console.WriteLine("Terminare Conversie!");
                }
                if (input == "sync")
                {
                    Console.WriteLine("Sincronizare!");

                    Console.WriteLine("Sincronizare Terminata!");
                }
                //Console.WriteLine(input);
            }
        }
    }
}
