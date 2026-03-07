using Console_Lab_4.labModels;
using System;
using System.Text;

namespace Console_Lab_4_version_1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            double cityIndustryIndex = 0.0,
                cityLaborIndex = 0.0,
                cityInvestsIndex = 0.0;

            double countryIndustryIndex = 0.0,
                countryLaborIndex = 0.0,
                countryInvestsIndex = 0.0;

            Locality locality = new Locality();
            // Initializations of city/country
            City city = new City("Kyiv", 106000000000, "It is characterized by significant elevation differences." +
                "The right bank is high and hilly (Kiev Mountains), the left bank is low and flat.",
                839, 3400000, "is located in the middle reaches of the Dnipro River, which divides it into two parts.");

            Country country = new Country("Sofia Borshchagovka", 197489197, "is located in the west of the Kyiv oblast",
                7.08, 27500, "Typical Polissya area with lakes and flat terrain.");

            // Output info about city/country
            city.PrintCityInfo();
            Console.WriteLine();
            country.PrintCountryInfo();

            // Calculations of increase of industrial income
            locality.TellAboutIndustrialIncome();
            city.MessageBeforeCalculationOfIncrease();

            // Промисловий потенціал Києва: індекси поставлені з врахуванням певних чинників, а саме:
            // кількість підприємств (досить велика), обсяг виробництва продукції (дуже великий) та 
            // технологічний рівень (який також досить високий)
            cityIndustryIndex = city.GrowthInIndustry(0.85, 0.3, 0.90, 0.5, 0.80, 0.2);

            country.MessageBeforeCalculationOfIncrease();

            // Промисловий потенціал Софіївської Борщагівки: мало підприємст, невелике виробництво
            // та середній технологічний рівень
            countryIndustryIndex = country.GrowthInIndustry(0.25, 0.4, 0.30, 0.4, 0.40, 0.2);

            // Calculations of labor potential of population
            locality.TellAboutLaborPotential();
            city.MessageBeforeCalculationOfLabor();

            // Трудовий потенціал Києва: велика кількість працездатного населення, досить високий рівень
            // освіти та високий рівень зайнятості населення
            cityLaborIndex = city.LaborPotential(0.90, 0.5, 0.85, 0.2, 0.75, 0.3);

            Console.WriteLine();

            country.MessageBeforeCalculationOfLabor();
            // Трудовий потенціал Софіївської Борщагівки: досить велика кількість працездатного населення
            // (більшість працюють в Києві), досить високий рівень освіти та високий рівень зайнятості
            countryLaborIndex = country.LaborPotential(0.55, 0.55, 0.65, 0.15, 0.70, 0.30);

            Console.WriteLine();

            // Calculations of increase/decrease of investments in future
            locality.TellAboutInvestmentsFuture();
            city.MessageBeforeCalculationOfIncreaseOfInvestments();

            // Економічний потенціал інвестицій Києва: дуже великі інвестиції,
            // розвинений бізнес та дуже розвинена інфраструктура
            cityInvestsIndex = city.InvetsmentsPotential(0.95, 0.4, 0.90, 0.35, 0.90, 0.25);


            country.MessageBeforeCalculationOfIncreaseOfInvestments();

            // Економічний потенціал інвестицій Софіївської Борщагівки: оскільки тут активно будують житло,
            // опираємось на це: досить великі інвестиції, розвинений бізнес та інфраструктура
            countryInvestsIndex = country.InvetsmentsPotential(0.60, 0.35, 0.55, 0.35, 0.60, 0.30);

            Console.WriteLine();

            // Calculation of whole economic potential
            locality.TellAboutEconomicPotential();
            city.MessageBeforeCalculationOfEcoPot();
            city.EconomicPotential(cityIndustryIndex, 0.45, cityLaborIndex, 0.35, cityInvestsIndex, 0.20);

            country.MessageBeforeCalculationOfEcoPot();
            country.EconomicPotential(countryIndustryIndex, 0.30, countryLaborIndex, 0.40, countryInvestsIndex, 0.30);

            Console.WriteLine();
        }
    }
}