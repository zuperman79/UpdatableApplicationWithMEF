using AppContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updater
{
    [Export(typeof(IUpdater))]
    public class Updater : IUpdater
    {
        private IConnector connector;

        [ImportingConstructor]
        public Updater(IConnector connector)
        {
            this.connector = connector;
        }

        public bool DownloadUpdates()
        {
            connector.Connect("updater");
            Debug.WriteLine("Downloading updates");
            return true;
        }
    }
}
