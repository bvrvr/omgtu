using System;

namespace Interface
{
    interface IOperations
    {
        delegate void Addition();
        delegate void Substraction();
        delegate void Multiplication();
        delegate void Division();
        delegate void Square();
        delegate void Sin();
        delegate void Cos();
    }

    class Operations : IOperations
    {
        public void Addition()
        {
            Console.WriteLine("Введите значение a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите значение b: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Сумма элементов {a} и {b} равна {a + b}");
            Console.WriteLine();
        }
        public void Substraction()
        {
            Console.WriteLine("Введите значение a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите значение b: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Разность элементов {a} и {b} равна {a - b}");
            Console.WriteLine();
        }
        public void Multiplication()
        {
            Console.WriteLine("Введите значение a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите значение b: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Произведение элементов {a} и {b} равна {a * b}");
            Console.WriteLine();
        }
        public void Division()
        {
            Console.WriteLine("Введите значение a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите значение b: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Сумма элементов {a} и {b} равна {a / b}");
            Console.WriteLine();
        }
        public void Square()
        {
            Console.WriteLine("Введите значение a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Корень из {a} равен {Math.Sqrt(a)}");
            Console.WriteLine();
        }
        public void Sin()
        {
            Console.WriteLine("Введите значение a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Синус {a} равен {Math.Sin(a)}");
            Console.WriteLine();
        }
        public void Cos()
        {
            Console.WriteLine("Введите значение a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Коинус {a} равен {Math.Cos(a)}");
            Console.WriteLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Operations operations = new Operations();

            while (true)
            {
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1. Сложение.");
                Console.WriteLine("2. Вычитание.");
                Console.WriteLine("3. Умножение.");
                Console.WriteLine("4. Деление.");
                Console.WriteLine("5. Извлечение корня.");
                Console.WriteLine("6. Поиск синуса.");
                Console.WriteLine("7. Поиск косинуса.");
                Console.WriteLine();

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        operations.Addition();
                        break;
                    case 2:
                        Console.Clear();
                        operations.Substraction();
                        break;
                    case 3:
                        Console.Clear();
                        operations.Multiplication();
                        break;
                    case 4:
                        Console.Clear();
                        operations.Division();
                        break;
                    case 5:
                        Console.Clear();
                        operations.Square();
                        break;
                    case 6:
                        Console.Clear();
                        operations.Sin();
                        break;
                    case 7:
                        Console.Clear();
                        operations.Cos();
                        break;
                }
            }
        }
    }
}
