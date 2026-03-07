using System;

namespace Console_Lab_4.labModels
{
    public class Country : Locality
    {
        private string name;
        private long budget;
        private string geographicalFeatures;
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
        public Country(string name, long budget, string geographicalFeatures,
            double sizeOfTerritory, int population, string location) : base(sizeOfTerritory, population, location)
        {
            Name = name;
            Budget = budget;
            GeographicalFeatures = geographicalFeatures;
        }
        public void PrintCountryInfo()
        {
            Console.Write("+----------------------- Info of the country ----------------------+\n"
                + $"|Name:                  {Name}\n"
                + $"|Budget:                {Budget:C}\n"
                + $"|Geographical features: {GeographicalFeatures}\n");

            PrintPartialInfo(); // = base.PrintPartialInfo();
        }
        public void MessageBeforeCalculationOfIncrease()
        {
            Console.Write($"+----- Increase in industrial income of the {Name} -----+");
        }
        public void MessageBeforeCalculationOfLabor()
        {
            Console.Write($"+--------------- Labor potential of the {Name} ---------------+");
        }
        public void MessageBeforeCalculationOfIncreaseOfInvestments()
        {
            Console.Write($"\n+------- Future of investments of the {Name} --------+");
        }
        public void MessageBeforeCalculationOfEcoPot()
        {
            Console.Write($"\n+------------------- Economic potential of the {Name} --------------------+\n");
        }
    }
}