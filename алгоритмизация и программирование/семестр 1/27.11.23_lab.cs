using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27._11._23_lab
{
    class Car
    {
        public string Name;
        public int Year;
        public string Color;
        public string Owner;
        public int Healthcheckyear;
        public Car(string name, int year, string color, string owner, int healthcheckyear)
        {
            this.Name = name;
            this.Year = year;
            this.Color = color;
            this.Owner = owner;
            this.Healthcheckyear = healthcheckyear;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car[] CarArray = new Car[5]
            {                
                new Car("mazda", 1999, "black", "Peter", 2004),
                new Car("toyota", 1983, "green", "Emy", 2009),
                new Car("honda", 1999, "yellow", "Sam", 2004),
                new Car("mazda", 2005, "pink", "Carlo", 2008),
                new Car("honda", 2005, "white", "Alex", 2009)
            };

            Console.WriteLine("Введите год:");
            int year = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < CarArray.Length; i++)
            {
                if (CarArray[i].Year == year)
                {
                    Console.WriteLine(CarArray[i].Owner);
                }
            }
            Console.WriteLine();

            Console.WriteLine("Введите марку:");
            string name = Convert.ToString(Console.ReadLine());
            for (int i = 0; i < CarArray.Length; i++)
            {
                if (CarArray[i].Name == name)
                {
                    Console.WriteLine(CarArray[i].Owner);
                }
            }
            Console.WriteLine();

            Console.WriteLine("Введите год прохождения техосмотра:");
            int healthcheckyear = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < CarArray.Length; i++)
            {
                if (CarArray[i].Healthcheckyear == healthcheckyear)
                {
                    Console.WriteLine(CarArray[i].Owner);
                }
            }
            Console.WriteLine();

            Console.WriteLine("Введите данные владельца:");
            string owner = Convert.ToString(Console.ReadLine());
            for (int i = 0; i < CarArray.Length; i++)
            {
                if (CarArray[i].Owner == owner)
                {
                    Console.WriteLine(CarArray[i].Name);
                    Console.WriteLine(CarArray[i].Year); Console.WriteLine(CarArray[i].Color);
                    Console.WriteLine(CarArray[i].Healthcheckyear);
                }
            }
        }
    }
}
