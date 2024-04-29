using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _16._10._23_lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m, n;

            Console.WriteLine("Введите число строк:");
            m = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите число столбцов:");
            n = Convert.ToInt32(Console.ReadLine());

            int[,] a = new int[m, n];

            for (int i = 0; i < m; ++i)
            {
                Console.WriteLine("Введите элементы строки:");
                for (int j = 0; j < n; ++j)
                {
                    a[i, j] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine();
            }

            for (int j = 0; j < n; j++)
            {
                int maxEl = int.MinValue;

                for (int i = 0; i < m; i++)
                {
                    if (a[i, j] > maxEl && a[i, j] % 2 == 0) maxEl = a[i, j];
                }

                if (maxEl == int.MinValue) Console.WriteLine($"В столбце {j + 1} нет чётных элментов.");
                else Console.WriteLine($"Наибольший чётный элемент в столбце {j + 1} - {maxEl}.");
            }
        }
    }
}
