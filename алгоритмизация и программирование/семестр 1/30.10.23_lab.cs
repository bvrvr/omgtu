using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30._10._23_lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание 1

            int sum = 0;

            Console.WriteLine("Введите текст:");
            string s = Console.ReadLine();

            foreach (char ch in s)
            {
                if (char.IsDigit(ch) && ch % 2 == 0)
                {
                    sum++;
                }
            }

            if (sum == 0)
            {
                Console.WriteLine("В этом тексте нет чётных цифр.");
            }

            else
            {
                Console.WriteLine($"В этом тексте {sum} чётных цифр.");
            }

            //Задание 2

            Console.WriteLine("Введите текст:");
            string str = Console.ReadLine();

            string strWithoutSpaces = str.Replace(" ", "");

            string lowerStr = strWithoutSpaces.ToLower();

            char[] charStr = lowerStr.ToCharArray();
            Array.Reverse(charStr);

            string reversedStr = new string(charStr);

            if (lowerStr == reversedStr)
            {
                Console.WriteLine("Это палиндром.");
            }

            else
            {
                Console.WriteLine("Это не палиндром.");
            }
        }
    }
}
