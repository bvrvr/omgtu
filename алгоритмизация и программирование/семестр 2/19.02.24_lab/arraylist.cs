using System;
using System.Collections;

namespace _19._02._24_lab_arraylist
{
    internal class arraylist
    {
        class CreateArrayList
        {
            public ArrayList arrlist;

            public CreateArrayList()
            {
                arrlist = new ArrayList();

                Console.WriteLine("Введите количество элементов, которое хотите добавить: ");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Введите элемент:");
                    int k = Convert.ToInt32(Console.ReadLine());
                    arrlist.Add(k);
                    Console.Clear();
                }
            }
        }

        class Menu
        {
            public void Count(CreateArrayList arrlist)
            {
                Console.WriteLine($"Результат реализации метода Count: {arrlist.arrlist.Count}");
                Console.WriteLine();
            }

            public void BinSearch(CreateArrayList arrlist)
            {
                Console.Clear();
                Console.WriteLine("Введите число, индекс которого вы хотите найти:");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                int index = arrlist.arrlist.BinarySearch(n);

                if (index < 0)
                {
                    Console.WriteLine("Этого элемента нет в данном массиве.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Результат выполнения метода BinSearch: {index}");
                    Console.WriteLine();
                }
            }

            public void Copy(CreateArrayList arrlist)
            {
                int[] array = new int[arrlist.arrlist.Count];
                arrlist.arrlist.CopyTo(array);

                Console.WriteLine("Метод Copy выполнен.");
                Console.WriteLine();
            }

            public void IndexOf(CreateArrayList arrlist)
            {
                Console.WriteLine("Введите число, индекс которого вы хотите найти:");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                int index = arrlist.arrlist.IndexOf(n);

                if (index < 0)
                {
                    Console.WriteLine("Этого элемента нет в данном массиве.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Результат выполнения метода IndexOf: {index}");
                    Console.WriteLine();
                }
            }

            public void Insert(CreateArrayList arrlist)
            {
                Console.WriteLine("Введите индекс, куда вы хотите добавить число:");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                Console.WriteLine("Введите число, которое вы хотите добавить:");
                int el = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                arrlist.arrlist.Insert(n, el);

                Console.WriteLine("Метод Insert выполнен.");
                Console.WriteLine();
            }
            public void Reverse(CreateArrayList arrlist)
            {
                arrlist.arrlist.Reverse();

                Console.WriteLine("Метод Reverse выполнен.");
                Console.WriteLine();
            }

            public void Sort(CreateArrayList arrlist)
            {
                arrlist.arrlist.Sort();

                Console.WriteLine("Метод Sort выполнен.");
                Console.WriteLine();
            }

            public void Add(CreateArrayList arrlist)
            {
                Console.WriteLine("Введите число, которое вы хотите добавить:");
                int el = Convert.ToInt32(Console.ReadLine());
                arrlist.arrlist.Add(el);
                Console.Clear();

                Console.WriteLine("Метод Add выполнен.");
                Console.WriteLine();
            }
            public void Exit()
            {
                Console.Clear();
            }
        }
        static void Main(string[] args)
        {
            CreateArrayList arrlist = new CreateArrayList();

            bool sorted = false;

            Menu menu = new Menu();

            while (true)
            {
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1. Метод Count.");
                Console.WriteLine("2. Метод BinSearch.");
                Console.WriteLine("3. Метод Copy.");
                Console.WriteLine("4. Метод IndexOf.");
                Console.WriteLine("5. Метод Insert.");
                Console.WriteLine("6. Метод Reverse.");
                Console.WriteLine("7. Метод Sort.");
                Console.WriteLine("8. Метод Add.");
                Console.WriteLine("9. Выход.");
                Console.WriteLine();

                string choiceString = Console.ReadLine();
                if (!int.TryParse(choiceString, out int choice))
                {
                    Console.Clear();
                    Console.WriteLine($"Некорректный ввод. Пожалуйста, введите целое число.\n");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        menu.Count(arrlist);
                        break;
                    case 2:
                        if (sorted)
                        {
                            menu.BinSearch(arrlist);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Сначала нужно отсортировать массив.");
                            Console.WriteLine();
                        }
                        break;
                    case 3:
                        Console.Clear();
                        menu.Copy(arrlist);
                        break;
                    case 4:
                        Console.Clear();
                        menu.IndexOf(arrlist);
                        break;
                    case 5:
                        Console.Clear();
                        menu.Insert(arrlist);
                        sorted = false;
                        break;
                    case 6:
                        Console.Clear();
                        menu.Reverse(arrlist);
                        sorted = false;
                        break;
                    case 7:
                        Console.Clear();
                        menu.Sort(arrlist);
                        sorted = true;
                        break;
                    case 8:
                        Console.Clear();
                        menu.Add(arrlist);
                        sorted = false;
                        break;
                    case 9:
                        menu.Exit();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Некорректный выбор. Пожалуйста, выберите существующую операцию.\n");
                        break;
                }
            }
        }
    }
}
