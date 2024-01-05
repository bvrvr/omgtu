using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27._11._23_practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            int n = Convert.ToInt32(Console.ReadLine());

            int minADiff = Int32.MaxValue;
            int aDiff = 0;
            int sumA = 0;
            int sumB = 0;
            int minSumB = 0;
            int minSumA = 0;

            for (int i = 0; i < n; i++)
            {
                string[] pair = Console.ReadLine().Split(' ');

                int a = Convert.ToInt32(pair[0]);
                int b = Convert.ToInt32(pair[1]);

                aDiff += (a - b);
                sumA += a;
                minSumB += b;
                sumB += b;

                if (aDiff < minADiff)
                {
                    minADiff = aDiff;
                    minSumB = 0;
                    minSumA = sumA;
                }
            }

            int minPath = (minSumA + minSumB + t) > (sumB + t) ? (sumB + t) : (minSumA + minSumB + t);

            Console.WriteLine(minPath);
        }
    }
}
