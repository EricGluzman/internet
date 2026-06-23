namespace internet
{
    internal partial class Program
    {
        public class Server : NetworkDevice
        {
            public bool IsCompromised { get; private set; } = false;
            public string Flag { get; private set; } = "CTF{y0u_h4ck3d_th3_53rv3r}";

            public Server(string iPAddress, string macAddress, string hostName, OS os, List<Port> ports) : base(iPAddress, macAddress, hostName, os, ports)
            {
            }

            public override void HandlePackage(Packet packet)
            {
                var targerPort = Ports.FirstOrDefault(p => p.GetPortNumber() == packet.DestinationPort);
                if(targerPort == null || !targerPort.IsOpen)
                {
                    Console.WriteLine($"Packed Droped: Packe {packet.DestinationPort} is closed.");
                    return;
                }
                if(targerPort.RunningService != null && targerPort.RunningService.ExploitPayLoad == packet.Data)
                {
                    IsCompromised = true;
                    Console.WriteLine($"The {HostName} has been compromised trough {targerPort.RunningService.Name}.");
                }
                else
                {
                    Console.WriteLine($"[{HostName}] Received normal request on port {packet.DestinationPort}: {packet.Data}");
                }
            }

        }
        
    }
}
