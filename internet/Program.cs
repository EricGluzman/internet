using System.Globalization;

namespace internet
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            Service apache = new Service("Apache Web Server", "2.4.41", isVunarble: true, exploitPayLoad: "EXPLOIT_HTTP_RCE");
            Service SSH = new Service("Secure Shell", "1.81", true, "Got_The_SSH");
            Port SshPort = new Port(22, "TCP", true, SSH);
            Port httpPort = new Port(80, "TCP", isOpen: true, runningService: apache);
            Port httpsPort = new Port(443, "TCP", isOpen: true, runningService: apache);
            Server victim = new Server("192.168.1.10", "00:0A:95:9D:68:16", "Victim_DB", OS.Linux, new List<Port> { httpPort, httpsPort, SshPort});
            AttackerMachine hacker = new AttackerMachine("192.168.1.50", "00:0A:95:9D:68:99", "Kali_Box", OS.Linux, new List<Port>());
            Network localNetwork = new Network(new List<NetworkDevice> { victim, hacker });
            hacker.ScanTarget(victim);
            hacker.LaunchExploit("192.168.1.10", 80, "Smth", localNetwork);
            hacker.LaunchExploit("192.168.1.10", 80, "EXPLOIT_HTTP_RCE", localNetwork);
            Console.ReadLine();
        }
        
    }
}
