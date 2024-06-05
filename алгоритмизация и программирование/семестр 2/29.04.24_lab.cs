using System;
using System.Linq;

namespace _29._04._24_lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 13, 26, 39, 45, 58, 67, 72, 84, 91 };

            var result1 = array.Where(x => (Math.Abs(x) % 10) % 3 == 0);

            Console.WriteLine("Элементы с последней цифрой, кратной 3:");
            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }

            var result2 = array.Where(x => x.ToString().Select(c => int.Parse(c.ToString())).Sum() % 2 == 0);

            Console.WriteLine("Элементы с чётной суммой цифр:");
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
