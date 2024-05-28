using System;

namespace _27._03._24_lab
{
    class A<T>
    {
        public T a { get; set; }
        public T b { get; set; }
        public A(T a1, T b1)
        {
            a = a1;
            b = b1;
        }
        public T Addition()
        {
            dynamic a1 = a;
            dynamic b1 = b;
            return a1 + b1;
        }
        public T Substraction()
        {
            dynamic a1 = a;
            dynamic b1 = b;
            return a1 - b1;
        }
        public T Multiplication()
        {
            dynamic a1 = a;
            dynamic b1 = b;
            return a1 * b1;
        }
        public T Division()
        {
            dynamic a1 = a;
            dynamic b1 = b;
            return a1 / b1;
        }
    }
    class Type
    {
        public void Integer()
        {
            A<int> aInt = new A<int>(20, 4);

            int sInt = aInt.Addition();
            int rInt = aInt.Substraction();
            int mInt = aInt.Multiplication();
            int dInt = aInt.Division();

            Console.WriteLine(sInt);
            Console.WriteLine(rInt);
            Console.WriteLine(mInt);
            Console.WriteLine(dInt);
            Console.WriteLine();
        }
        public void Double()
        {
            A<double> aDouble = new A<double>(20.75, 4.15);

            double sDouble = aDouble.Addition();
            double rDouble = aDouble.Substraction();
            double mDouble = aDouble.Multiplication();
            double dDouble = aDouble.Division();

            Console.WriteLine(sDouble);
            Console.WriteLine(rDouble);
            Console.WriteLine(mDouble);
            Console.WriteLine(dDouble);
            Console.WriteLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = new Type();

            while (true)
            {
                Console.WriteLine("Выберите тип чисел:");
                Console.WriteLine("1. Целые.");
                Console.WriteLine("2. Вещественные.");
                Console.WriteLine();

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        type.Integer();
                        break;
                    case 2:
                        Console.Clear();
                        type.Double();
                        break;
                }
            }
        }
    }
}
