using System;
using System.Collections.Generic;
using System.IO;

namespace _01._04._24_lab
{
    internal class Program
    {
        struct Person
        {
            public int YearOfBirth;
            public string CityOfBirth;
            public string CountryOfBirth;

            public Person(int yearOfBirth, string cityOfBirth, string countryOfBirth)
            {
                YearOfBirth = yearOfBirth;
                CityOfBirth = cityOfBirth;
                CountryOfBirth = countryOfBirth;
            }
        }
        static void Main(string[] args)
        {
            string inputFilePath = "input.txt";
            string outputByYearFilePath = "output_by_year.txt";
            string outputByCityFilePath = "output_by_city.txt";
            string outputByCountryFilePath = "output_by_country.txt";

            List<Person> persons = new List<Person>();
            foreach (var line in File.ReadLines(inputFilePath))
            {
                var parts = line.Split(',');
                int yearOfBirth = int.Parse(parts[0]);
                string cityOfBirth = parts[1];
                string countryOfBirth = parts[2];
                persons.Add(new Person(yearOfBirth, cityOfBirth, countryOfBirth));
            }

            persons.Sort((p1, p2) => p1.YearOfBirth.CompareTo(p2.YearOfBirth));
            using (StreamWriter writer = new StreamWriter(outputByYearFilePath))
            {
                int currentYear = -1;
                foreach (var person in persons)
                {
                    if (person.YearOfBirth != currentYear)
                    {
                        currentYear = person.YearOfBirth;
                        writer.WriteLine($"Год: {currentYear}");
                    }
                    writer.WriteLine($"{person.YearOfBirth}, {person.CityOfBirth}, {person.CountryOfBirth}");
                }
            }

            Dictionary<string, List<Person>> cityGroups = new Dictionary<string, List<Person>>();
            foreach (var person in persons)
            {
                if (!cityGroups.ContainsKey(person.CityOfBirth))
                {
                    cityGroups[person.CityOfBirth] = new List<Person>();
                }
                cityGroups[person.CityOfBirth].Add(person);
            }

            using (StreamWriter writer = new StreamWriter(outputByCityFilePath))
            {
                foreach (var city in cityGroups.Keys)
                {
                    writer.WriteLine($"Город: {city}");
                    foreach (var person in cityGroups[city])
                    {
                        writer.WriteLine($"{person.YearOfBirth}, {person.CityOfBirth}, {person.CountryOfBirth}");
                    }
                }
            }

            Console.Write("Введите страну: ");
            string country = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(outputByCountryFilePath))
            {
                foreach (var person in persons)
                {
                    if (person.CountryOfBirth.Equals(country, StringComparison.OrdinalIgnoreCase))
                    {
                        writer.WriteLine($"{person.YearOfBirth}, {person.CityOfBirth}, {person.CountryOfBirth}");
                    }
                }
            }

            Console.WriteLine("Обработка данных завершена.");
        }
    }
}
