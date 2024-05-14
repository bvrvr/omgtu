using System;
using System.Linq;

namespace _19._02._24_lab
{
    internal class Program
    {
        class CreateArray
        {
            public int[] array;

            public CreateArray()
            {
                Console.WriteLine("Введите размер массива: ");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                array = new int[n];

                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine("Введите элемент массива: ");
                    array[i] = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                }
            }
        }

        class Menu
        {
            public void Count(CreateArray array)
            {
                Console.WriteLine($"Результат реализации метода Count: {array.array.Count()}");
                Console.WriteLine();
            }

            public void BinSearch(CreateArray array)
            {
                Console.Clear();
                Console.WriteLine("Введите число, индекс которого вы хотите найти:");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                int index = Array.BinarySearch(array.array, n);

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

            public void Copy(CreateArray array)
            {
                int[] array2 = new int[array.array.Length];
                Array.Copy(array.array, array2, array.array.Length);

                Console.WriteLine("Метод Copy выполнен.");
                Console.WriteLine();
            }

            public void Find(CreateArray array)
            {
                int res = Array.Find(array.array, el => el >= 10);

                if (res == 0)
                {
                    Console.WriteLine("Элемента, большего или равного десяти нет в данном массиве.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Результат выполнения метода Find: {res}");
                    Console.WriteLine();
                }
            }

            public void FindLast(CreateArray array)
            {
                int res = Array.FindLast(array.array, el => el >= 10);

                if (res == 0)
                {
                    Console.WriteLine("Элемента, большего или равного десяти нет в данном массиве.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Результат выполнения метода FindLast: {res}");
                    Console.WriteLine();
                }
            }

            public void IndexOf(CreateArray array)
            {
                Console.WriteLine("Введите число, индекс которого вы хотите найти:");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                int index = Array.IndexOf(array.array, n);

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

            public void Reverse(CreateArray array)
            {
                Array.Reverse(array.array);

                Console.WriteLine("Метод Reverse выполнен.");
                Console.WriteLine();
            }

            public void Resize(CreateArray array)
            {
                Console.Clear();
                Console.WriteLine("На сколько элементов вы хотите изменить массив?");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                Array.Resize<int>(ref array.array, array.array.Length + n);

                Console.WriteLine("Метод Resize выполнен.");
                Console.WriteLine();
            }

            public void Sort(CreateArray array)
            {
                Array.Sort(array.array);

                Console.WriteLine("Метод Sort выполнен.");
                Console.WriteLine();
            }

            public void Exit()
            {
                Console.Clear();
            }
        }

        static void Main(string[] args)
        {
            CreateArray array = new CreateArray();

            bool sorted = false;

            Menu menu = new Menu();

            while (true)
            {
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1. Метод Count.");
                Console.WriteLine("2. Метод BinSearch.");
                Console.WriteLine("3. Метод Copy.");
                Console.WriteLine("4. Метод Find.");
                Console.WriteLine("5. Метод FindLast.");
                Console.WriteLine("6. Метод IndexOf.");
                Console.WriteLine("7. Метод Reverse.");
                Console.WriteLine("8. Метод Resize.");
                Console.WriteLine("9. Метод Sort.");
                Console.WriteLine("10. Выход.");
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
                        menu.Count(array);
                        break;
                    case 2:
                        if (sorted)
                        {
                            menu.BinSearch(array);
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
                        menu.Copy(array);
                        break;
                    case 4:
                        Console.Clear();
                        menu.Find(array);
                        break;
                    case 5:
                        Console.Clear();
                        menu.FindLast(array);
                        break;
                    case 6:
                        Console.Clear();
                        menu.IndexOf(array);
                        break;
                    case 7:
                        Console.Clear();
                        menu.Reverse(array);
                        sorted = false;
                        break;
                    case 8:
                        Console.Clear();
                        menu.Resize(array);
                        break;
                    case 9:
                        Console.Clear();
                        menu.Sort(array);
                        sorted = true;
                        break;
                    case 10:
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
