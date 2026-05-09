using Console_Lab_4_version4.models;
using System;
using System.Text;

namespace Console_Lab_4_version4
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Масив об'єктів класу City
            City[] cities = new City[]
            {
                new City(
                    "Kyiv",
                    1060000000,
                    "Significant elevation differences.",
                    839,
                    340000,
                    "Middle reaches of the Dnipro River."
                ),
                new City(
                    "Kharkiv",
                    18000000000,
                    "Flat terrain, steppe zone.",
                    350,
                    1430000,
                    "Located in northeastern Ukraine."
                ),
                new City(
                    "Odesa",
                    15000000000,
                    "Coastal city on the Black Sea.",
                    162,
                    1017000,
                    "Southwest Ukraine, Black Sea coast."
                ),
                new City(
                    "Lviv",
                    12000000000,
                    "Hilly terrain, Carpathian foothills.",
                    182,
                    757000,
                    "Western Ukraine."
                ),
                new City(
                    "Dnipro",
                    20000000000,
                    "Located along the Dnipro River.",
                    405,
                    980000,
                    "Central-eastern Ukraine."
                )
            };

            // Виведення інформації про всі міста
            Console.WriteLine("==================== ALL CITIES INFO ====================");
            foreach (City city in cities)
            {
                city.PrintCityInfo();
                Console.WriteLine();
            }

            // IComparable<City> — Array.Sort() без параметрів викликає CompareTo()
            // Сортування за розміром території
            Console.WriteLine("+====== IComparable: Array.Sort() by territory ======+");
            Array.Sort(cities); // викликає CompareTo() автоматично
            int rank = 1;
            foreach (City c in cities)
            {
                Console.WriteLine($"| {rank++}. {c.Name,-12}  Territory: {c.SizeOfTerritory,6} km²  Population: {c.Population,10} |");
            }
            Console.WriteLine("+====================================================+");

            // IComparer<City> — Array.Sort() з об'єктом, що реалізує Compare()
            // Сортування за кількістю населення
            Console.WriteLine("\n+====== IComparer: Array.Sort() by population ======+");
            Array.Sort(cities, cities[0]); // cities[0] реалізує IComparer<City> через Compare()
            rank = 1;
            foreach (City c in cities)
            {
                Console.WriteLine($"| {rank++}. {c.Name,-12}  Population: {c.Population,10}  Territory: {c.SizeOfTerritory,6} km² |");
            }
            Console.WriteLine("+===================================================+");

            // IEnumerable<City> — foreach по об'єкту міста
            // GetEnumerator() повертає міста відсортовані за населенням
            cities[0].PrintCitiesSortedByPopulation();

            // Демонстрація CompareTo() — пряме порівняння двох міст
            Console.WriteLine("\n+====== IComparable: manual CompareTo() demo ======+");
            City kyiv = cities[0];
            City kharkiv = cities[1];

            int result = kyiv.CompareTo(kharkiv);
            if (result > 0)
                Console.WriteLine($"| {kyiv.Name} is LARGER by territory than {kharkiv.Name}");
            else if (result < 0)
                Console.WriteLine($"| {kyiv.Name} is SMALLER by territory than {kharkiv.Name}");
            else
                Console.WriteLine($"| {kyiv.Name} and {kharkiv.Name} have EQUAL territory");

            Console.WriteLine("+==================================================+\n");
        }
    }
}