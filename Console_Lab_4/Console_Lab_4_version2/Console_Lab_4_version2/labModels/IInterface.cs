using System;
using System.Text;

namespace Console_Lab_4_version2.labModels
{
    interface IEconomicPotential
    {
        void TellAboutIndustrialIncome();
        void TellAboutLaborPotential();
        void TellAboutInvestmentsFuture();
        void TellAboutEconomicPotential();
        double GrowthInIndustry(double enterprisesQuantity, double coefficient1,
                                double productionVolume, double coefficient2,
                                double technologyLevel, double coefficient3);
        public double LaborPotential(double workingAge, double coefficient1,
                                     double educationLevel, double coefficient2,
                                     double employmentRate, double coefficient3);
        public double InvetsmentsPotential(double financialInvests, double coefficient1,
                                           double businessDevelopment, double coefficient2,
                                           double infrastructDevelopment, double coefficient3);
        public double EconomicPotential(double industrialIncome, double wC1,
                                        double laborPotential, double wC2,
                                        double investsPotential, double wC3);
    }
}
