using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Connectivity;

namespace IntelligentKioskSample.AddOpg.Static
{
    public class Configrations
    {
        private string machineName;
        public Configrations()
        {
            var hostNames = NetworkInformation.GetHostNames();
            machineName = hostNames.FirstOrDefault(name => name.Type == HostNameType.DomainName)?.DisplayName ?? "???";
        }

        public static string CampaignId = "Campaign01";

        private static Configrations config = new Configrations();

        public static string CameraId
        {
            get
            {
                return config.machineName;
            }
            set { }
        }
    }
}
