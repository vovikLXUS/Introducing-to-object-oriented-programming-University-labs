using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Lab_3
{
    public class Client
    {
        private string firstName;
        private string lastName;
        private string pinCode;
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
        public Client()
        {
            firstName = "";
            lastName = "";
            pinCode = "";
            cardNumber = 0;
            validityPeriod = new int[2];
            balance = 0;
        }
        public Client(string firstName, string lastName, string pinCode, long cardNumber, int[] validityPeriod)
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
            Console.Write("\n+------------------------- Initialize client -------------------------+\n"
                + "Enter your first name: ");
            firstName = Console.ReadLine();

            Console.Write("Enter your last name: ");
            lastName = Console.ReadLine();

            cardNumber = GetLong("Enter your card number (16 digits, without 'SPACE'): ");

            // TODO: додати перевірку щоб приймало PIN код, який починається з 0, наприклад 0123
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
        public void ChangePIN()
        {
            string oldPin = pinCode;   // зберігаємо старий PIN
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

            while (withdrawal > atm.CashAmount)
            {
                Console.Write("\nThere is not enough cash to do withdrawal."
                    + $"\nIn ATM is {atm.CashAmount:C}. Try again.");
                withdrawal = GetInt($"\nEnter amount to withdraw correctly (<{atm.CashAmount:C}): ");
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