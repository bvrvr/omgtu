using System;
using System.IO;
using System.Linq;

namespace Sliyanie
{
    internal class Sliyanie
    {
        static void Main(string[] args)
        {
            string input1 = "input1.txt";
            string input2 = "input2.txt";
            string output = "output.txt";
            StreamWriter sw = new StreamWriter(output);

            int n = -1;

            foreach(var line1 in File.ReadLines(input1))
            {
                int mark1 = Convert.ToInt32(line1.Split(',')[3]);
                foreach (var line2 in File.ReadLines(input2).Skip(n+1))
                {
                    int mark2 = Convert.ToInt32(line2.Split(',')[3]);

                    if (mark1 < mark2)
                    {
                        sw.WriteLine(line1);
                        break;
                    }
                    else
                    {
                        sw.WriteLine(line2);
                        n++;
                    }
                }
            }

            foreach (var line2 in File.ReadLines(input2).Skip(n + 1))
            {
                sw.WriteLine(line2);
            }

            sw.Close();
        }
    }
}
