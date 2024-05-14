using System;
using System.Collections.Generic;
using System.Linq;

namespace Phone_Book
{
    internal class Phone_Book
    {
        class Data
        {
            public string OutgoingCall { get; set; }
            public string IncomingCall { get; set; }
            public string Date { get; set; }
            public int Minutes { get; set; }
        }
        static void Main(string[] args)
        {
            Dictionary<string, Data> PhoneBook = new Dictionary<string, Data>();
            PhoneBook.Add("1", new Data { OutgoingCall = "560-432", IncomingCall = "780-145", Date = "02.01.2024", Minutes = 7 });
            PhoneBook.Add("2", new Data { OutgoingCall = "560-432", IncomingCall = "780-145", Date = "02.01.2024", Minutes = 34 });
            PhoneBook.Add("3", new Data { OutgoingCall = "560-432", IncomingCall = "440-490", Date = "12.01.2024", Minutes = 43 });
            PhoneBook.Add("4", new Data { OutgoingCall = "560-432", IncomingCall = "109-833", Date = "12.01.2024", Minutes = 28 });
            PhoneBook.Add("5", new Data { OutgoingCall = "560-432", IncomingCall = "440-490", Date = "12.01.2024", Minutes = 2 });
            PhoneBook.Add("6", new Data { OutgoingCall = "560-432", IncomingCall = "109-833", Date = "15.02.2024", Minutes = 5 });
            PhoneBook.Add("7", new Data { OutgoingCall = "560-432", IncomingCall = "338-393", Date = "25.02.2024", Minutes = 57 });

            PhoneBook.Add("8", new Data { OutgoingCall = "324-127", IncomingCall = "435-234", Date = "02.01.2024", Minutes = 36 });
            PhoneBook.Add("9", new Data { OutgoingCall = "324-127", IncomingCall = "288-656", Date = "02.01.2024", Minutes = 4 });
            PhoneBook.Add("10", new Data { OutgoingCall = "324-127", IncomingCall = "288-656", Date = "02.01.2024", Minutes = 51 });
            PhoneBook.Add("11", new Data { OutgoingCall = "324-127", IncomingCall = "435-234", Date = "12.01.2024", Minutes = 12 });
            PhoneBook.Add("12", new Data { OutgoingCall = "324-127", IncomingCall = "786-465", Date = "15.02.2024", Minutes = 26 });
            PhoneBook.Add("13", new Data { OutgoingCall = "324-127", IncomingCall = "786-465", Date = "15.02.2024", Minutes = 9 });
            PhoneBook.Add("14", new Data { OutgoingCall = "324-127", IncomingCall = "435-234", Date = "25.02.2024", Minutes = 41 });

            //На какой номер чаще всего звонил абонент

            string selectedPhoneNumber = "560-432";

            Dictionary<string, Dictionary<string, int>> outgoingCallsCountByDate = new Dictionary<string, Dictionary<string, int>>();

            foreach (var entry in PhoneBook)
            {
                if (entry.Value.OutgoingCall == selectedPhoneNumber)
                {
                    if (!outgoingCallsCountByDate.ContainsKey(entry.Value.Date))
                    {
                        outgoingCallsCountByDate[entry.Value.Date] = new Dictionary<string, int>();
                    }

                    if (!outgoingCallsCountByDate[entry.Value.Date].ContainsKey(entry.Value.IncomingCall))
                    {
                        outgoingCallsCountByDate[entry.Value.Date][entry.Value.IncomingCall] = 0;
                    }

                    outgoingCallsCountByDate[entry.Value.Date][entry.Value.IncomingCall]++;
                }
            }

            Dictionary<string, string> mostFrequentNumbersByDate = new Dictionary<string, string>();

            foreach (var dateEntry in outgoingCallsCountByDate)
            {
                var mostFrequentNumber = dateEntry.Value.OrderByDescending(x => x.Value).First().Key;
                mostFrequentNumbersByDate[dateEntry.Key] = mostFrequentNumber;
            }

            Console.WriteLine("Номера, на которые чаще всего звонил выбранный абонент:");
            foreach (var entry in mostFrequentNumbersByDate)
            {
                Console.WriteLine($"Дата: {entry.Key}, Номер: {entry.Value}");
            }

            // Номера, с которыми наибольшее количество минут разговаривал каждый абонент

            Dictionary<string, Dictionary<string, Dictionary<string, int>>> totalMinutesByNumberAndDate = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();

            foreach (var entry in PhoneBook)
            {
                if (!totalMinutesByNumberAndDate.ContainsKey(entry.Value.OutgoingCall))
                {
                    totalMinutesByNumberAndDate[entry.Value.OutgoingCall] = new Dictionary<string, Dictionary<string, int>>();
                }

                if (!totalMinutesByNumberAndDate[entry.Value.OutgoingCall].ContainsKey(entry.Value.Date))
                {
                    totalMinutesByNumberAndDate[entry.Value.OutgoingCall][entry.Value.Date] = new Dictionary<string, int>();
                }

                if (!totalMinutesByNumberAndDate[entry.Value.OutgoingCall][entry.Value.Date].ContainsKey(entry.Value.IncomingCall))
                {
                    totalMinutesByNumberAndDate[entry.Value.OutgoingCall][entry.Value.Date][entry.Value.IncomingCall] = 0;
                }

                totalMinutesByNumberAndDate[entry.Value.OutgoingCall][entry.Value.Date][entry.Value.IncomingCall] += entry.Value.Minutes;
            }

            Console.WriteLine("Номера, с которыми наибольшее количество минут разговаривал каждый абонент:");
            foreach (var entry in totalMinutesByNumberAndDate)
            {
                foreach (var dateEntry in entry.Value)
                {
                    var mostTalkativeNumber = dateEntry.Value.OrderByDescending(x => x.Value).First();
                    Console.WriteLine($"Абонент: {entry.Key}, Дата: {dateEntry.Key}, Номер: {mostTalkativeNumber.Key}, Сумма минут: {mostTalkativeNumber.Value}");
                }
            }
        }
    }
}