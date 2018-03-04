using System;

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
        Boolean login(String login, String password);

        Boolean downloadFile(ETarget target);
        Boolean uploadFile(ETarget target);
    }
}
