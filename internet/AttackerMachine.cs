
namespace internet
{
    internal partial class Program
    {
        public class AttackerMachine : NetworkDevice
        {
            public AttackerMachine(string iPAddress, string macAddress, string hostName, OS os, List<Port> ports) : base(iPAddress, macAddress, hostName, os, ports)
            {
            }

            public override void HandlePackage(Packet packet)
            {
                Console.WriteLine($"Attacker Recive Response from {packet.SourceIP}: {packet.Data}");
            }
            public void ScanTarget(NetworkDevice target)
            {
                Console.WriteLine($"Launching port scan against {target.HostName} ({target.IPAddress})...");

                foreach (var port in target.Ports)
                {
                    if (port.IsOpen)
                    {
                        Console.WriteLine($"-> Port {port.GetPortNumber()} is OPEN | Service: {port.RunningService.Name} (v{port.RunningService.Version})");
                    }
                }
            }
            public void LaunchExploit(string Ip, int port, string payload, Network network)
            {
                NetworkDevice device = null;
                for(int i = 0; i < network.Devices.Count; i++)
                {
                    if(Ip == network.Devices[i].IPAddress)
                    {
                        device = network.Devices[i];
                        break;
                    }
                    
                }
                if (device == null)
                {
                    throw new DeviceException("Device with the specified IP was not found.");
                }
                else if (device != null)
                {
                    Console.WriteLine($"Sending exploit payload to {device.HostName}:{port}...");

                    Packet exploitPacket = new Packet(this.IPAddress, Ip, port, payload);
                    network.RoutePacket(exploitPacket);
                }
            }

        }
        
    }
}
