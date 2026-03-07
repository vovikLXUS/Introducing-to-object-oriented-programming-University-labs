using System;

namespace Console_Lab_4_version2.labModels
{
    public class City : Locality
    {
        private string name;
        private long budget;
        private string geographicalFeatures;
        public double economicPotentialMark;
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
        }
        public void PrintCityInfo()
        {
            Console.Write("+------------------------ Info of the city ------------------------+\n"
                + $"|Name:                  {Name}\n"
                + $"|Budget:                {Budget:C}\n"
                + $"|Geographical features: {GeographicalFeatures}\n");

            PrintPartialInfo(); // = base.PrintPartialInfo();
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