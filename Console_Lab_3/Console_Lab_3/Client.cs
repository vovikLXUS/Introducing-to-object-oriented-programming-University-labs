using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Lab_3
{
    public class Client
    {
        private string firstName; // Ім'я клієнта
        private string lastName; // Прізвище клієнта
        private string pinCode; // PIN-код клієнта
        private long cardNumber; // Номер банківської картки клієнта
        private int[] validityPeriod; // Термін дії картки клієнта (місяць та рік)
        private int balance; // Баланс клієнта на картці
        // Властивості для доступу до полів класу
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public string PINCode
        {
            get
            {
                return pinCode;
            }
            set
            {
                pinCode = value;
            }
        }
        public long CardNumber
        {
            get
            {
                return cardNumber;
            }
            set
            {
                cardNumber = value;
            }
        }
        public int[] ValidityPeriod
        {
            get
            {
                return validityPeriod;
            }
            set
            {
                validityPeriod = value;
            }
        }
        public int Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }
        public bool IsBlocked { get; set; } = false; // Властивість для блокування картки
        // Конструктор класу без параметрів, який ініціалізує поля значеннями за замовчуванням
        public Client()
        {
            firstName = "";
            lastName = "";
            pinCode = "";
            cardNumber = 0;
            validityPeriod = new int[2];
            balance = 0;
        }
        // Конструктор класу з параметрами для ініціалізації полів значеннями, переданими при створенні об'єкта
        public Client(string firstName, string lastName, string pinCode, long cardNumber, int[] validityPeriod)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.pinCode = pinCode;
            this.cardNumber = cardNumber;
            this.validityPeriod = validityPeriod;
        }
        // Методи для отримання числа від користувача з обробкою помилок введення 
        // для скорочення довжини коду
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
        // Виведення заповненої таблиці на консоль та в текстовий файл
        public void PrintClientInfo()
        {
            Console.Write("\n+======== Client Info =========+\n"
                + $"|First name: {FirstName}\n"
                + $"|Last name: {LastName}\n"
                + $"|Card number: {CardNumber}\n"
                + $"|PIN code: {PINCode}\n"
                + $"|Validity period: {ValidityPeriod[0]}/{ValidityPeriod[1]}\n"
                + "+==============================+\n");
        }
        public void OutputClientInfoToFile()
        {
            string filePath = "ClientInfo.txt";

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.Write("\n+======== Client Info =========+\n"
                    + $"|First name: {FirstName}\n"
                    + $"|Last name: {LastName}\n"
                    + $"|Card number: {CardNumber}\n"
                    + $"|PIN code: {PINCode}\n"
                    + $"|Validity period: {ValidityPeriod[0]}/{ValidityPeriod[1]}\n"
                    + "+==============================+\n");
            }
        }
        // Методи для ініціалізації клієнта, зміни PIN-коду, перевірки балансу, зняття готівки та поповнення рахунку
        public void InitializeClient()
        {
            Console.Write("\n+------------------------- Initialize client -------------------------+\n"
                + "Enter your first name: ");
            firstName = Console.ReadLine();

            Console.Write("Enter your last name: ");
            lastName = Console.ReadLine();

            cardNumber = GetLong("Enter your card number (16 digits, without 'SPACE'): ");

            Console.Write("Enter your PIN code (4 digits): ");
            pinCode = Console.ReadLine();

            if (pinCode.Length != 4 || !int.TryParse(pinCode, out _))
            {
                Console.WriteLine("Error: PIN code must be 4 digits.");
                pinCode = Console.ReadLine();
            }

            validityPeriod = new int[2];
            validityPeriod[0] = GetInt("Enter the validity period month (MM): ");
            validityPeriod[1] = GetInt("Enter the validity year (YYYY): ");
            Console.Write("+-------------------------------------------------------------------+\n");

            PrintClientInfo();

            OutputClientInfoToFile();
        }
        /// <summary>
        /// Метод для зміни PIN-коду клієнта. Клієнт вводить новий PIN-код,
        /// який має бути 4-значним числом та відрізнятися від старого PIN-коду.
        /// </summary>
        public void ChangePIN()
        {
            string oldPin = pinCode;   // зберігаємо старий PIN

            Console.Write("\nEnter new PIN code: ");
            string newPin = Console.ReadLine();

            while (newPin.Length != 4 || !int.TryParse(newPin, out _) || newPin == oldPin)
            {
                if (newPin.Length != 4 || !int.TryParse(newPin, out _))
                    Console.WriteLine("Error: PIN code must be 4 digits.");
                else
                    Console.WriteLine("Error: New PIN code must be different from the old one.");

                newPin = Console.ReadLine();
            }

            pinCode = newPin;   // змінюємо тільки після перевірки

            Console.WriteLine("PIN code changed successfully.");
        }
        public void CheckBalance(ATM atm)
        {
            Console.Write($"There are {balance:C} on your account.\n");
        }
        /// <summary>
        /// Метод для зняття готівки з рахунку клієнта. 
        /// Клієнт вводить суму зняття, яка має бути додатною 
        /// та не перевищувати баланс клієнта та кількість готівки в банкоматі.
        /// </summary>
        /// <param name="atm">посилання на об'єкт банкомата</param>
        public void CashWithdrawal(ATM atm)
        {
            int withdrawal = GetInt("Enter amount to withdraw (an integer): ");

            while (withdrawal <= 0)
            {
                Console.Write($"The withdrawal of {withdrawal:C} is not possible.\n"
                    + $"It has to be greater than 0.");
                withdrawal = GetInt("\nEnter amount to withdraw correctly (an integer): ");
            }

            if (balance == 0)
            {
                Console.Write($"The withdrawal is not possible.\n"
                    + $"At first, fill up your card, because there are: {balance:C}.\n");
                return;
            }

            while (withdrawal >= atm.CashAmount)
            {
                Console.Write("\nThere is not enough cash to do withdrawal."
                    + $"\nIn ATM is {atm.CashAmount:C}. Try again.");
                withdrawal = GetInt($"\nEnter amount to withdraw correctly (<={atm.CashAmount:C}): ");
            }

            while (withdrawal > balance)
            {
                Console.Write($"The withdrawal of {withdrawal:C} is not possible.\n"
                    + $"Your balance: {balance:C}.");
                withdrawal = GetInt("\nEnter amount to withdraw correctly (an integer): ");
            }

            balance -= withdrawal;
            atm.CashAmount -= withdrawal;
        }
        /// <summary>
        /// Метод для поповнення рахунку клієнта.
        /// Клієнт вводить суму поповнення, яка має бути додатною. 
        /// Після успішного поповнення, баланс клієнта збільшується 
        /// на введену суму, а кількість готівки в банкоматі також збільшується на цю суму.
        /// </summary>
        /// <param name="atm">посилання на об'єкт банкомату</param>
        public void AccountTopUp(ATM atm)
        {
            int addedMoney = GetInt("Enter how much do you want to add (an integer): ");

            while (addedMoney <= 0)
            {
                Console.Write($"The top-up of {addedMoney} is not possible, it has to be greater than 0.");
                addedMoney = GetInt("Enter correct value of top-up: ");
            }

            balance += addedMoney;
            atm.CashAmount += addedMoney;

            Console.Write($"Your account topped-up by {addedMoney:C}.\n");
        }
        public void OptionsForUser(ATM atm)
        {
            int request = 0;

            do
            {
                Console.Write("\n+-- Client's options --+\n"
                    + "|1. Check your balance\n"
                    + "|2. Cash withdrawal\n"
                    + "|3. Account top-up\n"
                    + "|4. Change your PIN\n"
                    + "|0. Exit\n"
                    + "+----------------------+\n");

                request = GetInt("Your request: ");

                switch (request)
                {
                    case 1:
                        CheckBalance(atm);
                        break;
                    case 2:
                        CashWithdrawal(atm);
                        break;
                    case 3:
                        AccountTopUp(atm);
                        break;
                    case 4:
                        ChangePIN();
                        break;
                    case 0:
                        Console.WriteLine("Exiting from client's options menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid variant entered. Try again.");
                        break;
                }
            } while (request != 0);
        }
    }
}