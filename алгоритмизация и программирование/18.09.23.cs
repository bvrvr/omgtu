using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание 1
            int a, b;
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine($"a = {a}, b = {b}");

            //Задание 2
            int time, hour, minute, second;
            time = Convert.ToInt32(Console.ReadLine());
            hour = time / 3600;
            minute = (time - hour * 3600) / 60;
            second = time - hour * 3600 - minute * 60;
            Console.WriteLine($"{hour} часов, {minute} минут, {second} секунд.");

            //Задание 3
            int c, d, max, min;
            c = Convert.ToInt32(Console.ReadLine());
            d = Convert.ToInt32(Console.ReadLine());
            min = ((c + d - Math.Abs(c - d)) / 2);
            max = ((c + d + Math.Abs(c - d)) / 2);
            Console.WriteLine($"Наименьшее число: {min}, наибольшее число: {max}");
        }
    }
}
