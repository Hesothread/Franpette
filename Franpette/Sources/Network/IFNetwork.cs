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
        Boolean connect(String address);
        Boolean login(String login, String password);

        Boolean receive(ETarget target, BackgroundWorker worker);
        Boolean send(ETarget target, BackgroundWorker worker);
    }
}
