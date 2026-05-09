using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLab6.models.Exceptions
{
    public class DeviceFailureException : Exception
    {
        public DeviceFailureException(string message) : base(message) { }
    }
}
