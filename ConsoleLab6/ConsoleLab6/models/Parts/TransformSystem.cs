using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLab6.models.Parts
{
    public class TransformSystem
    {
        public void TransformToAirplane()
        {
            Console.WriteLine("Автомобіль трансформується у літак.");
        }

        public void TransformToSubmarine()
        {
            Console.WriteLine("Автомобіль трансформується у підводний човен.");
        }

        public void TransformToCar()
        {
            Console.WriteLine("Повернення в режим автомобіля.");
        }
    }
}
