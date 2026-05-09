using ConsoleLab6.models.Core;
using ConsoleLab6.models.Events;
using ConsoleLab6.models.Exceptions;
using ConsoleLab6.models.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLab6.models.Core
{
    public class TransformerCar
    {
        private string _model;
        private List<Person> _people;

        public string Model
        {
            get => _model;
            set => _model = value;
        }

        public Body Body { get; set; }
        public Engine Engine { get; set; }
        public Chassis Chassis { get; set; }
        public SmartSystem SmartSystem { get; set; }
        public TransformSystem TransformSystem { get; set; }

        public event CarEventHandler? OnTransform;
        public event CarEventHandler? OnAlert;
        public event CarEventHandler? OnFailure;

        public TransformerCar(string model)
        {
            Model = model;
            _people = new List<Person>();

            Body = new Body("Titanium", true);
            Engine = new Engine(500);
            Chassis = new Chassis();
            SmartSystem = new SmartSystem();
            TransformSystem = new TransformSystem();
        }

        public void AddPerson(Person person)
        {
            _people.Add(person);
        }

        public void ShowPeople()
        {
            Console.WriteLine("Люди в автомобілі:");
            foreach (var person in _people)
                Console.WriteLine(person);
        }

        public virtual void StartTrip(bool isDriverSober)
        {
            try
            {
                if (!SmartSystem.AnalyzeDriverState(isDriverSober))
                {
                    OnAlert?.Invoke("Водій у неадекватному стані. Запуск заблоковано.");
                    return;
                }

                Engine.Start();
                Chassis.Transmission.ShiftGear(1);
                Chassis.RunningGear.Move();
            }
            catch (DeviceFailureException ex)
            {
                OnFailure?.Invoke(ex.Message);
            }
        }

        public void TrafficJamDetected()
        {
            OnAlert?.Invoke("Виявлено затор. Перехід у режим літака.");
            TransformSystem.TransformToAirplane();
            OnTransform?.Invoke("Трансформація у літак завершена.");
        }

        public void BridgeProblemDetected()
        {
            OnAlert?.Invoke("Міст відсутній або перевантажений.");
            TransformSystem.TransformToSubmarine();
            OnTransform?.Invoke("Трансформація у підводний човен завершена.");
        }

        public void ExecuteVoiceCommand(string command)
        {
            SmartSystem.VoiceCommand(command);
        }

        public void SaveLog(string path)
        {
            File.WriteAllText(path, $"Автомобіль {Model} завершив поїздку.");
        }
    }
}
