using System;
using System.Collections;
using System.Collections.Generic;

namespace Console_Lab_4_version4.models
{
    public class City : Locality, IComparable<City>, IComparer<City>, IEnumerable<City>
    {
        private string name;
        private long budget;
        private string geographicalFeatures;
        public double economicPotentialMark;

        // Статичний список усіх створених міст
        private static List<City> allCities = new List<City>();

        public string Name
        {
            get 
            {
                return name;
            }
            set 
            {
                name = value; 
            }
        }
        public long Budget
        {
            get 
            { 
                return budget;
            }
            set 
            { 
                budget = value; 
            }
        }
        public string GeographicalFeatures
        {
            get
            { 
                return geographicalFeatures; 
            }
            set 
            {
                geographicalFeatures = value;
            }
        }

        public City(string name, long budget, string geographicalFeatures,
                    double sizeOfTerritory, int population, string location) : base(sizeOfTerritory, population, location)
        {
            Name = name;
            Budget = budget;
            GeographicalFeatures = geographicalFeatures;

            // Кожне нове місто автоматично додається до загального списку
            allCities.Add(this);
        }

        // IComparable<City> — порівняння за розміром території
        // Повертає: < 0 якщо this менше, 0 якщо рівне, > 0 якщо більше
        public int CompareTo(City? other)
        {
            if (other == null) 
                return 1;
            return this.SizeOfTerritory.CompareTo(other.SizeOfTerritory);
        }

        // IComparer<City> — порівняння двох міст за населенням
        // Використовується як: Array.Sort(cities, someCity)
        public int Compare(City? x, City? y)
        {
            if (x == null && y == null) 
                return 0;
            if (x == null)
                return -1;
            if (y == null) 
                return 1;
            return x.Population.CompareTo(y.Population);
        }

        // IEnumerable<City> — перебір міст, відсортованих за населенням
        public IEnumerator<City> GetEnumerator()
        {
            List<City> sorted = new List<City>(allCities);
            sorted.Sort(this); // використовуємо Compare() з IComparer<City>
            return sorted.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Виведення списку всіх міст через IEnumerable (foreach)
        public void PrintCitiesSortedByPopulation()
        {
            Console.WriteLine("\n+============ Cities sorted by population (IEnumerable) ============+");
            int rank = 1;
            foreach (City c in this)
            {
                Console.WriteLine($"| {rank++}. {c.Name,-15} Population: {c.Population,10}   Territory: {c.SizeOfTerritory,6} km² |");
            }
            Console.WriteLine("+===================================================================+");
        }

        // Стандартні методи виведення 
        public void PrintCityInfo()
        {
            Console.Write("+------------------------ Info of the city ------------------------+\n"
                + $"|Name:                  {Name}\n"
                + $"|Budget:                {Budget:C}\n"
                + $"|Geographical features: {GeographicalFeatures}\n");
            PrintPartialInfo();
        }

        public void MessageBeforeCalcGrowth()
        {
            Console.Write($"\n+------------ Increase in industrial income of the {Name} -------------+");
        }
        public void MessageBeforeCalcLabor()
        {
            Console.Write($"\n+---------------------- Labor potential of the {Name} -----------------------+");
        }
        public void MessageBeforeCalcInvestments()
        {
            Console.Write($"+--------------- Future of investments of the {Name} ---------------+");
        }
        public void MessageBeforeCalcEcoPot()
        {
            Console.Write($"+--------------------------- Economic potential of the {Name} ---------------------------+\n");
        }
    }
}