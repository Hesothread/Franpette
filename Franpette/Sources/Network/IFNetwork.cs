using System;
using System.ComponentModel;

namespace Franpette.Sources.Network
{
    public enum ETarget
    {
        FRANPETTE,
        MINECRAFT
    }
    
    interface IFNetwork
    {
        bool connect(String address);
        bool login(String login, String password);

        bool receive(ETarget target, BackgroundWorker worker);
        bool send(ETarget target, BackgroundWorker worker);

        bool isPortOpen(string host, int port, TimeSpan timeout);
        string getInternetIP();
    }
}
