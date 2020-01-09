using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Management;

namespace adapterconfig.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public ManagementScope Scope { get; set; }
        private ManagementObjectCollection Adapters { get; set; }
        public List<NetworkAdapterVM> AdapterVMs { get; private set; }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
        }

        public void GetConfig()
        {
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(Scope, query);
            Adapters = searcher.Get();
            AdapterVMs = new List<NetworkAdapterVM>(Adapters.Count);
            foreach (var a in Adapters)
                AdapterVMs.Add(new NetworkAdapterVM(a));
        }
    }
}