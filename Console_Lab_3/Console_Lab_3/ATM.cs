using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace Console_Lab_3
{
    public class ATM
    {
        private string bankName;
        private int ID;
        private string placement;
        private int cashAmount;
        public string BankName
        {
            get
            {
                return bankName;
            }
            set
            {
                bankName = value;
            }
        }
        public int IDNumber
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }
        public string Placement
        {
            get
            {
                return placement;
            }
            set
            {
                placement = value;
            }
        }
        public int CashAmount
        {
            get
            {
                return cashAmount;
            }
            set
            {
                cashAmount = value;
            }
        }
        public ATM()
        {
            bankName = "";
            ID = 0;
            placement = "";
            cashAmount = 0;
        }
        public ATM(string bankName, int ID, string placement, int cashAmount)
        {
            this.bankName = bankName;
            this.ID = ID;
            this.placement = placement;
            this.cashAmount = cashAmount;
        }
        public int GetInt(string request)
        {
            int result;

            Console.Write(request);
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Error: please enter a valid integer.");
                Console.Write(request);
            }
            return result;
        }
        public long GetLong(string request)
        {
            long result;

            Console.Write(request);
            while (!long.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Error: please enter a valid integer.");
                Console.Write(request);
            }
            return result;
        }
        public void PrintATMInfo()
        {
            Console.Write("\n+======== ATM Info =========+\n"
                + $"|Bank name: {BankName}\n"
                + $"|ID number: {IDNumber}\n"
                + $"|Placement: {Placement}\n"
                + $"|Cash amount: {CashAmount:C}\n"
                + "+===========================+\n");
        }
        public void OutPutATMInfoToFile()
        {
            string filePath = "ATMInfo.txt";

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.Write($"\n+======== ATM Info =========+\n"
                    + $"|Bank name: {BankName}\n"
                    + $"|ID number: {IDNumber}\n"
                    + $"|Placement: {Placement}\n"
                    + $"|Cash amount: {CashAmount:C}\n"
                    + "+===========================+\n");
            }
        }
        public void InitializeATM()
        {
            Console.Write("\n=== Initialize ATM ===\n"
                + "Enter the name of the bank: ");
            bankName = Console.ReadLine();
            
            ID = GetInt("Enter the ID number (4 digits): ");
            if (ID < 1000 || ID > 9999)
            {
                Console.WriteLine("Error: ID number must be 4 digits.");
                ID = GetInt("Enter the ID number correctly (4 digits): ");
            }
            Console.Write("Enter the placement of the ATM (street): ");
            placement = Console.ReadLine();

            cashAmount = GetInt("Enter the cash amount (in UAH): ");

            PrintATMInfo();

            OutPutATMInfoToFile();
        }
        public void EnterPIN(Client client)
        {
            int enteredPIN = GetInt("Enter your PIN code: ");

            int attempts = 3;

            if (enteredPIN != client.PINCode)
            {
                while (attempts > 0)
                {
                    Console.WriteLine("Error: Incorrect PIN code.");
                    enteredPIN = GetInt("Enter your PIN code: ");
                    if (enteredPIN == client.PINCode)
                    {
                        Console.WriteLine("PIN code accepted.");
                        return;
                    }
                    attempts--;
                }
                Console.WriteLine("Error: Too many failed attempts.");
            }
        }
        public bool Authenticate(Client client)
        {
            Console.Write("\n---- Authentication ----\n");
            long enteredCardNumber = GetLong("Enter your card number (16 digits): ");
            if (enteredCardNumber != client.CardNumber)
            {
                Console.WriteLine("Error: Incorrect card number.");
                return false;
            }
            Console.WriteLine("Card number accepted.");

            EnterPIN(client);

            return true;
        }
        public void ShowATMOptions(Client client)
        {
            if (!Authenticate(client))
                return;
            
            int request;

            do
            {
                Console.Write("\n+---- ATM Options ----+\n"
                    + "|1. Check your balance\n"
                    + "|2. Cash withdrawal\n"
                    + "|3. Top-up\n"
                    + "|4. Change PIN code\n"
                    + "|0. Exit\n"
                    + "+---------------------+\n");

                request = GetInt("Your request: ");

                switch (request)
                {
                    case 1:
                        client.CheckBalance(this);
                        break;
                    case 2:
                        client.CashWithdrawal(this);
                        break;
                    case 3:
                        client.AccountTopUp(this);
                        break;
                    case 4:
                        client.ChangePIN();
                        break;
                    case 0:
                        Console.WriteLine("Thank you for using our ATM. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Error: Invalid option. Please try again.");
                        break;
                }
            } while (request != 0);
        }
    }
}