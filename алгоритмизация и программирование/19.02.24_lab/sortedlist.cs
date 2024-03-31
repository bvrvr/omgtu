using System;
using System.Collections.Generic;

namespace _19._02._24_lab_sortedlist
{
    internal class sortedlist
    {
        class CreateSortedList
        {
            public SortedList<int, string> sortlist;

            public CreateSortedList()
            {
                sortlist = new SortedList<int, string>();

                Console.WriteLine("Введите количество элементов, которое хотите добавить: ");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Введите номер: ");
                    int k = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("Введите слово: ");
                    string l = Console.ReadLine();
                    sortlist.Add(k, l);
                    Console.Clear();
                }
            }
        }

        class Menu
        {
            public void Add(CreateSortedList sortlist)
            {
                Console.WriteLine("Введите номер: ");
                int k = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Введите слово: ");
                string l = Console.ReadLine();
                sortlist.sortlist.Add(k, l);
                Console.Clear();
                Console.WriteLine("Операция выполнена.");
                Console.WriteLine();
            }

            public void IndexOfKey(CreateSortedList sortlist)
            {
                Console.WriteLine("Введите номер: ");
                int key = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (sortlist.sortlist.IndexOfKey(key) < 0)
                {
                    Console.WriteLine("Такого номера нет.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Индекс ключа \"{0}\" - {1}.", key, sortlist.sortlist.IndexOfKey(key));
                    Console.WriteLine();
                }
            }

            public void IndexOfValue(CreateSortedList sortlist)
            {
                Console.WriteLine("Введите слово: ");
                string value = Console.ReadLine();
                Console.Clear();
                if (sortlist.sortlist.IndexOfValue(value) < 0)
                {
                    Console.WriteLine("Такого слова нет.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Индекс значения \"{0}\" - {1}.", value, sortlist.sortlist.IndexOfValue(value));
                    Console.WriteLine();
                }
            }

            public void Key(CreateSortedList sortlist)
            {
                Console.WriteLine("Введите индекс: ");
                int index = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (index >= 0 && index < sortlist.sortlist.Count)
                {
                    int key = sortlist.sortlist.Keys[index];
                    Console.WriteLine("Ключ с индексом {0} - {1}.", index, key);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Неверный индекс.");
                    Console.WriteLine();
                }
            }

            public void Value(CreateSortedList sortlist)
            {
                Console.WriteLine("Введите индекс: ");
                int index = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (index >= 0 && index < sortlist.sortlist.Count)
                {
                    string value = sortlist.sortlist.Values[index];
                    Console.WriteLine("Значение с индексом {0} - {1}.", index, value);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Неверный индекс.");
                    Console.WriteLine();
                }
            }

            public void Exit()
            {
                Console.Clear();
            }
            static void Main(string[] args)
            {
                CreateSortedList sortlist = new CreateSortedList();

                Menu menu = new Menu();

                while (true)
                {
                    Console.WriteLine("Выберите операцию:");
                    Console.WriteLine("1. Метод Add.");
                    Console.WriteLine("2. Метод IndexOfKey.");
                    Console.WriteLine("3. Метод IndexOfValue.");
                    Console.WriteLine("4. Вывод ключа по индексу.");
                    Console.WriteLine("5. Вывод значения по индексу.");
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
                            menu.Add(sortlist);
                            break;
                        case 2:
                            Console.Clear();
                            menu.IndexOfKey(sortlist);
                            break;
                        case 3:
                            Console.Clear();
                            menu.IndexOfValue(sortlist);
                            break;
                        case 4:
                            Console.Clear();
                            menu.Key(sortlist);
                            break;
                        case 5:
                            Console.Clear();
                            menu.Value(sortlist);
                            break;
                        case 6:
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
}
