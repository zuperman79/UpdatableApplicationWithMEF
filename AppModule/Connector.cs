using AppContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModule
{
    [Export(typeof(IConnector))]
    public class Connector : IConnector
    {
        public void Connect(string to)
        {
            Debug.WriteLine("connecting from:" + to);
        }
    }
}
