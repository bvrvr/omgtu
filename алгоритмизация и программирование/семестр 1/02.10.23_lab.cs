using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._10._23_lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 1

            int n, b1, c1;
            int b = 1, c = int.MaxValue, amount = 0;

            Console.WriteLine("Введите количество элементов:");
            n = Convert.ToInt32(Console.ReadLine());

            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите число:");
                a[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                c1 = c;
                b1 = b;
                while (c1 != 3 && c1 != 0)
                {
                    c1 = a[i] % (10 * b1) / b1;
                    b1 *= 10;
                    if (c1 == 3) amount++;
                }
            }
            Console.WriteLine($"Количесвто элементов, у которых имеется хотя бы одна цифра 3 - {amount}");

            // Задание 2

            int n;
            int b = int.MaxValue;

            Console.WriteLine("Введите количество элементов:");
            n = Convert.ToInt32(Console.ReadLine());

            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите число:");
                a[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                if (a[i] % 2 != 0 && a[i] < b) b = a[i];
            }
            if (b == int.MaxValue) Console.WriteLine("Наименьшего нечётного элемента не сущетсвует.");
            else
            {
                Console.WriteLine($"Наименьший нечётный элемент - {b}");
            }

            // Задание 3

            int n;
            int amount = 0;

            Console.WriteLine("Введите количество элементов:");
            n = Convert.ToInt32(Console.ReadLine());

            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите число:");
                a[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                if (a[i] % 3 == a[i] % 5 && a[i] % 3 == a[i] % 15 & a[i] % 5 == a[i] % 15) amount++;
            }
            Console.WriteLine($"Количество элементов, которые в 3-, 5- и 15-ричной системе счисления оканчиваются одинаково - {amount}");
        }
    }
}
