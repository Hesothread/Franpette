using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using WindowsFormsApplication2.Sources.Network;
using WindowsFormsApplication2.Sources.Serialisation;

namespace WindowsFormsApplication2.Sources.Franpette
{
    public class FranpetteCore
    {
        private ISerialisation      _serialisation;
        private IFranpetteNetwork   _network;

        private Dictionary<EInfo, String>   _data;

        private Boolean _isMinecraftUpToDate = false;

        public FranpetteCore(Label progress_label)
        {
            _data = new Dictionary<EInfo, String>();
            _serialisation = new XMLInfoSerialisation();
            _network = new NetworkFTP(progress_label);
        }

        internal  Dictionary<EInfo, String> getInfoValue()
        {
            return _data;
        }

        public Boolean getIsMinecraftUpToDate()
        {
            return _isMinecraftUpToDate;
        }

        public Boolean minecraftUpdate(BackgroundWorker worker)
        {
            if (_data[EInfo.MINECRAFTSTATE] != "Start")
            {
                if (!_network.downloadFile(ETarget.MINECRAFT, worker))
                {
                    Console.WriteLine("[FRANPETTE] Minecraft Update : can't download files");
                    _isMinecraftUpToDate = false;
                    return false;
                }
            }
            else
            {
                Console.WriteLine("[FRANPETTE] Minecraft Update : Minecraft state is already Start");
                _isMinecraftUpToDate = false;
                return false;
            }
            Console.WriteLine("[FRANPETTE] Minecraft Update : update finished.");
            _isMinecraftUpToDate = true;
            return true;
        }

        public void connect(string address, string login, string password)
        {
            _network.connect(address);
            _network.login(login, password);
        }

        public void minecraftStart(BackgroundWorker worker)
        {
            // New Minecraft status values
            _data[EInfo.MINECRAFTDATE] = DateTime.Now.ToString();
            _data[EInfo.MINECRAFTIP] = FranpetteUtils.getInternetIp();
            _data[EInfo.MINECRAFTUSER] = Environment.UserName;
            _data[EInfo.MINECRAFTSTATE] = "Start";
            _data[EInfo.FRANPETTEVERSION] = (Convert.ToInt32(_data[EInfo.FRANPETTEVERSION]) + 1).ToString();
            _data[EInfo.MINECRAFTVERSION] = (Convert.ToInt32(_data[EInfo.MINECRAFTVERSION]) + 1).ToString();
            // Serialisation
            _serialisation.setInfoValue(_data);
            _serialisation.Serialise();
            // Upload new status
            _network.uploadFile(ETarget.FRANPETTE, worker);

            Console.WriteLine("[FRANPETTE] minecraftStart : starting server...");
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "servMinecraft.bat";
            process.StartInfo = startInfo;
            process.Start();
            Console.WriteLine("[FRANPETTE] minecraftStart : server started !");
        }

        public void minecraftStop(BackgroundWorker worker)
        {
            // New Minecraft status values
            _data[EInfo.MINECRAFTDATE] = DateTime.Now.ToString();
            _data[EInfo.MINECRAFTIP] = "NaN";
            _data[EInfo.MINECRAFTUSER] = Environment.UserName;
            _data[EInfo.MINECRAFTSTATE] = "Stop";
            _data[EInfo.FRANPETTEVERSION] = (Convert.ToInt32(_data[EInfo.FRANPETTEVERSION]) + 1).ToString();
            _data[EInfo.MINECRAFTVERSION] = (Convert.ToInt32(_data[EInfo.MINECRAFTVERSION]) + 1).ToString();
            // Serialisation
            _serialisation.setInfoValue(_data);
            _serialisation.Serialise();
            // Upload new status
            _network.uploadFile(ETarget.MINECRAFT, worker);
            _network.uploadFile(ETarget.FRANPETTE, worker);

            Console.WriteLine("[FRANPETTE] minecraftStop : server stoped !");
        }

        public void editMOTD(string message, BackgroundWorker worker)
        {
            // New Message of the day
            _data[EInfo.FRANPETTEMESSAGEOFTHEDAY] = message;
            _data[EInfo.FRANPETTEVERSION] = (Convert.ToInt32(_data[EInfo.FRANPETTEVERSION]) + 1).ToString();
            // Serialisation
            _serialisation.setInfoValue(_data);
            _serialisation.Serialise();
            // Upload new status
            _network.uploadFile(ETarget.FRANPETTE, worker);
        }

        public void infoUpdate(BackgroundWorker worker)
        {
            _network.downloadFile(ETarget.FRANPETTE, worker);
            _serialisation.Deserialise("FranpetteStatus.xml");
            _data = _serialisation.getInfoValue();
        }
        
    }
}
