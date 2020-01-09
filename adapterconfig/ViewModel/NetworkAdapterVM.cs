using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using GalaSoft.MvvmLight.Command;

namespace adapterconfig.ViewModel
{
    public class NetworkAdapterVM : ViewModelBase
    {
        private ManagementBaseObject Adapter;

        public NetworkAdapterVM(ManagementBaseObject adapter)
        {
            this.Adapter = adapter;

            Description = (string)adapter[nameof(Description)];
            DNSDomain = (string)adapter[nameof(DNSDomain)];
            DomainDNSRegistrationEnabled = (bool)adapter[nameof(DomainDNSRegistrationEnabled)];
            DNSHostName = (string)adapter[nameof(DNSHostName)];
            DefaultIPGateway = (string)adapter[nameof(DefaultIPGateway)];
            DHCPEnabled = (bool)adapter[nameof(DHCPEnabled)];
            DHCPServer = (string)adapter[nameof(DHCPServer)];
            MACAddress = (string)adapter[nameof(MACAddress)];
            WINSPrimaryServer = (string)adapter[nameof(WINSPrimaryServer)];

            var ip = (string[])adapter[nameof(IPAddress)];
            if (ip != null) IPAddress = new List<string>(ip);
            else IPAddress = new List<string>();

            var subnet = (string[])adapter[nameof(IPAddress)];
            if (subnet != null) IPAddress = new List<string>(subnet);
            else IPAddress = new List<string>();

            var dnsServers = (string[])adapter[nameof(DNSServerSearchOrder)];
            if (subnet != null) DNSServerSearchOrder = new List<string>(dnsServers);
            else DNSServerSearchOrder = new List<string>();

            UpdateConfiguration = new RelayCommand(new Action(() =>
            {
                Adapter.SetPropertyValue(nameof(Description), Description);
                Adapter.SetPropertyValue(nameof(DNSDomain), DNSDomain);
                Adapter.SetPropertyValue(nameof(IPAddress), IPAddress);
            }));
        }

        public RelayCommand UpdateConfiguration { get; private set; }
        public string Description { get; set; }
        public string DNSDomain { get; set; }
        public List<string> IPAddress { get; set; }
        public List<string> IPSubnet { get; set; }
        public string DefaultIPGateway { get; set; }
        public bool DHCPEnabled { get; set; }
        public string DHCPServer { get; set; }
        public string DNSHostName { get; set; }
        public List<string> DNSServerSearchOrder { get; set; }
        public bool DomainDNSRegistrationEnabled { get; set; }
        public string MACAddress { get; private set; }
        public string WINSPrimaryServer { get; set; }
    }
}
