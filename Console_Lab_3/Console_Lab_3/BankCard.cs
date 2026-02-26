using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Lab_3
{
    public static class BankCard
    {
        public static decimal depositAmount;
        public static double interestRatio;
        public static decimal DepositAmount
        {
            get
            {
                return depositAmount;
            }
            set
            {
                depositAmount = value;
            }
        }
        public static decimal InterestRatio
        {
            get
            {
                return (decimal)interestRatio;
            }
            set
            {
                interestRatio = (double)value;
            }
        }

    }
}
