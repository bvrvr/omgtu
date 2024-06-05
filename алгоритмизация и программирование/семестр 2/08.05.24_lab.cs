using System;
using System.Collections.Generic;
using System.Linq;
public class Client
{
    public string AccountNumber { get; set; }
    public string FullName { get; set; }
    public decimal Income { get; set; }
    public decimal Expense { get; set; }
    public decimal Tax => Income * 0.05m;
    public decimal Balance => Income - Expense - Tax;
}

namespace _08._05._24_lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Client> clients = new List<Client>
            {
            new Client { AccountNumber = "123456", FullName = "Ivan Ivanov", Income = 1000, Expense = 500 },
            new Client { AccountNumber = "234567", FullName = "Petr Petrov", Income = 2000, Expense = 1800 },
            new Client { AccountNumber = "345678", FullName = "Sergey Sergeev", Income = 3000, Expense = 3200 },
            new Client { AccountNumber = "456789", FullName = "Anna Ivanova", Income = 4000, Expense = 1000 },
            new Client { AccountNumber = "567890", FullName = "Olga Petrova", Income = 1500, Expense = 1700 }
            };

            var negativeBalanceClients = clients.Where(c => c.Balance < 0).ToList();
            Console.WriteLine("Клиенты с отрицательным балансом:");
            foreach (var client in negativeBalanceClients)
            {
                Console.WriteLine($"{client.FullName}, Баланс: {client.Balance}");
            }

            int positiveBalanceCount = clients.Count(c => c.Balance > 0);
            Console.WriteLine($"\nКоличество клиентов с положительным балансом: {positiveBalanceCount}");

            decimal maxIncome = clients.Max(c => c.Income);
            var maxIncomeClients = clients.Where(c => c.Income == maxIncome).ToList();
            Console.WriteLine("\nКлиенты с максимальным доходом:");
            foreach (var client in maxIncomeClients)
            {
                Console.WriteLine($"{client.FullName}, Доход: {client.Income}");
            }

            decimal totalTaxes = clients.Sum(c => c.Tax);
            Console.WriteLine($"\nОбщая сумма налогов: {totalTaxes}");
        }
    }
}
