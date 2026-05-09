using System;

namespace Console_Lab_5.models
{
    public class Village : Locality
    {
        public string Name { get; set; }
        public int FarmCount { get; set; }

        public Village() : base() 
        { 
            Name = "Unknown Village"; 
            FarmCount = 0; 
        }

        public Village(string name, int farmCount, double sizeOfTerritory, 
            long population, string location, double costOfLiving, int rating) : base(sizeOfTerritory, population, location, costOfLiving, rating)
        {
            Name = name;
            FarmCount = farmCount;
        }

        public Village(Village other) : base(other)
        {
            Name = other.Name;
            FarmCount = other.FarmCount;
        }

        public override void Invest()
        {
            FarmCount++;
            Console.WriteLine($"[Село {Name}]: Відкрито нову ферму завдяки інвестиціям! Кількість ферм: {FarmCount}");
        }

        public override void Migrate()
        {
            Population -= 500;
            Console.WriteLine($"[Село {Name}]: Молодь мігрує до міст. Населення зменшується. Населення: {Population}");
        }
    }
}