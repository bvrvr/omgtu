using System;
using System.Collections.Generic;
using System.Linq;

namespace _24._04._24_lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = new List<string> { "cat", "fish", "dolphin", "monkey", "hare", "elephant", "mouse", "turtle" };

            var evenLengthStrings = strings.Where(s => s.Length % 2 == 0).ToList();
            Console.WriteLine("Строки четной длины после первого запроса:");
            evenLengthStrings.ForEach(Console.WriteLine);

            for (int i = evenLengthStrings.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    evenLengthStrings.RemoveAt(i);
                }
            }

            var filteredAgain = evenLengthStrings.Where(s => s.Length % 2 == 0).ToList();
            Console.WriteLine("\nСтроки четной длины после второго запроса:");
            filteredAgain.ForEach(Console.WriteLine);
        }
    }
}
