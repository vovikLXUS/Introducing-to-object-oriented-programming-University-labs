using System;

namespace Console_Lab_5.models
{
    public class City : Locality
    {
        public string Name { get; set; }
        public long Budget { get; set; }
        public int DistrictsCount { get; set; }

        public City() : base() 
        {
            Name = "Unknown City"; 
            Budget = 0; 
            DistrictsCount = 1; 
        }

        public City(string name, long budget, int districtsCount, double sizeOfTerritory, long population, string location, double costOfLiving, int rating)
        : base(sizeOfTerritory, population, location, costOfLiving, rating)
        {
            Name = name;
            Budget = budget;
            DistrictsCount = districtsCount;
        }

        public City(City other) : base(other)
        {
            Name = other.Name;
            Budget = other.Budget;
            DistrictsCount = other.DistrictsCount;
        }

        public override void Invest()
        {
            Budget += 5000000;
            Console.WriteLine($"[Місто {Name}]: Побудовано нове підприємство! Бюджет збільшено. Поточний бюджет: {Budget:C}");
        }

        public override void Migrate()
        {
            Population += 10000;
            Console.WriteLine($"[Місто {Name}]: Відбувається урбанізація. Кількість населення збільшується. Населення: {Population}");
        }

        // Специфічний унарний оператор для міста (зменшення районів)
        public static City operator --(City c)
        {
            if (c.DistrictsCount > 1) c.DistrictsCount--;
            Console.WriteLine($"Райони міста {c.Name} було об'єднано. Кількість районів: {c.DistrictsCount}");
            return c;
        }
    }
}