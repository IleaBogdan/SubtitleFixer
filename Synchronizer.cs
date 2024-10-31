using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitleFixer
{
    internal class Synchronizer
    {
        private static double ConvertTime(string time)
        {
            double rezult=0.0;
            int x = 3600;
            string[] splitter = time.Split(':', ',');
            for (int i=0; i<splitter.Length-1; i++)
            {
                rezult += x * Convert.ToDouble(splitter[i]);
                x /= 60;
            }
            return rezult+Convert.ToDouble(splitter[splitter.Length-1])/1000.0;
        }
        private static string DeConvertTime(double time)
        {
            int timeFixer = Convert.ToInt32(time);
            time-=timeFixer;
            string converter=Convert.ToString(timeFixer / 3600), rezult=(converter.Length>1 ? converter : "0"+converter)+":";
            timeFixer %= 60;
            converter = Convert.ToString(timeFixer / 60);
            rezult += (converter.Length > 1 ? converter : "0" + converter) + ":";
            timeFixer %= 60;
            converter = Convert.ToString(timeFixer);
            rezult += (converter.Length > 1 ? converter : "0" + converter) + ",";
            timeFixer = Convert.ToInt32(time * 1000);
            return rezult+ Convert.ToString(timeFixer);
        }
        public static void Synchronize(string[] lines, string filename)
        {
            if (lines.Length == 0)
            {
                Console.WriteLine("No lines in source file!");
                return;
            }
            Console.WriteLine("enter seconds number to sync (- for faster and with + for slower):");
            string input=Console.ReadLine();
            double numb;
            if (double.TryParse(input, out numb))
            {
                using (StreamWriter sw = new StreamWriter(File.Open(filename, FileMode.Create), Encoding.UTF8))
                {
                    foreach (string line in lines)
                    {
                        string new_line = line;
                        if (line.Contains("-->"))
                        {
                            Console.WriteLine($"{new_line}");
                            new_line = "";
                            string[] splitter=line.Split(new string[] { "--> " }, StringSplitOptions.None);
                            foreach (string splitted in splitter){
                                double time = ConvertTime(splitted);
                                time += numb;
                                new_line += DeConvertTime(time);
                                new_line += " --> ";
                            }
                            new_line=new_line.Remove(new_line.Length - 4);
                            Console.WriteLine($"{new_line}");
                        }
                        sw.WriteLine(new_line);
                    }
                }
            }
            else
            {
                Console.WriteLine("Failed to sync");
                return;
            }
            Console.WriteLine("Sincronizare Terminata!");
        }
    }
}
