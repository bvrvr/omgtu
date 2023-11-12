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
            int p = 0;

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

            for (int i = 0; i < m - 1; i++)
            {
                for (int k = i + 1; k < m; k++)
                {
                    bool areEqual = true;

                    for (int j = 0; j < n; j++)
                    {
                        if (a[i, j] != a[k, j])
                        {
                            areEqual = false;
                            break;
                        }
                    }

                    if (areEqual)
                    {
                        p += 1;
                    }
                }
            }

            Console.WriteLine(p);
        }
    }
}
