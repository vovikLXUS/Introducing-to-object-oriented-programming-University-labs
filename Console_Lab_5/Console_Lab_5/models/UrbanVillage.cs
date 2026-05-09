using System;
using System.Text;

namespace Console_Lab_5.models
{
    public class UrbanVillage : Locality
    {
        public string Name { get; set; }
        public bool HasResort { get; set; }

        public UrbanVillage() : base() 
        { 
            Name = "Unknown Urban Village"; 
            HasResort = false; 
        }

        public UrbanVillage(string name, bool hasResort, double sizeOfTerritory, long population, string location, double costOfLiving, int rating)
            : base(sizeOfTerritory, population, location, costOfLiving, rating)
        {
            Name = name;
            HasResort = hasResort;
        }

        public UrbanVillage(UrbanVillage other) : base(other)
        {
            Name = other.Name;
            HasResort = other.HasResort;
        }

        public override void Invest()
        {
            HasResort = true;
            Console.WriteLine($"[СМТ {Name}]: Інвестори відкрили курортну зону! Туристична привабливість зросла.");
        }

        public override void Migrate()
        {
            Population -= 100;
            Console.WriteLine($"[СМТ {Name}]: Незначний відтік населення на заробітки. Населення: {Population}");
        }
    }
}
