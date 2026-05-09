using ConsoleLab6.models.Core;
using System;
using System.Text;

namespace TransformerCarApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            TransformerCar car = new TransformerCar("Tesla Transformer X");

            car.OnAlert += message => Console.WriteLine($"[ALERT] {message}");
            car.OnTransform += message => Console.WriteLine($"[TRANSFORM] {message}");
            car.OnFailure += message => Console.WriteLine($"[FAILURE] {message}");

            try
            {
                car.AddPerson(new Person("Олег", 22, true));
                car.AddPerson(new Person("Марія", 20));
                car.AddPerson(new Person("Іван", 25));

                car.ShowPeople();

                car.StartTrip(true);
                car.ExecuteVoiceCommand("Увімкнути автопілот");
                car.TrafficJamDetected();
                car.BridgeProblemDetected();

                car.SaveLog("log.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }

            Console.WriteLine("\n--- Похідний клас ---");

            FlyingChair chair = new FlyingChair("SkySeat-1");
            chair.StartTrip(true);
            chair.PersonalFlight();
        }
    }
}
