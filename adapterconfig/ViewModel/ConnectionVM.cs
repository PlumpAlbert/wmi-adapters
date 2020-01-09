using System.Windows;
using System.ComponentModel;
using System.Security;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Management;
using GalaSoft.MvvmLight.Ioc;

namespace adapterconfig.ViewModel
{
    public class ConnectionVM : ViewModelBase, INotifyPropertyChanged
    {
        public string IpAddress { get; set; } = "192.168.150.2";
        public string Username { get; set; } = "Administrator";
        public SecureString Password { get; set; }

        private bool IsConnecting = false;
        public bool Connected { get; private set; } = false;
        public RelayCommand<Window> Connect { get; private set; }

        public ConnectionVM()
        {
            Connect = new RelayCommand<Window>((Window w) =>
            {
                IsConnecting = true;
                ConnectionOptions options = new ConnectionOptions()
                {
                    Username = Username,
                    SecurePassword = Password,
                    Authentication = AuthenticationLevel.Default,
                    Impersonation = ImpersonationLevel.Impersonate,
                    EnablePrivileges = true
                };
                ManagementScope scope = new ManagementScope($"\\\\{IpAddress}\\root\\cimv2", options);
                scope.Connect();
                SimpleIoc.Default.GetInstance<MainViewModel>().Scope = scope;
                IsConnecting = false;
                Connected = true;
                if (w != null)
                    w.Close();
            }, (Window w) => !IsConnecting);
        }
    }
}
