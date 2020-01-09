using adapterconfig.ViewModel;
using adapterconfig.Views;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace adapterconfig
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Visibility = Visibility.Hidden;
            var login = new Connection();
            login.ShowDialog();
            if (SimpleIoc.Default.GetInstance<ConnectionVM>().Connected)
            {
                this.Visibility = Visibility.Visible;
                ((MainViewModel)this.DataContext).GetConfig();
                return;
            }
            this.Close();
        }
    }
}
