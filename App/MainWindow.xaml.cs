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

namespace App
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    [Export("MainWindow", typeof(IView))]
    public partial class MainWindow : Window, IView
    {
        [ImportingConstructor]
        public MainWindow(IConnector connector)
        {
            InitializeComponent();
            connector.Connect("client");
        }

        public Action StartApp { get; set; }
    }
}
