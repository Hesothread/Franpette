using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2.Sources.Serialisation
{
    enum EInfo
    {
        FRANPETTEVERSION,
        FRANPETTEMESSAGEOFTHEDAY,

        MINECRAFTVERSION,
        MINECRAFTUSER,
        MINECRAFTIP,
        MINECRAFTDATE,
        MINECRAFTSTATE
    }

    interface ISerialisation
    {
        Boolean Serialise();
        Boolean Deserialise(String fineName);
        Boolean Backup();

        Dictionary<EInfo, String> getInfoValue();
        void setInfoValue(Dictionary<EInfo, String> val);
        String getFileName();
    }
}
