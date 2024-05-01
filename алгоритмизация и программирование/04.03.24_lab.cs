using System;
using System.Collections.Generic;

namespace _04._03._24_lab
{
    class Data
    {
        public string PhoneNumber { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Minutes { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Data> PhoneBook = new Dictionary<string, Data>();
            PhoneBook.Add("1", new Data { PhoneNumber = "560-432", Date = "02.01.2024", Time = "12:53", Minutes = 7});
            PhoneBook.Add("2", new Data { PhoneNumber = "324-127", Date = "02.01.2024", Time = "15:21", Minutes = 34});
            PhoneBook.Add("3", new Data { PhoneNumber = "560-432", Date = "02.01.2024", Time = "22:21", Minutes = 43 });
            PhoneBook.Add("4", new Data { PhoneNumber = "560-432", Date = "12.01.2024", Time = "16:45", Minutes = 28 });
            PhoneBook.Add("5", new Data { PhoneNumber = "560-432", Date = "12.01.2024", Time = "18:00", Minutes = 2 });
            PhoneBook.Add("6", new Data { PhoneNumber = "324-127", Date = "12.01.2024", Time = "07:03", Minutes = 5 });
            PhoneBook.Add("7", new Data { PhoneNumber = "324-127", Date = "12.01.2024", Time = "10:03", Minutes = 57 });

            PhoneBook.Add("8", new Data { PhoneNumber = "560-432", Date = "15.02.2024", Time = "14:43", Minutes = 36 });
            PhoneBook.Add("9", new Data { PhoneNumber = "324-127", Date = "15.02.2024", Time = "15:46", Minutes = 4 });
            PhoneBook.Add("10", new Data { PhoneNumber = "324-127", Date = "15.02.2024", Time = "15:59", Minutes = 51 });
            PhoneBook.Add("11", new Data { PhoneNumber = "560-432", Date = "25.02.2024", Time = "08:01", Minutes = 12 });
            PhoneBook.Add("12", new Data { PhoneNumber = "560-432", Date = "25.02.2024", Time = "10:00", Minutes = 26 });
            PhoneBook.Add("13", new Data { PhoneNumber = "324-127", Date = "25.02.2024", Time = "18:19", Minutes = 9 });
            PhoneBook.Add("14", new Data { PhoneNumber = "324-127", Date = "25.02.2024", Time = "23:54", Minutes = 41 });

            //Месячный отчёт по общей сумме минут каждого номера

            Dictionary<string, Dictionary<string, int>> phoneNumberMinutes = new Dictionary<string, Dictionary<string, int>>();

            foreach (var entry in PhoneBook)
            {
                Data call = entry.Value;
                string phoneNumber = call.PhoneNumber;
                int minutes = call.Minutes;

                string[] dateParts = call.Date.Split('.');
                string monthKey = $"{dateParts[1]}";

                if (!phoneNumberMinutes.ContainsKey(monthKey))
                {
                    phoneNumberMinutes[monthKey] = new Dictionary<string, int>();
                }

                if (phoneNumberMinutes[monthKey].ContainsKey(call.PhoneNumber))
                {
                    phoneNumberMinutes[monthKey][call.PhoneNumber] += call.Minutes;
                }
                else
                {
                    phoneNumberMinutes[monthKey][call.PhoneNumber] = call.Minutes;
                }
            }

            Console.WriteLine("Отчёт по общей сумме минут для каждого номера телефона: ");
            foreach (var monthData in phoneNumberMinutes)
            {
                Console.WriteLine($"Месяц: {monthData.Key}");
                foreach (var entry in monthData.Value)
                {
                    Console.WriteLine($"Номер: {entry.Key}, Минуты: {entry.Value}");
                }
                Console.WriteLine();
            }

            //Суммарное время за каждую дату

            Dictionary<string, int> dateMinutes = new Dictionary<string, int>();

            foreach (var entry in PhoneBook)
            {
                Data call = entry.Value;
                string date = call.Date;
                int minutes = call.Minutes;

                if (dateMinutes.ContainsKey(date))
                {
                    dateMinutes[date] += minutes;
                }
                else
                {
                    dateMinutes[date] = minutes;
                }
            }

            Console.WriteLine("\nСуммарное время за каждую дату:");
            foreach (var entry in dateMinutes)
            {
                Console.WriteLine($"Дата: {entry.Key}, Минуты: {entry.Value}");
            }
        }
    }
}