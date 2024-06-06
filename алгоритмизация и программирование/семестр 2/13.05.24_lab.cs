using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public string SKU { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public string Warehouse { get; set; }

    public Product(string sku, string name, string category, int quantity, decimal unitPrice, string warehouse)
    {
        SKU = sku;
        Name = name;
        Category = category;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Warehouse = warehouse;
    }

    public decimal TotalValue => Quantity * UnitPrice;
}

namespace _13._05._24_lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
        {
            new Product("001", "Product1", "Category1", 10, 15.50m, "Warehouse1"),
            new Product("002", "Product2", "Category1", 5, 25.00m, "Warehouse1"),
            new Product("003", "Product3", "Category2", 20, 10.00m, "Warehouse2"),
            new Product("004", "Product4", "Category2", 15, 20.00m, "Warehouse2"),
            new Product("005", "Product5", "Category3", 8, 50.00m, "Warehouse1"),
        };

            // Объем товара в денежном эквиваленте по каждому складу
            var warehouseValue = products.GroupBy(p => p.Warehouse)
                                         .Select(g => new
                                         {
                                             Warehouse = g.Key,
                                             TotalValue = g.Sum(p => p.TotalValue)
                                         });

            Console.WriteLine("Объем товара в денежном эквиваленте по каждому складу:");
            foreach (var item in warehouseValue)
            {
                Console.WriteLine($"{item.Warehouse}: {item.TotalValue:C}");
            }

            // Максимальная цена по каждой категории
            var maxPriceByCategory = products.GroupBy(p => p.Category)
                                             .Select(g => new
                                             {
                                                 Category = g.Key,
                                                 MaxPrice = g.Max(p => p.UnitPrice)
                                             });

            Console.WriteLine("\nМаксимальная цена по каждой категории:");
            foreach (var item in maxPriceByCategory)
            {
                Console.WriteLine($"{item.Category}: {item.MaxPrice:C}");
            }

            // Средняя цена товара по каждому складу и по всем складам
            var avgPriceByWarehouse = products.GroupBy(p => p.Warehouse)
                                              .Select(g => new
                                              {
                                                  Warehouse = g.Key,
                                                  AvgPrice = g.Average(p => p.UnitPrice)
                                              });

            var avgPriceAllWarehouses = products.Average(p => p.UnitPrice);

            Console.WriteLine("\nСредняя цена товара по каждому складу:");
            foreach (var item in avgPriceByWarehouse)
            {
                Console.WriteLine($"{item.Warehouse}: {item.AvgPrice:C}");
            }
            Console.WriteLine($"Средняя цена товара по всем складам: {avgPriceAllWarehouses:C}");

            // Самый дешевый товар
            var cheapestProduct = products.OrderBy(p => p.UnitPrice).FirstOrDefault();

            Console.WriteLine("\nСамый дешевый товар:");
            if (cheapestProduct != null)
            {
                Console.WriteLine($"{cheapestProduct.Name} ({cheapestProduct.SKU}) - {cheapestProduct.UnitPrice:C}");
            }

            // Склад с наименьшей суммарной стоимостью товаров
            var warehouseWithMinValue = warehouseValue.OrderBy(w => w.TotalValue).FirstOrDefault();

            Console.WriteLine("\nСклад с наименьшей суммарной стоимостью товаров:");
            if (warehouseWithMinValue != null)
            {
                Console.WriteLine($"{warehouseWithMinValue.Warehouse}: {warehouseWithMinValue.TotalValue:C}");

                var productsInWarehouse = products.Where(p => p.Warehouse == warehouseWithMinValue.Warehouse);
                foreach (var product in productsInWarehouse)
                {
                    Console.WriteLine($"{product.Name} ({product.SKU}) - Категория: {product.Category}, Количество: {product.Quantity}, Цена за единицу: {product.UnitPrice:C}, Склад: {product.Warehouse}");
                }
            }
        }
    }
}
