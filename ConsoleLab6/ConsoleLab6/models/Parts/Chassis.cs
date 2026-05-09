using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLab6.models.Parts
{
    public class Chassis
    {
        public RunningGear RunningGear { get; set; }
        public SteeringSystem Steering { get; set; }
        public Transmission Transmission { get; set; }
        public BrakeSystem Brakes { get; set; }

        public Chassis()
        {
            RunningGear = new RunningGear();
            Steering = new SteeringSystem();
            Transmission = new Transmission();
            Brakes = new BrakeSystem();
        }
    }
}
