using System;
using System.Collections.Generic;
using System.Text;
using ConsoleLab6.models.Exceptions;

namespace ConsoleLab6.models.Parts
{
    public class Engine
    {
        public int HorsePower { get; set; }
        public bool IsWorking { get; private set; } = true;

        public Engine(int horsePower)
        {
            HorsePower = horsePower;
        }

        public void Start()
        {
            if (!IsWorking)
                throw new DeviceFailureException("Двигун не працює.");

            Console.WriteLine("Двигун запущено.");
        }

        public void Fail()
        {
            IsWorking = false;
        }

        public void Repair()
        {
            IsWorking = true;
            Console.WriteLine("Двигун відремонтовано.");
        }
    }
}
