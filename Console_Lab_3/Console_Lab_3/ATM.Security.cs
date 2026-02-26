using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Lab_3
{
    public partial class ATM
    {
        public void BlockCard(Client client)
        {
            client.IsBlocked = true;
            Console.Write("\nYour card has been BLOCKED.");
        }
    }
}
