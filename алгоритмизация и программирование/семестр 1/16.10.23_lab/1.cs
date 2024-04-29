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
            int k = 0;

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
                int sum = 0, prod = 1;

                for (int i = 0; i < m; i++)
                {
                    sum += a[i, j];
                    prod *= a[i, j];
                }

                if (sum < 0 && prod > 0)
                {
                    k += 1;
                }
            }

            Console.WriteLine($"Количество столбцов, в которых сумма элементов меньше нуля, а произведение больше нуля - {k}.");
        }
    }
}
