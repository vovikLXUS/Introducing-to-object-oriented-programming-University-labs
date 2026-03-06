using System;

namespace Console_Lab_4.labModels
{
    public class City : Locality
    {
        private string name;
        private int budget;
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
        public int Budget
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
        public City(string name, int budget, string geographicalFeatures,
            double sizeOfTerritory, int population, string location) : base(sizeOfTerritory, population, location)
        {
            Name = name;
            Budget = budget;
            GeographicalFeatures = geographicalFeatures;
        }
        public void PrintCityInfo()
        {
            Console.Write("+---------------------- Info of the city ----------------------+\n"
                + $"|Name:                  {Name}\n"
                + $"|Budget:                {Budget:C}\n"
                + $"|Geographical features: {GeographicalFeatures}\n");

            PrintPartialInfo(); // = base.PrintPartialInfo();
        }
        // Console.Write("\n+--------------------- Economic potential ---------------------+");
        // IncreaseOfInvestments
        public void MessageBeforeCalculationOfIncrease()
        {
            Console.Write($"\n+----- Increase in industrial income of the {Name} -----+");
        }
        public void MessageBeforeCalculationOfLabor()
        {
            Console.Write($"\n+--------------------- Labor potential of the {Name} ---------------------+");
        }
        public void MessageBeforeCalculationOfIncreaseOfInvestments()
        {
            Console.Write($"\n+--------------------- Increase of investments of the {Name} ---------------------+");
        }
        public void MessageHeaderOfCalcInvestments()
        {
            Console.Write($"\n+----------- Calculation of investments' future of {Name} -----------+");
        }
    }
}
