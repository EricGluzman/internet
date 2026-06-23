namespace internet
{
    internal partial class Program
    {
        public class Packet {
            public string SourceIP { get; private set; }
            public string DestinationIP { get; private set; }
            public int DestinationPort { get; private set; }
            public string Data { get; private set; }

            public void SetSourceIp(string ip)
            {
                if (ip == null) throw new NullReferenceException();
                SourceIP = ip;
            }
            public void SetDestIp(string ip)
            {
                if (ip == null) throw new NullReferenceException();
                DestinationIP = ip;
            }
            public void SetDestPort(int portnum)
            {
                if (portnum == 0) throw new PortNumberException("Cant Access Port At Number 0");
                DestinationPort = portnum;
            }
            public void SetData(string data)
            {
                if (data == null) throw new NullReferenceException();
                Data = data;
            }

            public Packet(string sourceIP, string destinationIP, int destinationPort, string data)
            {
                SourceIP = sourceIP;
                DestinationIP = destinationIP;
                DestinationPort = destinationPort;
                Data = data;
            }
        }

    }
}
