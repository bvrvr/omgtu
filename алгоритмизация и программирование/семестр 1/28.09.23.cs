using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            //Задание 1

            int a, i, n;

            n = 0;

            for (i = 0; i < 10; i++)
            {
            Console.WriteLine("Введите число:");
            a = Convert.ToInt32(Console.ReadLine());
            if (a < 0) n += 1;
            }

            Console.WriteLine($"Количество отрицательных элементов: {n}.");

            //Задание 2

            int a, i, n;

            n = 0;

            for (i = 0; i < 10; i++)
            {
            Console.WriteLine("Введите число:");
            a = Convert.ToInt32(Console.ReadLine());
            if (a % 10 == 3) n += 1;
            }

            Console.WriteLine($"Количество элементов, оканчивающихся на 3: {n}.");

            //Задание 3

            int a, i, n;

            n = 0;

            for (i = 0; i < 10; i++)
            {
            Console.WriteLine("Введите число:");
            a = Convert.ToInt32(Console.ReadLine());
            if (a % 3 == a % 5) n += a;
            }

            Console.WriteLine($"Сумма элементов, которые в троичной и пятиричной системе одинаковы: {n}.");

            //Задание 4

            int a, i, n;

            n = 1;

            for (i = 0; i < 10; i++)
            {
            Console.WriteLine("Введите число:");
            a = Convert.ToInt32(Console.ReadLine());

            if (a % 2 == 0 && a >= 0) n *= a;
            }

            Console.WriteLine($"Произведение неотрицательных чётных элементов: {n}.");

            //Задание 5

            int a, b, n, i, amount;

            amount = 0;

            Console.WriteLine("Введите количество чисел:");
            n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите число:");
            a = Convert.ToInt32(Console.ReadLine());

            for (i = 1; i < n; i++)
            {
            Console.WriteLine("Введите число:");
            b = Convert.ToInt32(Console.ReadLine());

            if (b < a) amount += 1;

            a = b;
            }

            Console.WriteLine($"Количество элементов, значения которых меньше предыдущего: {amount}.");

            //Задание 6

            int amount, previousEl, n, i, El;
            bool firstEl;

            amount = 0;
            previousEl = int.MaxValue;

            firstEl = true;

            Console.WriteLine("Введите количество чисел:");
            n = Convert.ToInt32(Console.ReadLine());

            for (i = 0; i < n; i++)
            {
            Console.WriteLine("Введите число:");
            El = Convert.ToInt32(Console.ReadLine());

            if (firstEl)
            {
            firstEl = false;
            previousEl = El;
            }

            else if (El < previousEl)
            {
            previousEl = El;
            amount++;
            }
            }

            Console.WriteLine($"Количество элементов, значения которых меньше всех предыдущих: {amount}.");

            //Задание 7

            int a, b, i, n, amount;

            amount = 0;

            Console.WriteLine("Введите количество чисел:");
            n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите число:");
            a = Convert.ToInt32(Console.ReadLine());

            for (i = 1; i < n; i++)
            {
                Console.WriteLine("Введите число:");
                b = Convert.ToInt32(Console.ReadLine());

                if (a * b < 0) amount += 1;

                a = b;
            }

            Console.WriteLine($"Количество сменных знаков последовательности: {amount}.");
        }
    }
}
