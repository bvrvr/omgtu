using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._10._23_practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int K = Convert.ToInt32(Console.ReadLine());
            int M = Convert.ToInt32(Console.ReadLine());
            int white = Convert.ToInt32(Console.ReadLine());

            int[] mice = new int[K];
            for (int i = 0; i < K; i++)
            {
                mice[i] = 0;
            }

            int pointer = 0;
            mice[pointer] = 1;

            while (mice.Count(c => c == 0) > 0)
            {
                int moved = 0;

                while (moved != M)
                {
                    ++pointer;

                    if (pointer > K - 1)
                    {
                        pointer = 0;
                    }

                    if (mice[pointer] == 0)
                    {
                        ++moved;
                    }
                }

                mice[pointer] = 1;
            }

            int difference = pointer - white;
            int answer = (K - difference) % K;

            Console.WriteLine("Ответ: {0}", answer);
        }
    }
}
