using System;
using System.Xml.Linq;

namespace Console_Lab_4_version2.labModels
{
    public class Locality : IEconomicPotential 
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
                + "+------------------------------------------------------------------+\n");
        }
        public void TellAboutIndustrialIncome()
        {
            Console.Write("\n+----------------------- Potential in industry ----------------------+"
                + "\n|Growth in industry: P = N * a1 + G * a2 + T * a3"
                + "\n| where: P is growth (or  increase),  N is number of enterprises"
                + "\n|        G is volume of production, T is level of technology"
                + "\n|        and a1, a2, a3 are weighting coefficient (more precisely the"
                + "\n|        importance of each component). ! a1 + a2 + a3 = 1 !");
        }
        public void TellAboutLaborPotential()
        {
            Console.Write("\n+---------------------------- Labor Potential ----------------------------+"
                + "\n|Labor potential of population: LP = W * b1 + Ed * b2 + Emp * b3,"
                + "\n| where: LP is labor potential, W is working-age population,"
                + "\n|        Ed is education level, Emp is employment rate"
                + "\n|        and b1, b2, b3 are coefficients of importance.\n"
                + "+-------------------------------------------------------------------------+");
        }
        public void TellAboutInvestmentsFuture()
        {
            Console.Write("\n+--------------------- Investments Potential ---------------------+"
                + "\n|Investments potential: IP = F * c1 + B * c2 + D * c3"
                + "\n| where: F is dinancial investments, B is business development,"
                + "\n|        D is infrastructure development and cN are coefficients.\n");
        }
        public void TellAboutEconomicPotential()
        {
            Console.Write("\n+--------------------------------- Economic potential ---------------------------------+\n"
                + "|Whole economic potential: WEP = P * wC1 + LP * wC2 + IP * wC3\n"
                + "| where: P is index of industry potential, LP is index of labor potential,\n"
                + "|        IP is index of investments potential,\n"
                + "|        wCN is weighting coefficients of variables.\n");
        }
        /// <summary>
        /// Розрахунок приросту доходів від промисловості, який має за мету оцінити економічний 
        /// потенціал у вигляді приросту доходів від промисловості
        /// </summary>
        /// <param name="enterprisesQuantity">кількість підприємств місцевості</param>
        /// <param name="coefficient1">ваговий коефіцієнт 1 (індекс того, на скільки це важливий фактор)</param>
        /// <param name="productionVolume">обсяг виробництва продуктів</param>
        /// <param name="coefficient2">ваговий коефіцієнт 2</param>
        /// <param name="technologyLevel">технологічний рівень</param>
        /// <param name="coefficient3">ваговий коефіцієнт 3</param>
        /// <returns></returns>
        public double GrowthInIndustry(double enterprisesQuantity, double coefficient1,
                                       double productionVolume, double coefficient2,
                                       double technologyLevel, double coefficient3)
        {
            double absoluteIncrease = enterprisesQuantity * coefficient1
                                    + productionVolume * coefficient2
                                    + technologyLevel * coefficient3;

            Console.Write($"\n|                        - Main calculations -"
                        + $"\n|P = {enterprisesQuantity} * {coefficient1} + {productionVolume} * {coefficient2} + {technologyLevel} * {coefficient3}"
                        + $"\n|P = {absoluteIncrease} ~ {absoluteIncrease:F3}"
                         + "\n+--------------------------------------------------------------------+\n");

            return absoluteIncrease;
        }
        /// <summary>
        /// Основний розрахунок трудового потенціалу населення для визначення сукупної оцінкм
        /// </summary>
        /// <param name="workingAge">населення працездатного віку</param>
        /// <param name="coefficient1">ваговий коефіцієнт першого множника</param>
        /// <param name="educationLevel">рівень освіти населення</param>
        /// <param name="coefficient2">ваговий коефіцієнт другого множника</param>
        /// <param name="employmentRate">рівень зайнятості населення</param>
        /// <param name="coefficient3">ваговий коефіцієнт третього множника</param>
        /// <returns>значення індексу трудового потенціалу населення</returns>
        public double LaborPotential(double workingAge, double coefficient1,
                                     double educationLevel, double coefficient2,
                                     double employmentRate, double coefficient3)
        {
            // Основний розрахунок трудового потенціалу
            double laborPotential = workingAge * coefficient1
                                  + educationLevel * coefficient2
                                  + employmentRate * coefficient3;

            Console.Write("\n|                         - Main calculations -"
                       + $"\n|LP = {workingAge} * {coefficient1} + {educationLevel} * {coefficient2} + {employmentRate} * {coefficient3},"
                       + $"\n|LP = {laborPotential} ~ {laborPotential:F3}."
                       + "\n+--------------------------------------------------------------------------+");

            return laborPotential;
        }
        /// <summary>
        /// Розрахунок економічного потенціалу від інвестицій з врахуванням фінансових
        /// інвестицій, розвитку бізнесу та інфраструктури, та їхніх вагових коефіцієнтів
        /// </summary>
        /// <param name="financialInvests">фінансові інвестиції</param>
        /// <param name="coefficient1">ваговий коефіцієнт першого множника</param>
        /// <param name="businessDevelopment">розвиток бізнесу</param>
        /// <param name="coefficient2">ваговий коефіцієнт другого множника</param>
        /// <param name="infrastructDevelopment">розвиток інфраструктури</param>
        /// <param name="coefficient3">ваговий коефіцієнт третього множника</param>
        /// <returns>значення індексу економічного потенціалу від інвестицій</returns>
        public double InvetsmentsPotential(double financialInvests, double coefficient1,
                                           double businessDevelopment, double coefficient2,
                                           double infrastructDevelopment, double coefficient3)
        {
            double investsPotential = financialInvests * coefficient1
                                    + businessDevelopment * coefficient2
                                    + infrastructDevelopment * coefficient3;

            Console.Write("\n|                      - Main calculations -"
                       + $"\n|LP = {financialInvests} * {coefficient1} + {businessDevelopment} * {coefficient2} + {infrastructDevelopment} * {coefficient3},"
                       + $"\n|LP = {investsPotential} ~ {investsPotential:F3}."
                       + "\n+-----------------------------------------------------------------+");

            return investsPotential;
        }
        /// <summary>
        /// Розрахунок всього економічного потенціалу місцевості за врахуванням результатів розрахунків
        /// у вигляді приросту доходів від промисловості, трудового потенціалу від населення та інвестицій
        /// </summary>
        /// <param name="industrialIncome">результат розрахунку потенціалу від промисловості</param>
        /// <param name="wC1">ваговий коефіцієнт першого множника</param>
        /// <param name="laborPotential">результат розрахунку трудового потенціалу</param>
        /// <param name="wC2">ваговий коефіцієнт другого множника</param>
        /// <param name="investsPotential">результат розрахунку потенціалу інвестицій</param>
        /// <param name="wC3">ваговий коефіцієнт третього множника</param>
        /// <returns>значення індекса всього економічного потенціалу</returns>
        public double EconomicPotential(double industrialIncome, double wC1,
                                        double laborPotential, double wC2,
                                        double investsPotential, double wC3)
        {
            double wholeEconomicPotential = industrialIncome * wC1
                                          + laborPotential * wC2
                                          + investsPotential * wC3;

            Console.Write($"|WEP = {industrialIncome:F3} * {wC1} + {laborPotential:F3} * {wC2} + {investsPotential:F3} * {wC3} = {wholeEconomicPotential:F3}.\n"
                + "+--------------------------------------------------------------------------------------+");

            return wholeEconomicPotential;
        }
    }
}