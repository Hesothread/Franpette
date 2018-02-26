using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2.Sources.Network
{
    public enum ETarget
    {
        FRANPETTE,
        MINECRAFT 
    }
    
    interface IFranpetteNetwork
    {
        Boolean connect(String address);
        Boolean disconnect();

        Boolean login(String login, String password);
        Boolean logout();

        Boolean downloadFile(ETarget target);
        Boolean uploadFile(ETarget target);

        Boolean isConnected();
    }
}
