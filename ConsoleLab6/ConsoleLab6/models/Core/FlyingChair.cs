using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLab6.models.Core
{
    public class FlyingChair : TransformerCar
    {
        public FlyingChair(string model) : base(model) { }

        public override void StartTrip(bool isDriverSober)
        {
            Console.WriteLine("Літальне крісло активовано.");
            base.StartTrip(isDriverSober);
        }

        public void PersonalFlight()
        {
            Console.WriteLine("Літальне крісло виконує персональний політ.");
        }
    }
}
