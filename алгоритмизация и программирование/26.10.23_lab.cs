using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26._10._23_lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, amount;

            Console.WriteLine("Введите количество множеств:");
            n = Convert.ToInt32(Console.ReadLine());

            int[][] nums = new int[n][];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите количество элеметов в множестве {i + 1}:");
                amount = Convert.ToInt32(Console.ReadLine());

                nums[i] = new int[amount];

                for (int j = 0; j < amount; j++)
                {
                    Console.WriteLine($"Введите элемент, входящий в множество {i + 1}:");

                    nums[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine();

            // пересечение множеств
            int[] set1 = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                int[] currentSet1 = nums[i];
                int[] intersection = new int[Math.Min(set1.Length, currentSet1.Length)];
                int currentIndex1 = 0;

                foreach (var element in set1)
                {
                    if (Array.IndexOf(currentSet1, element) != -1)
                    {
                        intersection[currentIndex1++] = element;
                    }
                }

                Array.Resize(ref intersection, currentIndex1);
                set1 = intersection;
            }

            // объединение множеств
            int totalLength = 0;
            foreach (var set in nums)
            {
                totalLength += set.Length;
            }

            int[] union = new int[totalLength];
            int currentIndex2 = 0;

            foreach (var set in nums)
            {
                foreach (var element in set)
                {
                    bool alreadyInUnion = false;
                    for (int i = 0; i < currentIndex2; i++)
                    {
                        if (union[i] == element)
                        {
                            alreadyInUnion = true;
                            break;
                        }
                    }

                    if (!alreadyInUnion)
                    {
                        union[currentIndex2++] = element;
                    }
                }
            }

            Array.Resize(ref union, currentIndex2);

            // дополнение относительно объединения
            int[][] complements = new int[nums.Length][];
            for (int i = 0; i < nums.Length; i++)
            {
                int[] currentSet3 = nums[i];
                int[] complement = new int[union.Length];
                int complementIndex = 0;

                foreach (var element in union)
                {
                    if (Array.IndexOf(currentSet3, element) == -1)
                    {
                        complement[complementIndex++] = element;
                    }
                }

                Array.Resize(ref complement, complementIndex);
                complements[i] = complement;
            }

            Console.WriteLine($"Пересечение множеств сожержит следующие элементы: {string.Join(", ", set1)}");
            Console.WriteLine($"Объединение множеств сожержит следующие элементы: {string.Join(", ", union)}");
            Console.WriteLine("Дополнение для каждого множества относительно объединения:");
            for (int i = 0; i < complements.Length; i++)
            {
                Console.WriteLine($"Множество {i + 1}: {string.Join(", ", complements[i])}");
            }
        }
    }
}
