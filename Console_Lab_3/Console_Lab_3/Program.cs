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
            
            atm.InitializeATM();
            client.InitializeClient();

            client.OptionsForUser(atm);
            atm.ShowATMOptions(client);


        }
    }
}