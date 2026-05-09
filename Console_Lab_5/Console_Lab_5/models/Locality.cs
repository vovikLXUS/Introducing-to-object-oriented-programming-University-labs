using System;

namespace Console_Lab_5.models
{
    public class Locality
    {
        protected double sizeOfTerritory;
        protected long population;
        protected string location;
        public double economicPotentialMark;

        // Додаткові поля для перевантаження операторів
        public double CostOfLiving { get; set; }
        public int Rating { get; set; }

        public double SizeOfTerritory
        {
            get 
            { 
                return sizeOfTerritory; 
            }
            set 
            { 
                sizeOfTerritory = value; 
            }
        }
        public long Population
        {
            get
            {
                return population; 
            }
            set
            {
                population = value; 
            }
        }
        public string Location
        {
            get
            {
                return location;
            }
            set 
            { 
                location = value; 
            }
        }

        // Конструктор за замовчуванням
        public Locality()
        {
            sizeOfTerritory = 0.0;
            population = 0;
            location = "Unknown";
            CostOfLiving = 0.0;
            Rating = 0;
        }

        // Конструктор з параметрами
        public Locality(double sizeOfTerritory, long population, string location, double costOfLiving, int rating)
        {
            SizeOfTerritory = sizeOfTerritory;
            Population = population;
            Location = location;
            CostOfLiving = costOfLiving;
            Rating = rating;
        }

        // Конструктор копіювання
        public Locality(Locality other)
        {
            SizeOfTerritory = other.SizeOfTerritory;
            Population = other.Population;
            Location = other.Location;
            CostOfLiving = other.CostOfLiving;
            Rating = other.Rating;
        }

        // Віртуальні методи для перевантаження
        public virtual void Invest()
        {
            Console.WriteLine("Базовий метод: Інвестиції надходять у місцевість.");
        }

        public virtual void Migrate()
        {
            Console.WriteLine("Базовий метод: Відбуваються базові міграційні процеси.");
        }

        // Перевантаження бінарних операторів
        public static long operator +(Locality locality1, Locality locality2) => locality1.Population + locality2.Population;
        public static long operator -(Locality locality1, Locality locality2) => Math.Abs(locality1.Population - locality2.Population);
        public static bool operator >(Locality locality1, Locality locality2) => locality1.CostOfLiving > locality2.CostOfLiving;
        public static bool operator <(Locality locality1, Locality locality2) => locality1.CostOfLiving < locality2.CostOfLiving;
        public static bool operator ==(Locality locality1, Locality locality2)
        {
            if (ReferenceEquals(locality1, null) || ReferenceEquals(locality2, null)) 
                return ReferenceEquals(locality1, locality2);
            return locality1.Population == locality2.Population;
        }
        public static bool operator !=(Locality locality1, Locality locality2) => !(locality1 == locality2);

        // Перевантаження унарних операторів
        public static Locality operator ++(Locality locality)
        {
            locality.Rating++;
            return locality;
        }
        public static Locality operator --(Locality loc)
        {
            loc.Rating--;
            return loc;
        }
        public static Locality operator -(Locality loc)
        {
            // Наприклад, зменшення населення на 10% внаслідок кризи
            loc.Population = (long)(loc.Population * 0.9);
            return loc;
        }

        public override bool Equals(object obj)
        {
            if (obj is Locality other) 
                return this.Population == other.Population;
            return false;
        }
        public override int GetHashCode() => Population.GetHashCode();

        // Старі методи з Лаби 4
        public void PrintPartialInfo()
        {
            Console.Write($"|Population:            {Population}\n"
                + $"|Size of territory:     {SizeOfTerritory} km in square\n"
                + "+------------------------------------------------------------------+\n");
        }
    }
}