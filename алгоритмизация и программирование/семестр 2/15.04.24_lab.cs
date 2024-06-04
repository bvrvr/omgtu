using System;
using System.IO;
using System.Collections.Generic;

namespace _15._04._24_lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "input.txt";

            Dictionary<char, int> frequency = new Dictionary<char, int>();
            HashSet<char> Characters = new HashSet<char>();
            HashSet<char> unicCharacters = new HashSet<char>();

            using (StreamReader reader = new StreamReader(input))
            {
                while (!reader.EndOfStream)
                {
                    char[] buffer = new char[1];
                    reader.Read(buffer, 0, 1);
                    char ch = buffer[0];

                    if (char.IsLetter(ch))
                    {
                        if (frequency.ContainsKey(ch))
                        {
                            frequency[ch]++;
                        }
                        else
                        {
                            frequency[ch] = 1;
                            Characters.Add(ch);
                        }
                    }
                    else
                    {
                        unicCharacters.Add(ch);
                    }
                }
            }

            char mostFrequentChar = '\0';
            int maxFrequency = 0;

            foreach (var kvp in frequency)
            {
                if (kvp.Value > maxFrequency)
                {
                    mostFrequentChar = kvp.Key;
                    maxFrequency = kvp.Value;
                }
            }

            int Count = unicCharacters.Count;

            List<char> sortedCharacters = new List<char>(Characters);
            sortedCharacters.Sort();

            Console.WriteLine($"Символ, который встречается чаще всего: {mostFrequentChar}");
            Console.WriteLine($"Количество уникальных символов: {Count}");
            Console.Write("Список символов в алфавитном порядке: ");
            foreach (char ch in sortedCharacters)
            {
                Console.Write(ch + " ");
            }
        }
    }
}
