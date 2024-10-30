using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitleFixer
{
    internal class ConversieDiacritice
    {
        public static void Conversion(string[] lines, string filename){
            if (lines.Length == 0) { 
                Console.WriteLine("No line in source file!");
            }
            using (StreamWriter sw = new StreamWriter(File.Open(filename, FileMode.Create), Encoding.UTF8))
            {
                foreach (string line in lines)
                {
                    string new_line = line;
                    //replace diacritics in new_line
                    new_line = new_line.Replace('þ', 'ţ'); //t mic
                    new_line = new_line.Replace('Þ', 'Ț'); //t mare
                    new_line = new_line.Replace('º', 'ş'); //s mic
                    new_line = new_line.Replace('ª', 'Ş'); //s mare
                    // scriem in fisier linia modificata
                    sw.WriteLine(new_line);
                }
            }
        }
    }
}
