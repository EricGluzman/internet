namespace internet
{
    internal partial class Program
    {
        public class Service
        {
            public string Name { get; private set; }
            public string Version { get; private set; }
            public bool IsVulnerable { get; private set; }
            public string ExploitPayLoad { get; private set; }

            public void SetName(string name)
            {
                if (name == null) throw new NullReferenceException();
                Name = name;
            }
            public void ChangeVersion(string version)
            {
                if (version == null) throw new NullReferenceException(); 
                Version = version;
            }
            public void ChangeVulnerability(bool vulnrable)
            {
                IsVulnerable = vulnrable;
            }

            public Service(string name, string version, bool isVunarble, string exploitPayLoad)
            {
                Name = name;
                Version = version;
                IsVulnerable = isVunarble;
                ExploitPayLoad = exploitPayLoad;
            }
        }
    }
}
