using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace Symbols_a
{
    internal class Symbols_a
    {
        static void Main(string[] args)
        {
            string input = "input.txt";

            Dictionary<string, int> dict = new Dictionary<string, int>();
            Regex regex = new Regex("a+");

            foreach (var line in File.ReadLines(input))
            {
                MatchCollection matches = regex.Matches(line);

                int min = (matches.Cast<Match>().Select(m => m.Value.Count())).Min();

                dict[line] = min;
            }

            int minLine = dict.Min(m => m.Value);

            foreach (string line in dict.Keys)
            {
                if (dict[line] == minLine) Console.WriteLine(line);
            }
        }
    }
}
