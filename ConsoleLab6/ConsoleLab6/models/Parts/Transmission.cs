using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLab6.models.Parts
{
    public class Transmission
    {
        public void ShiftGear(int gear)
        {
            Console.WriteLine($"Передача перемкнена на {gear}.");
        }
    }
}
