using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppContracts
{
    public interface IView {
        Action StartApp { get; set; }
    }

    public interface IUpdater
    {
        bool DownloadUpdates();
    }   

    public interface IConnector {
        void Connect(string to);
    }   

}
