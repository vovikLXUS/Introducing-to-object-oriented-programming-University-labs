using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLab6.models.Parts
{
    public class SmartSystem
    {
        public bool AnalyzeDriverState(bool isSober)
        {
            return isSober;
        }

        public void VoiceCommand(string command)
        {
            Console.WriteLine($"Виконую голосову команду: {command}");
        }

        public void Alert(string message)
        {
            Console.WriteLine($"[SMART ALERT]: {message}");
        }
    }
}
