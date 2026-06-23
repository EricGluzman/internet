using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internet
{
    internal class Exeptions
    {
    }
    public class PortNumberException : Exception
    {
        public PortNumberException() : base("Invalid Port Number Provided.") { }
        public PortNumberException(string message) : base(message) { }

    }
    public class DeviceException : Exception
    {
        public DeviceException() : base("Device Was Not Found.") { }
        public DeviceException(string message) : base(message) { }
    }
}
