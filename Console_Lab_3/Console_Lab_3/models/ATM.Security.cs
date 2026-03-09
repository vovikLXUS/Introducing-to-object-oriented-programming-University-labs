using Console_Lab_3.models;
using System;
using System.Text;

namespace Console_Lab_3
{
    public partial class ATM
    {
        /// <summary>
        /// Блокує карту клієнта, встановлюючи властивість IsBlocked в true. 
        /// Це може бути використано у випадках, коли клієнт забув свій 
        /// PIN-код або підозрює несанкціонований доступ до своєї картки.
        /// </summary>
        /// <param name="client">посилання на об'єкт клієнта</param>
        public void BlockCard(Client client)
        {
            client.IsBlocked = true;
            Console.Write("\nYour card has been blocked.");
        }
    }
}