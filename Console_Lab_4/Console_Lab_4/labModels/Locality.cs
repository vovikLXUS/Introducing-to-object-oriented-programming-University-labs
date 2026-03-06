using System;
using System.Security.Cryptography;

namespace Console_Lab_4.labModels
{
    public class Locality
    {
        private double sizeOfTerritory;
        private long population;
        private string location;
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
        public Locality()
        {
            sizeOfTerritory = 0.0;
            population = 0;
            location = "";
        }
        public Locality(double sizeOfTerritory, long population, string location)
        {
            SizeOfTerritory = sizeOfTerritory;
            Population = population;
            Location = location;
        }
        public void PrintPartialInfo()
        {
            Console.Write($"|Population:            {Population}\n"
                + $"|Size of territory:     {SizeOfTerritory} km in square\n"
                + "+--------------------------------------------------------------+\n");
        }
        /// <summary>
        /// Розрахунок приросту доходів від промисловості, який має за мету оцінити збільшення 
        /// обсягів виробництва, реалізації продукції або прибутку підприємства
        /// </summary>
        /// <param name="presentClearIncome">чистий дохід за теперішній рік</param>
        /// <param name="previousClearIncome">чистий дохід за минулий рік</param>
        /// <returns>кількість прибутку підприємства</returns>
        public double GrowthInIndustrialIncome(double presentClearIncome, double previousClearIncome)
        {
            double absoluteIncrease = presentClearIncome - previousClearIncome;
            double percentageIncrease = (absoluteIncrease / previousClearIncome) * 100.0;

            Console.Write("\n|Growth in industrial income: D(prom) = P1 - P0"
                + "\n|where: D(prom) is growth (increase)"
                + "\n|       P1 is estimated amount"
                + "\n|       P0 is basic amount"
                + $"\n|        - Main calculations -"
                + $"\n|Absolute increase = {presentClearIncome:C} - {previousClearIncome:C}"
                + $"\n|          D(prom) = {absoluteIncrease:C}"
                + $"\n|Percentage increase = {percentageIncrease}%"
                + "\n+--------------------------------------------------------------+\n");
            return absoluteIncrease;
        }
        public void DescriptionOfLaborPotential()
        {
            Console.Write("\n+---------------------------- Labor Potential ----------------------------+"
                + "\n|It's calculalated as follows: first we have to find the annual"
                + "\n|fund and then the real labor potential of population:"
                + "\n| RLP = AF * C , where AF is annual fund"
                + "\n| (working-age population * amount of working days * duration of work day)"
                + "\n| and C is coefficient of actual working time use.\n"
                + "+-------------------------------------------------------------------------+");
        }
        /// <summary>
        /// Основний розрахунок трудового потенціалу населення для визначення сукупної кількості
        /// робочого часу, який може бути відпрацьований працездатними громадянами
        /// </summary>
        /// <param name="workingAgePopulation">кількість населення працездатного віку</param>
        /// <param name="amountOfWorkingDays">кількість робочих днів у році</param>
        /// <param name="durationOfWorkingDay">тривалість робочого дня</param>
        /// <param name="coefficientOfActualUse">коефіцієнт реального використання робочого часу
        /// (з врахуванням хвороб, відпусток та тому подібного)</param>
        public double LaborPotentialOfPopulation(int workingAgePopulation, int amountOfWorkingDays,
            int durationOfWorkingDay, double coefficientOfActualUse)
        {
            int minWage = 53; // Мінімальна ставка за годину в Україні
            // Річний фонд (максимальна кількість запланових годин роботи)
            long annualFund = workingAgePopulation * amountOfWorkingDays * durationOfWorkingDay;

            // Розрахунок загальної кількості планових робочих годин населення
            double realLaborPotential = annualFund * coefficientOfActualUse,
                realEconomicLaborPotential = realLaborPotential * minWage;

            Console.Write("\n|                           - Main calculations -"
                       + $"\n|AF = {workingAgePopulation} * {amountOfWorkingDays} * {durationOfWorkingDay} = {annualFund},"
                       + $"\n|RLP = {annualFund} * {coefficientOfActualUse} = {realLaborPotential} all hours per year."
                       + $"\n|Finally, real minimal labor potential of locality in Ukraine is {realEconomicLaborPotential:C}.");

            return realEconomicLaborPotential;
        }
        public void DescriptionBeforeCalculationOfInvestments()
        {
            Console.Write("\n+----------- Calculation of future of the investments -----------+"
                + "\n|For first, it is the difference between the discounted revenues"
                + "\n|and costs of the project, which is determined through the net"
                + "\n|discounted income. The formula is:"
                + "\n|       n   / /      Annual income     \\                        \\"
                + "\n| Sum = S  | | ------------------------ | - first invested funds |"
                + "\n|      t=1  \\ \\  (1 + discount rate)^t /                        /\n");
        }
        /// <summary>
        /// Розрахунок отриманих коштів з інвестицій під конкретний відсоток
        /// та оцінка майбутнього цієї інвестиції
        /// </summary>
        /// <param name="firstInvestments">перші внесені кошти</param>
        /// <param name="annualClearFunds">річний чистий дохід</param>
        /// <param name="discountRate">ставка дисконтування</param>
        /// <param name="yearsUnderInvestments">кількість років утримання інвестиційних грошей</param>
        /// <returns>різницю між сумою чистого доходу та першим вкладенням
        /// та відповідно цього виводить повідомлення в залежності від знака різниці</returns>
        public double IncreaseOfInvestments(int firstInvestments, int annualClearFunds,
            int discountRate, int yearsUnderInvestments)
        {
            double discountIncome = 0.0,
                 sumOfDiscountIncome = 0.0;
            double realDiscountRate = discountRate / 100.0;
            //TODO: гарний вивід підрахунків інвестицій під відсотком
            for (int t = 1; t <= yearsUnderInvestments; t++)
            {
                discountIncome = (annualClearFunds / Math.Pow(1 + realDiscountRate, t));
                //Console.Write($"\nDuring year {t}: income is {discountIncome:C}");
                sumOfDiscountIncome += discountIncome;
            }
            //Console.WriteLine();
            //TODO: вивід розрахунку різниці
            double difference = sumOfDiscountIncome - firstInvestments;
            if (difference > 0)
            {
                Console.Write($"\n|Investments (at size of {firstInvestments:C}) will be possitive returned"
                    + $"\n|in {yearsUnderInvestments} years. The difference between first investement"
                    + $"\n|and funds, which locality will get, is {difference:C}.\n");
            }
            else
            {
                Console.Write($"\n|Investments (at size of {firstInvestments:C}) will not be possitive"
                    + $"\n|returned in {yearsUnderInvestments} years. The difference between first investement"
                    + $"\n|and funds, which locality will get, is {difference:C}.\n");
            }
            return difference;
        }
    }
}