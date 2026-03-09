using Console_Lab_3.models;
using System;
using System.Text;

namespace Console_Lab_3
{
    public partial class ATM
    {
        private string atmBankName; // Назва банку, до якого належить банкомат
        private string ID; // Унікальний ідентифікатор банкомату (4 цифри)
        private string placement; // Розташування банкомату
        private int cashAmount; // Кількість готівки в банкоматі
        // Властивості для доступу до полів
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
        // Конструктор за замовчуванням
        public ATM()
        {
            atmBankName = "";
            ID = "";
            placement = "";
            cashAmount = 0;
        }
        // Конструктор з параметрами для заповнення полів класу значеннями
        public ATM(string atmBankName, string ID, string placement, int cashAmount)
        {
            this.atmBankName = atmBankName;
            this.ID = ID;
            this.placement = placement;
            this.cashAmount = cashAmount;
        }
        // Вкладений клас Bank для роботи з банком
        public class Bank
        {
            private string bankName; // Назва банку
            private string bankAddress; // Адреса банку
            private string clientBankID; // Ідентифікаційний номер клієнта в банку (10 цифр)
            private int clientBankCashAmount; // Кількість грошей на рахунку клієнта в банку
            // Властивості для доступу до полів
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
            // Конструктори без та з параметрами для заповнення полів класу
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
            // Методи виведення заповненої таблиці на консоль та виведення цієї ж інформації у файл
            public void PrintClientInBankInfo()
            {
                Console.Write("\n+=== Info about a client in bank ===+\n"
                    + $"|Bank name: {bankName}\n"
                    + $"|Bank address: {bankAddress}\n"
                    + $"|Client ID: {clientBankID}\n"
                    + $"|Client cash amount: {clientBankCashAmount:C}\n"
                    + "+===================================+\n");
            }
            public void OutputClientInBankInfoToFile()
            {
                string filePath = "BankInfo.txt";

                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.Write($"\n+=== Info about a client in bank ===+\n"
                        + $"|Bank name: {bankName}\n"
                        + $"|Bank address: {bankAddress}\n"
                        + $"|Client ID: {clientBankID}\n"
                        + $"|Client cash amount: {clientBankCashAmount:C}\n"
                        + "+===================================+\n");
                }
            }
            // Метод для ініціалізації клієнта в банку, який заповнює поля класу
            public void InitializeClientInBank()
            {
                Console.Write("\n+---- Initialize client in Bank ----+\n"
                    + "Enter name of the bank: ");
                bankName = Console.ReadLine();

                Console.Write("Enter address of the bank: ");
                bankAddress = Console.ReadLine();

                Console.Write("Enter your ID (10 digits): ");
                clientBankID = Console.ReadLine();

                while (clientBankID.Length < 10 || clientBankID.Length > 10 || !long.TryParse(clientBankID, out _))
                {
                    Console.Write("\nYour ID must be 10 digits long!"
                        + "\nEnter your ID correctly: ");
                    clientBankID = Console.ReadLine();
                }

                clientBankCashAmount = Helper.GetInt("Enter your bank's cash amount: ");

                while (clientBankCashAmount < 0)
                {
                    Console.Write("Your bank's cash amount must be greater than 0.");

                    clientBankCashAmount = Helper.GetInt("Enter your bank's cash amount correctly: ");
                }
                Console.Write("+-------------------------------------+\n");

                PrintClientInBankInfo();

                OutputClientInBankInfoToFile();
            }
            /// <summary>
            /// Метод для депозиту грошей на рахунок клієнта, 
            /// який запитує суму для депозиту та перевіряє чи вона більша за 0.
            /// </summary>
            /// <param name="client">посилання на об'єкт клієнта</param>
            public void BankDeposit(Client client)
            {
                int amount = Helper.GetInt("Enter the amount to deposit (in UAH): ");

                while (amount < 0)
                {
                    Console.Write("Your deposit must be greater than 0.\n");

                    amount = Helper.GetInt("Enter your deposit correctly: ");
                }

                clientBankCashAmount += amount + client.Balance;
                client.Balance += amount;

                Console.Write($"\nYour account deposited by {amount:C}.\n");
            }
            /// <summary>
            /// Метод для зняття готівки, який запитує суму для зняття та 
            /// перевіряє чи достатньо грошей на рахунку клієнта та в банкоматі.
            /// </summary>
            /// <param name="client">посилання на об'єкт клієнта</param>
            /// <returns>успіх/невдачу</returns>
            public bool BankWithdrawal(Client client)
            {
                int amount = Helper.GetInt("Enter the amount of cash withdrawal: ");

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
                client.Balance -= amount;
                Console.Write($"\nYour cash withdrawal of {amount:C} successful.\n");

                return true;
            }
            public void CheckBankBalance()
            {
                Console.Write("\n+----------------- Balance -----------------+"
                    + $"\n|There are {clientBankCashAmount:C} on your account."
                    + "\n+-------------------------------------------+\n");
            }
            /// <summary>
            /// Метод для переведення грошей іншому клієнту, 
            /// який запитує інформацію про отримувача та суму для переведення.
            /// </summary>
            /// <returns>успіх/невдачу</returns>
            public bool BankTransfer()
            {
                Console.Write("\n+---------------- Receiver ----------------+\n"
                    + "|Enter name of the bank: ");
                string newBankName = Console.ReadLine();

                Console.Write("|Enter address of the bank: ");
                string newBankAddress = Console.ReadLine();

                Console.Write("|Enter the receiver's name: ");
                string newClientName = Console.ReadLine();

                Console.Write("|Enter the receiver's surname: ");
                string newClientSurname = Console.ReadLine();

                Console.Write("|Enter ID (10 digits): ");
                string newClientBankID = Console.ReadLine();

                while (newClientBankID.Length < 10 || newClientBankID.Length > 10 || !long.TryParse(newClientBankID, out _))
                {
                    Console.Write("\nID must to be 10 digits long!"
                        + "\nEnter ID correctly: ");

                    newClientBankID = Console.ReadLine();
                }
                Console.Write("+------------------------------------------+\n");

                Bank newClient = new Bank(newBankName, newBankAddress, newClientBankID, 0);

                int amount = Helper.GetInt("Enter cash amount to transfer: ");

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

                Console.Write("\n+-----------------------------+"
                    + $"\n|Receiver: {newBankName}\n"
                    + $"|\t   {newBankAddress}\n"
                    + $"|\t   {newClientName}\n"
                    + $"|\t   {newClientSurname}\n"
                    + $"|\t   {newClientBankID}\n"
                    + "+-----------------------------+"
                    + $"\nThe transfer of {amount:C} successful.\n");

                return true;
            }
            /// <summary>
            /// Метод для оплати комунальних послуг, який виводить суму до сплати та баланс клієнта,
            /// </summary>
            /// <returns>успіх/невдачу</returns>
            public bool BankPayUtility()
            {
                int utilitiesCost = 3500;

                Console.Write("\n+-------- Pay for utilities --------+\n"
                    + $"|The sum of utilities is: {utilitiesCost:C}\n"
                    + $"|and you balance is: {clientBankCashAmount:C}.\n"
                    + "+-----------------------------------+\n");

                int choice = Helper.GetInt("Do you want to pay for utilities (1/0): ");

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
            public void BankOptionsForUser(Bank bank, Client client)
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

                    choice = Helper.GetInt("Your choice: ");

                    switch (choice)
                    {
                        case 1:
                            bank.InitializeClientInBank();
                            break;
                        case 2:
                            bank.BankDeposit(client);
                            break;
                        case 3:
                            bank.BankWithdrawal(client);
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
        /// <summary>
        /// Метод для ініціалізації банкомату, який заповнює поля класу значеннями
        /// </summary>
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

            cashAmount = Helper.GetInt("Enter the cash amount (in UAH): ");

            while (cashAmount < 0)
            {
                Console.Write("Cash amount must be greater than 0.");
                cashAmount = Helper.GetInt("Enter the cash amount correctly (in UAH): ");
            }
            Console.Write("+----------------------------------------------------+\n");

            PrintATMInfo();

            OutPutATMInfoToFile();
        }
        /// <summary>
        /// Метод для блокування картки клієнта після 3 невдалих спроб введення PIN-коду
        /// </summary>
        /// <param name="client">посилання на об'єкт клієнта</param>
        public void EnterPIN(Client client)
        {
            string enteredPIN = "";

            int attempts = 3;

            while (attempts > 0)
            {
                Console.Write("|Enter your PIN code: ");
                enteredPIN = Console.ReadLine();

                if (enteredPIN == client.PINCode)
                {
                    Console.WriteLine("|*PIN code accepted.");
                    return;
                }
                attempts--;
               
                Console.WriteLine($"Error: Incorrect PIN code. Attempts left: {attempts}."
                    + "\nEnter your PIN code: ");
            }

            Console.WriteLine("***Error: Too many failed attempts.");
            BlockCard(client);
        }
        /// <summary>
        /// Метод для аутентифікації клієнта, який перевіряє чи не заблокована картка, 
        /// чи правильний номер картки та викликає метод для введення PIN-коду. 
        /// Якщо картка заблокована або номер картки неправильний, то аутентифікація не проходить.
        /// </summary>
        /// <param name="client">посилання на об'єкт клієнта</param>
        /// <returns>успіх/невдачу</returns>
        public bool Authenticate(Client client)
        {
            if (client.IsBlocked)
            {
                Console.Write("\nYour card is blocked.\n");
                return false;
            }

            Console.Write("\n+------------------- Authentication ------------------+\n");
            long enteredCardNumber = Helper.GetLong("|Enter your card number (16 digits): ");

            if (enteredCardNumber != client.CardNumber)
            {
                Console.WriteLine("|***Error: Incorrect card number.");
                return false;
            }
            Console.Write("|*Card number accepted.\n");

            EnterPIN(client);

            if (client.IsBlocked)
            {
                Console.Write("\n|***Your card is blocked.\n");
                Console.Write("+-----------------------------------------------------+\n");
                return false;
            }

            Console.Write("+-----------------------------------------------------+\n");
            return true;
        }
        public void ShowInitializationMenu(ATM atm, Client client)
        {
            int choice;

            do
            {
                Console.Write("\n+--- Initialization menu ---+"
                    + "\n|1. Initialize ATM"
                    + "\n|2. Initialize client"
                    + "\n|0. Go back"
                    + "\n+---------------------------+");

                choice = Helper.GetInt("\nYour choice: ");

                switch (choice)
                {
                    case 1:
                        atm.InitializeATM();
                        break;
                    case 2:
                        client.InitializeClient();
                        break;
                    case 0:
                        Console.WriteLine("Exiting the initialization. Thank you!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            } while (choice != 0);
        }
        public void ShowATMOptions(Client client)
        {
            if (!Authenticate(client))
            { 
                Console.Write("\nAuthentication failed. Exiting from options...\n");
                return;
            }

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

                request = Helper.GetInt("Your request: ");

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