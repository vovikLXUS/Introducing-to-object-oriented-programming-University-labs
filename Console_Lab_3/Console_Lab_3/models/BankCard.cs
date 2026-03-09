using System;
using System.Text;

namespace Console_Lab_3.models
{
    public static class BankCard
    {
        /// <summary>
        /// Розрахунок відсотків, які нараховуються на депозитну суму за певний період часу.
        /// </summary>
        /// <param name="depositAmount">депозит клієнта</param>
        /// <param name="interestRatio">відсоткова ставка</param>
        /// <returns>нараховані відсотки</returns>
        public static decimal DepositAmount(decimal depositAmount, double interestRatio)
        {
            return depositAmount * (decimal)(interestRatio / 100.0);
        }
        /// <summary>
        /// Додавання депозиту до балансу клієнта з урахуванням нарахованих відсотків. 
        /// Користувач вводить суму депозиту та відсоткову ставку, після чого система 
        /// розраховує нараховані відсотки та додає їх до депозитної суми, оновлюючи 
        /// баланс клієнта. Виводиться інформація про суму депозиту, нараховані відсотки, 
        /// загальну суму, додану до балансу, та оновлений баланс клієнта.
        /// </summary>
        /// <param name="client">посилання на об'єкт клієнта</param>
        public static void AddDepositToClientBalance(Client client)
        {
            Console.Write("\n+------------ Deposit calculation ------------+\n"
               + $"|Client balance before deposit: {client.Balance:C}\n"
               + "|Enter deposit amount: ");
            decimal depositAmount;
            
            while (!decimal.TryParse(Console.ReadLine(), out depositAmount) || depositAmount <= 0)
            {
                Console.Write("\n|Invalid input. Please enter a positive decimal number for the deposit amount: ");
            }

            Console.Write("|Enter interest rate (in %): ");
            double interestRatio;

            while (!double.TryParse(Console.ReadLine(), out interestRatio) || interestRatio < 0)
            {
                Console.Write("\n|Invalid input. Please enter a non-negative number for the interest rate: ");
            }

            // Розрахунок відсотків та оновлення балансу клієнта
            decimal interest = DepositAmount(depositAmount, interestRatio);
            decimal totalAmount = depositAmount + interest;

            client.Balance += (int)totalAmount;

            Console.Write($"\n|Deposit amount: {depositAmount:C}\n"
               + $"|Interest earned: {interest:C}\n"
               + $"|Total amount added to balance: {totalAmount:C}\n"
               + $"|Client balance after deposit: {client.Balance:C}\n"
               + "+---------------------------------+\n");
        }
    }
}