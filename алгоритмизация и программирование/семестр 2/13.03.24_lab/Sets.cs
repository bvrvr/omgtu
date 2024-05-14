using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sets
{
    internal class Program
    {
        class HashSetDemo
        {
            static void Show(string msg, HashSet<int> set)
            {
                Console.Write(msg);
                foreach (int el in set)
                    Console.Write(el + " ");
                Console.WriteLine();
            }

            static void Main(string[] args)
            {
                HashSet<int> uniSet = new HashSet<int>();
                HashSet<int> firstSet = new HashSet<int>();
                HashSet<int> secondSet = new HashSet<int>();
                HashSet<int> thirdSet = new HashSet<int>();
                HashSet<int> set = new HashSet<int>();

                uniSet.Add(1);
                uniSet.Add(2);
                uniSet.Add(3);
                uniSet.Add(4);
                uniSet.Add(5);
                uniSet.Add(6);

                firstSet.Add(1);
                firstSet.Add(3);
                firstSet.Add(2);

                secondSet.Add(6);
                secondSet.Add(4);
                secondSet.Add(2);

                thirdSet.Add(3);
                thirdSet.Add(1);
                thirdSet.Add(5);

                set = new HashSet<int>(firstSet);
                set.UnionWith(secondSet);
                Show("Содержимое множества firstSet после объединения со множеством secondSet: ", set);

                set = new HashSet<int>(firstSet);
                set.UnionWith(thirdSet);
                Show("Содержимое множества firstSet после объединения со множеством thirdSet: ", set);

                set = new HashSet<int>(secondSet);
                set.UnionWith(thirdSet);
                Show("Содержимое множества secondSet после объединения со множеством thirdSet: ", set);

                set = new HashSet<int>(firstSet);
                set.IntersectWith(secondSet);
                Show("Содержимое множества firstSet после пересечения со множеством secondSet: ", set);

                set = new HashSet<int>(firstSet);
                set.IntersectWith(thirdSet);
                Show("Содержимое множества firstSet после пересечения со множеством thirdSet: ", set);

                set = new HashSet<int>(secondSet);
                set.IntersectWith(thirdSet);
                Show("Содержимое множества secondSet после пересечения со множеством thirdSet: ", set);

                set = new HashSet<int>(uniSet);
                set.ExceptWith(firstSet);
                Show("Дополнение множества firstSet: ", set);

                set = new HashSet<int>(uniSet);
                set.ExceptWith(secondSet);
                Show("Дополнение множества secondSet: ", set);

                set = new HashSet<int>(uniSet);
                set.ExceptWith(thirdSet);
                Show("Дополнение множества thirdSet: ", set);
            }
        }
    }
}