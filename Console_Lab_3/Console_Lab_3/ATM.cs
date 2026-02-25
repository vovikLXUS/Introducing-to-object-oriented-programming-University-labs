using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Text;

namespace Console_Lab_3
{
    public class ATM
    {
        private string atmBankName;
        private string ID;
        private string placement;
        private int cashAmount;
        public string ATMBankName
        {
            get
            {
                return atmBankName;
            }
            set
            {
                atmBankName = value;
            }
        }
        public string IDNumber
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
            atmBankName = "";
            ID = "";
            placement = "";
            cashAmount = 0;
        }
        public ATM(string atmBankName, string ID, string placement, int cashAmount)
        {
            this.atmBankName = atmBankName;
            this.ID = ID;
            this.placement = placement;
            this.cashAmount = cashAmount;
        }
        public class Bank
        {
            private string bankName;
            private string bankAddress;
            private string clientBankID;
            private int clientBankCashAmount;
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
            public string BankAddress
            {
                get
                {
                    return bankAddress;
                }
                set
                {
                    bankAddress = value;
                }
            }
            public string ClientBankID
            {
                get
                {
                    return clientBankID;
                }
                set
                {
                    clientBankID = value;
                }
            }
            public int ClientBankCashAmount
            {
                get
                {
                    return clientBankCashAmount;
                }
                set
                {
                    clientBankCashAmount = value;
                }
            }
            public Bank()
            {
                bankName = "";
                bankAddress = "";
                clientBankID = "";
                clientBankCashAmount = 0;
            }
            public Bank(string bankName, string bankAddress, string clientID, int clientCashAmount)
            {
                this.bankName = bankName;
                this.bankAddress = bankAddress;
                this.clientBankID = clientID;
                this.clientBankCashAmount = clientCashAmount;
            }
            public void PrintClientInBankInfo()
            {
                Console.Write("\n+=========== Bank Info ===========+\n"
                    + $"|Bank name: {bankName}\n"
                    + $"|Bank address: {bankAddress}\n"
                    + $"|Client ID: {clientBankID}\n"
                    + $"|Client cash amount: {clientBankCashAmount:C}\n"
                    + "+=================================+\n");
            }
            public void OutputClientInBankInfoToFile()
            {
                string filePath = "BankInfo.txt";

                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.Write($"\n+=========== Bank Info ===========+\n"
                        + $"|Bank name: {bankName}\n"
                        + $"|Bank address: {bankAddress}\n"
                        + $"|Client ID: {clientBankID}\n"
                        + $"|Client cash amount: {clientBankCashAmount:C}\n"
                        + "+=================================+\n");
                }
            }
            public void InitializeClientInBank()
            {
                Console.Write("\n+--- Initialize client in Bank ---+\n"
                    + "Enter name of the bank: ");
                bankName = Console.ReadLine();

                Console.Write("Enter address of the bank: ");
                bankAddress = Console.ReadLine();

                Console.Write("Enter your ID (8 digits): ");
                clientBankID = Console.ReadLine();

                while (clientBankID.Length < 8 || clientBankID.Length > 8 || !long.TryParse(clientBankID, out _))
                {
                    Console.Write("\nYour ID must be 8 digits long!"
                        + "\nEnter your ID correctly: ");
                    clientBankID = Console.ReadLine();
                }

                clientBankCashAmount = GetInt("Enter your bank's cash amount: ");
                while (clientBankCashAmount < 0)
                {
                    Console.Write("Your bank's cash amount must be greater than 0.");

                    clientBankCashAmount = GetInt("Enter your bank's cash amount correctly: ");
                }
                Console.Write("+-----------------------------------+\n");

                PrintClientInBankInfo();

                OutputClientInBankInfoToFile();
            }
            public void BankDeposit()
            {
                int amount = GetInt("Enter the amount to deposit (in UAH): ");
                while (amount < 0)
                {
                    Console.Write("Your deposit must be greater than 0.\n");

                    amount = GetInt("Enter your deposit correctly: ");
                }

                clientBankCashAmount += amount;

                Console.Write($"\nYour account deposited by {amount:C}.\n");
            }
            public bool BankWithdrawal()
            {
                int amount = GetInt("Enter the amount of cash withdrawal: ");

                if (amount < 0)
                {
                    Console.Write("\nYour withdrawal must be greater than 0.");
                    return false;
                }

                if (amount > clientBankCashAmount)
                {
                    Console.Write("\nThere are not enough money.");
                    return false;
                }

                clientBankCashAmount -= amount;
                Console.Write($"\nYour cash withdrawal of {amount:C} successful.\n");

                return true;
            }
            public void CheckBankBalance()
            {
                Console.Write("\n+-------------- Balance --------------+"
                    + $"\n|There are {clientBankCashAmount:C} on your account."
                    + "\n+-------------------------------------+\n");
            }
            //public void Receiver()
            //{
            //    Console.Write("+----------- Receiver -----------+\n"
            //        + "\nEnter name of the bank: ");
            //    string newBankName = Console.ReadLine();

            //    Console.Write("\nEnter address of the bank: ");
            //    string newBankAddress = Console.ReadLine();

            //    long newClientBankID = GetLong("Enter your ID (8 digits): ");
            //    while (newClientBankID > 99999999)
            //    {
            //        Console.Write("\nYour ID must to be 8 digits long!");

            //        newClientBankID = GetLong("Enter your ID correctly: ");
            //    }
            //    Console.Write("+--------------------------------+\n");
            //}
            public bool BankTransfer()
            {
                Console.Write("+---------------- Receiver ----------------+\n"
                    + "|Enter name of the bank: ");
                string newBankName = Console.ReadLine();

                Console.Write("|Enter address of the bank: ");
                string newBankAddress = Console.ReadLine();

                Console.Write("|Enter the receiver's name: ");
                string newClientName = Console.ReadLine();

                Console.Write("|Enter the receiver's surname: ");
                string newClientSurname = Console.ReadLine();

                Console.Write("|Enter ID (8 digits): ");
                string newClientBankID = Console.ReadLine();

                while (newClientBankID.Length > 8 || !long.TryParse(newClientBankID, out _))
                {
                    Console.Write("\nID must to be 8 digits long!"
                        + "\nEnter ID correctly: ");

                    newClientBankID = Console.ReadLine();
                }
                Console.Write("+------------------------------------------+\n");

                Bank newClient = new Bank(newBankName, newBankAddress, newClientBankID, 0);

                int amount = GetInt("Enter cash amount to transfer: ");

                if (amount > clientBankCashAmount)
                {
                    Console.Write($"\nThere are not enough money to transfer {amount:C}."
                        + "\nTransfer failed.");
                    return false;
                }
                else if (amount <= 0)
                {
                    Console.Write($"\nThe cash amount must be greater than 0."
                        + "\nTransfer failed.");
                    return false;
                }

                clientBankCashAmount -= amount;
                newClient.clientBankCashAmount += amount;

                Console.Write("\n+-----------------------+"
                            + $"\n|Receiver: {newBankName}\n"
                    + $"|\t   {newBankAddress}\n"
                    + $"|\t   {newClientName}\n"
                    + $"|\t   {newClientSurname}\n"
                    + $"|\t   {newClientBankID}\n"
                    + "+-----------------------+"
                    + $"\nThe transfer of {amount:C} successful.\n");

                return true;
            }
            public bool BankPayUtility()
            {
                int utilitiesCost = 3500;

                Console.Write("\n+-------- Pay for utilities --------+\n"
                    + $"|The sum of utilities is: {utilitiesCost:C}\n"
                    + $"|and you balance is: {clientBankCashAmount:C}.\n"
                    + "+-----------------------------------+\n");

                int choice = GetInt("Do you want to pay for utilities (1/0): ");

                if (choice == 0)
                {
                    Console.Write("\nPayment canceled.\n");
                    return false;
                }

                Console.Write("\n+-------------------------------------"
                    + "\n|Payment is in progress...");

                if (clientBankCashAmount - utilitiesCost < 0)
                {
                    Console.Write("\n|Payment canceled because there is not"
                        + "\n|enough money on your balance."
                        + "\n+-------------------------------------\n");
                    return false;
                }

                clientBankCashAmount -= utilitiesCost;

                Console.Write("\n|The payment for utilities successful."
                    + "\n+-------------------------------------"
                    + $"\nYours remainings: {clientBankCashAmount:C}.\n");

                return true;
            }
        }
        public void BankOptionsForUser(Bank bank)
        {
            int choice;

            do
            {
                Console.Write("\n+-------- Bank options --------+"
                    + "\n|1. Initialize client in a bank"
                    + "\n|2. Deposit your account"
                    + "\n|3. Cash withdrawal"
                    + "\n|4. Check balance"
                    + "\n|5. Transfer your money"
                    + "\n|6. Pay for utilities"
                    + "\n|0. Exit"
                    + "\n+------------------------------+\n");

                choice = GetInt("Your choice: ");

                switch (choice)
                {
                    case 1:
                        bank.InitializeClientInBank();
                        break;
                    case 2:
                        bank.BankDeposit();
                        break;
                    case 3:
                        bank.BankWithdrawal();
                        break;
                    case 4:
                        bank.CheckBankBalance();
                        break;
                    case 5:
                        bank.BankTransfer();
                        break;
                    case 6:
                        bank.BankPayUtility();
                        break;
                    case 0:
                        Console.WriteLine("Exiting from options...");
                        break;
                    default:
                        Console.WriteLine("Invalid input, try again.\n");
                        break;
                }
            } while (choice != 0);
        }
        static int GetInt(string request)
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
        static long GetLong(string request)
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
                + $"|Bank name: {ATMBankName}\n"
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
                    + $"|Bank name: {ATMBankName}\n"
                    + $"|ID number: {IDNumber}\n"
                    + $"|Placement: {Placement}\n"
                    + $"|Cash amount: {CashAmount:C}\n"
                    + "+===========================+\n");
            }
        }
        public void InitializeATM()
        {
            Console.Write("\n+------------------ Initialize ATM ------------------+\n"
                + "Enter the name of the bank: ");
            atmBankName = Console.ReadLine();

            Console.Write("Enter the ID number (4 digits): ");
            ID = Console.ReadLine();

            while (ID.Length < 4 || ID.Length > 4)
            {
                Console.WriteLine("Error: ID number must be 4 digits."
                    + "\nEnter the ID number correctly: ");
                ID = Console.ReadLine();
            }

            Console.Write("Enter the placement of the ATM (street): ");
            placement = Console.ReadLine();

            cashAmount = GetInt("Enter the cash amount (in UAH): ");

            while (cashAmount < 0)
            {
                Console.Write("Cash amount must be greater than 0.");
                cashAmount = GetInt("Enter the cash amount correctly (in UAH): ");
            }
            Console.Write("+----------------------------------------------------+\n");

            PrintATMInfo();

            OutPutATMInfoToFile();
        }
        public void EnterPIN(Client client)
        {
            Console.Write("\nEnter your PIN code: ");
            string enteredPIN = Console.ReadLine();

            int attempts = 3;

            if (enteredPIN != client.PINCode)
            {
                while (attempts > 0)
                {
                    Console.WriteLine("Error: Incorrect PIN code."
                        + "Enter your PIN code: ");
                    enteredPIN = Console.ReadLine();

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
            Console.Write("\n+------------------ Authentication -----------------+\n");
            long enteredCardNumber = GetLong("Enter your card number (16 digits): ");
            if (enteredCardNumber != client.CardNumber)
            {
                Console.WriteLine("Error: Incorrect card number.");
                return false;
            }
            Console.Write("Card number accepted.");

            EnterPIN(client);
            // "+--------------------------------------------------+\n"
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