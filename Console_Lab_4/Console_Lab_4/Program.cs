using System;
using System.Text;
using Console_Lab_4.labModels;

namespace Console_Lab_4
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            double cityIndustrialIncome = 0.0,
                cityLaborPotential = 0.0,
                cityResultOfInvests = 0.0;

            double countryIndustrialIncome = 0.0,
                countryLaborPotential = 0.0,
                countryResultOfInvests = 0.0;

            // Initializations of city/country
            City city = new City("Sokal", 950000, "Рівнинна місцевість, помірно-континентальний клімат", 
                8.47, 20373, "Північ Львівської області, правий берег р. Західний Буг");
            
            Country country = new Country("Шептицький", 67676969, "Рівнинний ландшафт",
                23.2, 58500, "Північ Львівської області, близько до Республіки Польща");

            // Output info about city/country
            city.PrintCityInfo();

            Console.WriteLine();

            country.PrintCountryInfo();

            // Calculations of increase of industrial income
            city.MessageBeforeCalculationOfIncrease();
            cityIndustrialIncome = city.GrowthInIndustrialIncome(15000000, 12000000);

            country.MessageBeforeCalculationOfIncrease();
            countryIndustrialIncome = country.GrowthInIndustrialIncome(1500000, 1200000);

            // Calculations of labor potential of population
            city.DescriptionOfLaborPotential();
            city.MessageBeforeCalculationOfLabor();
            cityLaborPotential = city.LaborPotentialOfPopulation(20000, 250, 8, 0.8);

            Console.WriteLine();

            country.MessageBeforeCalculationOfLabor();
            countryLaborPotential = country.LaborPotentialOfPopulation(15000, 290, 12, 0.9);

            Console.WriteLine("\n");

            // Calculations of increase/decrease of investments in future
            city.DescriptionBeforeCalculationOfInvestments();
            city.MessageBeforeCalculationOfIncreaseOfInvestments();
            cityResultOfInvests = city.IncreaseOfInvestments(1500000, 650000, 12, 5);

            Console.WriteLine();

            country.MessageBeforeCalculationOfIncreaseOfInvestments();
            countryResultOfInvests = country.IncreaseOfInvestments(1000000, 400000, 10, 5);

            Console.WriteLine();

            // Calculation of whole economic potential
            double allEconimicPotentialOfCity = cityIndustrialIncome + cityLaborPotential + cityResultOfInvests,
                allEconimicPotentialOfCountry = countryIndustrialIncome + countryLaborPotential + countryResultOfInvests;

            Console.Write($"\n+--- Economic potential of the {city.Name} ---+\n"
                + "|EP = II + ELP + RoI\n"
                + "| where: II is industrial income of the city,\n"
                + "|        ELP is economic labor potential,\n"
                + "|        RoI is result of invests.\n"
                + $"|EP = {cityIndustrialIncome:C} + {cityLaborPotential:C} + {cityResultOfInvests:C} = {allEconimicPotentialOfCity:C}\n"
                + $"+--- Economic potential of the {country.Name} ---+\n"
                + $"|EP = {countryIndustrialIncome:C} + {countryLaborPotential:C} + {countryResultOfInvests:C} = {allEconimicPotentialOfCountry:C}\n");
        }
    }
}