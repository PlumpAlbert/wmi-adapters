using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;

namespace adapterconfig.CustomUI
{
    /// <summary>
    /// Interaction logic for NetworkAdapter.xaml
    /// </summary>
    public partial class NetworkAdapter : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public NetworkAdapter()
        {
            InitializeComponent();
        }

        //public string AdapterName {
        //    get { return (string)GetValue(AdapterNameProperty); }
        //    set {
        //        SetValue(AdapterNameProperty, value);
        //        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AdapterName)));
        //    }
        //}

        //public static readonly DependencyProperty AdapterNameProperty =
        //    DependencyProperty.Register("AdapterName", typeof(string), typeof(NetworkAdapter), new PropertyMetadata(""));


        //public List<string> IPAddress {
        //    get { return (List<string>)GetValue(IPAddressProperty); }
        //    set {
        //        SetValue(IPAddressProperty, value);
        //        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IPAddress)));
        //    }
        //}

        //public static readonly DependencyProperty IPAddressProperty =
        //    DependencyProperty.Register("IPAddress", typeof(List<string>), typeof(NetworkAdapter), new PropertyMetadata(null));


        //public string DomainName {
        //    get { return (string)GetValue(DomainNameProperty); }
        //    set {
        //        SetValue(DomainNameProperty, value);
        //        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DomainName)));
        //    }
        //}

        //public static readonly DependencyProperty DomainNameProperty =
        //    DependencyProperty.Register("DomainName", typeof(string), typeof(NetworkAdapter), new PropertyMetadata(""));

    }
}
