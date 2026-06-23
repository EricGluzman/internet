namespace internet
{
    internal partial class Program
    {
        public class Network
        {
            public List<NetworkDevice> Devices { get; private set; }

            public Network(List<NetworkDevice> devices)
            {
                Devices = devices ?? throw new NullReferenceException();
            }

            public void RoutePacket(Packet packet)
            {
                var destination = Devices.FirstOrDefault(d => d.IPAddress == packet.DestinationIP);

                if (destination != null)
                {
                    destination.HandlePackage(packet);
                }
                else
                {
                    Console.WriteLine($"Router Error IP {packet.DestinationIP} cant be reached.");
                }
            }
        }
    }
}
