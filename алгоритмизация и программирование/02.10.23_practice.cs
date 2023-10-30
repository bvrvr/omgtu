using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._10._23_practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0, minSum = 0, k = 2;
            int n;

            Console.WriteLine("Введите количество пар элементов:");
            n = Convert.ToInt32(Console.ReadLine());

            int[] pair = new int[k];
            int[] maxElements = new int[n];
            int[] minElements = new int[n];

            for (int i = 0; i < n; i++)
            {
                for (int e = 0; e < k; e++)
                {
                    Console.WriteLine("Введите элемент:");
                    pair[e] = Convert.ToInt32(Console.ReadLine());
                }

                maxElements[i] = Math.Max(pair[0], pair[1]);
                minElements[i] = Math.Min(pair[0], pair[1]);
            }

            foreach (int element in maxElements)
            {
                sum += element;
            }

            foreach (int element in minElements)
            {
                minSum += element;
            }

            if (sum % 3 == 0)
            {
                Console.WriteLine("Максимальная сумма элементов пар, кратная трём - {0}", sum);
            }

            else if (sum % 3 != 0)
            {
                int[] arr = new int[n];

                for (int i = 0; i < n; i++)
                {
                    int maxSum = sum - maxElements[i] + minElements[i];

                    if (maxSum % 3 == 0)
                    {
                        arr[i] = maxSum;
                    }
                }

                Console.WriteLine("Максимальная сумма элементов пар, кратная трём - {0}", arr.Max());
            }

            else if (sum % 3 != 0 && minSum % 3 == 0)
            {
                Console.WriteLine("Максимальная сумма элементов пар, кратная трём - {0}", minSum);
            }
        }
    }
}