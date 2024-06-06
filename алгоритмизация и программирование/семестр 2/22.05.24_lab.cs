using System;
using System.Collections.Generic;
using System.Linq;

namespace _22._05._24_lab
{
    class EmployeeProduction
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string ProductCategory { get; set; }
        public int QuantityProduced { get; set; }
        public decimal UnitPrice { get; set; }

        public EmployeeProduction(int employeeId, string fullName, string position, decimal salary, string productCategory, int quantityProduced, decimal unitPrice)
        {
            EmployeeId = employeeId;
            FullName = fullName;
            Position = position;
            Salary = salary;
            ProductCategory = productCategory;
            QuantityProduced = quantityProduced;
            UnitPrice = unitPrice;
        }

        public decimal TotalProductionValue => QuantityProduced * UnitPrice;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<EmployeeProduction> productions = new List<EmployeeProduction>
        {
            new EmployeeProduction(1, "Ivanov Ivan", "Worker", 20000, "Category1", 100, 300),
            new EmployeeProduction(2, "Petrov Petr", "Worker", 25000, "Category2", 200, 150),
            new EmployeeProduction(3, "Sidorov Sidr", "Worker", 15000, "Category1", 150, 250),
            new EmployeeProduction(4, "Kuznetsov Kuzma", "Worker", 30000, "Category3", 50, 600)
        };

            // Кол-во рабочих, которые получают ЗП < сумма выработанной продукции
            var workersWithLessSalaryThanProduction = productions.Count(p => p.Salary < p.TotalProductionValue);

            Console.WriteLine($"Количество рабочих, которые получают ЗП < сумма выработанной продукции: {workersWithLessSalaryThanProduction}");

            // Кол-во произведённой продукции по каждой категории (в количественном и денежном эквиваленте)
            var productionByCategory = productions.GroupBy(p => p.ProductCategory)
                                                  .Select(g => new
                                                  {
                                                      Category = g.Key,
                                                      TotalQuantity = g.Sum(p => p.QuantityProduced),
                                                      TotalValue = g.Sum(p => p.TotalProductionValue)
                                                  });

            Console.WriteLine("\nКоличество произведённой продукции по каждой категории:");
            foreach (var category in productionByCategory)
            {
                Console.WriteLine($"{category.Category}: Количество - {category.TotalQuantity}, Суммарная стоимость - {category.TotalValue:C}");
            }

            // Общий суммарный объём произведённой продукции
            var totalProductionValue = productions.Sum(p => p.TotalProductionValue);

            Console.WriteLine($"\nОбщий суммарный объём произведённой продукции: {totalProductionValue:C}");

            // Кол-во сотрудников, получающих > 50% от суммы производимого ими продукта
            var workersWithMoreThanHalfProductionValue = productions.Count(p => p.Salary > (p.TotalProductionValue / 2));

            Console.WriteLine($"Количество сотрудников, получающих > 50% от суммы производимого ими продукта: {workersWithMoreThanHalfProductionValue}");
        }
    }
}
