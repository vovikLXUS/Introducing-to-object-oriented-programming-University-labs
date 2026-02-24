using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Lab_3
{
    public class Client
    {
        private string firstName;
        private string lastName;
        private int pinCode;
        private long cardNumber;
        private int[] validityPeriod;
        private int balance;
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
        public int PINCode
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
        public Client()
        {
            firstName = "";
            lastName = "";
            pinCode = 0;
            cardNumber = 0;
            validityPeriod = new int[2];
            balance = 0;
        }
        public Client(string firstName, string lastName, int pinCode, long cardNumber, int[] validityPeriod)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.pinCode = pinCode;
            this.cardNumber = cardNumber;
            this.validityPeriod = validityPeriod;
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
        public void InitializeClient()
        {
            Console.Write("\n=== Initialize client ===\n"
                + "Enter your first name: ");
            firstName = Console.ReadLine();

            Console.Write("Enter your last name: ");
            lastName = Console.ReadLine();

            cardNumber = GetLong("Enter your card number (16 digits, without 'SPACE'): ");
            
            pinCode = GetInt("Enter your PIN code (4 digits): ");
            if (pinCode < 1000 || pinCode > 9999)
            {
                Console.WriteLine("Error: PIN code must be 4 digits.");
                pinCode = GetInt("Enter your PIN code (4 digits): ");
            }

            validityPeriod = new int[2];
            validityPeriod[0] = GetInt("Enter the validity period month (MM): ");
            validityPeriod[1] = GetInt("Enter the validity year (YYYY): ");

            PrintClientInfo();

            OutputClientInfoToFile();
        }
        public void ChangePIN()
        {
            int oldPin = pinCode;   // зберігаємо старий PIN
            int newPin = GetInt("Enter your new PIN code (4 digits): ");

            while (newPin < 1000 || newPin > 9999 || newPin == oldPin)
            {
                if (newPin < 1000 || newPin > 9999)
                    Console.WriteLine("Error: PIN code must be 4 digits.");
                else
                    Console.WriteLine("Error: New PIN code must be different from the old one.");

                newPin = GetInt("Enter your new PIN code (4 digits): ");
            }

            pinCode = newPin;   // змінюємо тільки після перевірки

            Console.WriteLine("PIN code changed successfully.");
        }
        public void CheckBalance(ATM atm)
        {
            Console.Write($"There are {atm.CashAmount:C} on your account.\n");
        }
        public void CashWithdrawal(ATM atm)
        {
            int withdrawal = GetInt("Enter amount to withdraw (an integer): ");
            while (withdrawal <= 0)
            {
                Console.Write($"The withdrawal of {withdrawal:C} is not possible.\n"
                    + $"Your balance: {atm.CashAmount:C}.");
                withdrawal = GetInt("\nEnter amount to withdraw correctly (an integer): ");
            }
            
            while (withdrawal > atm.CashAmount)

            atm.CashAmount -= withdrawal;
        }
        public void AccountTopUp(ATM atm)
        {
            int addedMoney = GetInt("Enter how much do you want to add (an integer): ");
            while (addedMoney <= 0)
            {
                Console.Write($"The top-up of {addedMoney} is not possible, it must be positive and >0.");
                addedMoney = GetInt("Enter correct value of top-up: ");
            }

            atm.CashAmount += addedMoney;

            Console.Write($"Your account topped-up by {addedMoney:C}.");
        }
        public void OptionsForUser(ATM atm)
        {
            int request = 0;

            do
            {
                Console.Write("\n+------- Options ------+\n"
                    + "|1. Change your PIN\n"
                    + "|2. Check your balance\n"
                    + "|3. Cash withdrawal\n"
                    + "|4. Account top-up\n"
                    + "|0. Exit\n"
                    + "-----------------------+\n");

                request = GetInt("Your request: ");

                switch (request)
                {
                    case 1:
                        ChangePIN();
                        break;
                    case 2:
                        CheckBalance(atm);
                        break;
                    case 3:
                        CashWithdrawal(atm);
                        break;
                    case 4:
                        AccountTopUp(atm);
                        break;
                    case 0:
                        Console.WriteLine("Exiting from options menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid variant entered. Try again.");
                        break;
                } 
            } while (request != 0);
        }
    }
}