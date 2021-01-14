using AppContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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
using System.Windows.Shapes;

namespace LoginScreen
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    [Export("LoginWindow", typeof(IView))]
    public partial class LoginWindow : Window, IView
    {
        [ImportingConstructor]
        public LoginWindow(IUpdater updater, IConnector connector)
        {
            InitializeComponent();
            connector.Connect("login");
            updater.DownloadUpdates();
        }

        private Action startApp;

        public Action StartApp
        {
            get { return startApp; }
            set { startApp = value; this.Show(); }
        }       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartApp();
            this.Close();                       
        }
    }
}
