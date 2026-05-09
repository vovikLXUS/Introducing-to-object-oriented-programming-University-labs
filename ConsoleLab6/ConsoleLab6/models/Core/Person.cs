using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLab6.models.Core
{
    public class Person
    {
        private string _name;
        private int _age;
        private bool _isDriver;

        public string Name
        {
            get => _name;
            set => _name = string.IsNullOrWhiteSpace(value) ? "Unknown" : value;
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 0 || value > 120)
                    throw new ArgumentException("Некоректний вік.");
                _age = value;
            }
        }

        public bool IsDriver
        {
            get => _isDriver;
            set => _isDriver = value;
        }

        public Person(string name, int age, bool isDriver = false)
        {
            Name = name;
            Age = age;
            IsDriver = isDriver;
        }

        public override string ToString()
        {
            return $"{Name}, {Age} років" + (IsDriver ? " (Водій)" : "");
        }
    }
}
