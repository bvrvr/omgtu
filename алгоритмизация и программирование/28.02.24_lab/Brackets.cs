using System;
using System.Collections.Generic;
using System.Linq;

namespace Brackets
{
    internal class Brackets
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();
            char[] openingBrackets = { '(', '{', '[' };
            char[] closingBrackets = { ')', '}', ']' };

            Console.WriteLine("Введите выражение: ");
            string expression = Console.ReadLine();

            foreach (char c in expression)
            {
                if (openingBrackets.Contains(c)) stack.Push(c);

                if (closingBrackets.Contains(c) && (stack.Count == 0 || openingBrackets[Array.IndexOf(closingBrackets, c)] != stack.Pop()))
                {
                    Console.WriteLine(false);

                    break;
                }
            }

            if (stack.Count == 0) Console.WriteLine(true);
            else Console.WriteLine(false);
        }
    }
}
