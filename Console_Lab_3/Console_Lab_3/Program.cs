using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console_Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            ATM atm = new ATM();
            Client client = new Client();
            ATM.Bank bank = new ATM.Bank();
            
            int choice;

            do
            {
                Console.WriteLine("\n+------ Main menu ------+"
                    + "\n|1. Initialize ATM/client"
                    + "\n|2. Show client options"
                    + "\n|3. Show ATM options"
                    + "\n|4. Show Bank options"
                    + "\n|0. Exit"
                    + "\n+-----------------------+");

                choice = client.GetInt("Your choice: ");

                switch (choice)
                {
                    case 1:
                        atm.ShowInitializationMenu(atm, client);
                        break;
                    case 2:
                        client.OptionsForUser(atm);
                        break;
                    case 3:
                        atm.ShowATMOptions(client);
                        break;
                    case 4:
                        atm.BankOptionsForUser(bank, client);
                        break;
                    case 0:
                        Console.WriteLine("Exiting the program. Goodbye!\n");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            } while (choice != 0);
        }
    }
}