using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLab6.models.Parts
{
    public class SteeringSystem
    {
        public void Turn(string direction)
        {
            Console.WriteLine($"Поворот {direction}.");
        }
    }
}
