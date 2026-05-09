using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLab6.models.Parts
{
    public class Body
    {
        public string Material { get; set; }
        public bool IsArmored { get; set; }

        public Body(string material, bool isArmored)
        {
            Material = material;
            IsArmored = isArmored;
        }

        public void ProtectPassengers()
        {
            Console.WriteLine("Кузов захищає пасажирів.");
        }
    }
}
