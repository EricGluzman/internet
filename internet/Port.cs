namespace internet
{
    internal partial class Program
    {
        public class Port
        {
            private readonly int PortNumber;
            private readonly string Protocol;
            public bool IsOpen { get; private set; }
            public Service RunningService { get; private set; }

            public int GetPortNumber()
            {
                return PortNumber;
            }
            public string GetProtName()
            {
                return Protocol;
            }
            public void OpenPort()
            {
                IsOpen = true;
            }
            public void ClosePort()
            {
                IsOpen = false;
            }
            public bool 
            public Port(int portNumber, string protocol, bool isOpen, Service runningService)
            {
                PortNumber = portNumber;
                Protocol = protocol;
                IsOpen = isOpen;
                RunningService = runningService;
            }
        }
    }
}
