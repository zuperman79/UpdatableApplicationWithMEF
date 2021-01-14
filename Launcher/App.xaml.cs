using AppContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace Launcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        CompositionContainer baseContainer;
        AggregateCatalog catalog = new AggregateCatalog();

        public App()
        {
            this.Startup += App_Startup;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            DirectoryCatalog baseCatalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory, "app*.dll");
            AssemblyCatalog updaterCatalog = new AssemblyCatalog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Updater.dll"));

            catalog.Catalogs.Add(baseCatalog);
            catalog.Catalogs.Add(updaterCatalog);

            baseContainer = new CompositionContainer(catalog);
            
            var login = baseContainer.GetExport<IView>("LoginWindow");
            login.Value.StartApp = StartMainWindow;
        }

        private void StartMainWindow()
        {
            AssemblyCatalog appCatalog = new AssemblyCatalog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Client.dll"));
            catalog.Catalogs.Add(appCatalog);

            var mainWindowView = baseContainer.GetExport<IView>("MainWindow");

            Window mainWindow = mainWindowView.Value as Window;
            mainWindow.Show();
        }
    }
}