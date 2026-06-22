namespace internet
{
    internal partial class Program
    {
        public abstract class NetworkDevice
        {
            public string IPAddress { get; private set; }
            private readonly string MacAddress;
            public string HostName { get; private set; }
            public OS os { get; private set; }
            public List<Port> Ports { get; private set; }

            public abstract void HandlePackage(Packet packet);
            public void ChangeIpAdress(string Ip)
            {
                if (Ip != null) IPAddress = Ip;
                else throw new NullReferenceException();
            }
            public void AddPort(Port port)
            {
                if (port == null) throw new NullReferenceException();
                else if (port.GetPortNumber() <= 0) throw new PortNumberException("Port Number Cant Be 0 Or Below Zero");
                Ports.Add(port);
            }
            public void RemovePort(Port port)
            {
                if (!Ports.Contains(port)) throw new NullReferenceException("Cant Find The Port.");
                Ports.Remove(port);
            }
            public string GetMacAdd()
            {
                return MacAddress;
            }

            protected NetworkDevice(string iPAddress, string macAddress, string hostName, OS os, List<Port> ports)
            {
                IPAddress = iPAddress;
                MacAddress = macAddress;
                HostName = hostName;
                this.os = os;
                Ports = ports;
            }
        }
    }
}
