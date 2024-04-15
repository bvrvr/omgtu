using System;
using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();
            char[] openingBrackets = { '(', '{', '[' };
            char[] closingBrackets = { ')', '}', ']' };

            int count = 0;

            Console.WriteLine("Введите выражение: ");
            string expression = Console.ReadLine();

            foreach (char c in expression)
            {
                foreach (char b in openingBrackets)
                {
                    if (c == b)
                    {
                        stack.Push(c);
                    }
                }

                foreach (char b in closingBrackets)
                {
                    if (c == b)
                    {
                        if (stack.Count == 0 || openingBrackets[Array.IndexOf(closingBrackets, c)] != stack.Pop())
                        {
                            count = 1;
                        }
                    }
                }
            }

            if (count == 0)
            {
                Console.WriteLine(true);
            }

            else
            {
                Console.WriteLine(false);
            }
        }
    }
