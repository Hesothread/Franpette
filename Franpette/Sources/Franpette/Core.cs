using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using Franpette.Sources.Network;
using Franpette.Sources.Serialisation;

namespace Franpette.Sources.Franpette
{
    public class Core
    {
        private ISerialisation              _serialisation;
        private IFNetwork                   _network;

        private Dictionary<EInfo, string>   _data;
        private bool                        _minecraftUpdated = false;

        public Core(Label progress)
        {
            _data = new Dictionary<EInfo, string>();
            _serialisation = new XMLInfoSerialisation();
            _network = new FNetwork(progress);
        }

        internal  Dictionary<EInfo, string> getData()
        {
            return _data;
        }

        public bool isMinecraftUpToDate()
        {
            return _minecraftUpdated;
        }

        public void connect(string address, string login, string password)
        {
            _network.connect(address);
            _network.login(login, password);
        }

        public bool minecraftUpdate(BackgroundWorker worker)
        {
            if (!_network.receive(ETarget.MINECRAFT, worker))
            {
                Utils.debug("[FRANPETTE] minecraftUpdate : can't download files");
                return (_minecraftUpdated = false);
            }

            Utils.debug("[FRANPETTE] minecraftUpdate : update finished.");
            return (_minecraftUpdated = true);
        }

        public void minecraftStart(BackgroundWorker worker)
        {
            _data[EInfo.MINECRAFTDATE] = DateTime.Now.ToString();
            _data[EInfo.MINECRAFTIP] = Utils.getInternetIp();
            _data[EInfo.MINECRAFTUSER] = Environment.UserName;
            _data[EInfo.MINECRAFTSTATE] = "Start";
            _data[EInfo.FRANPETTEVERSION] = (Convert.ToInt32(_data[EInfo.FRANPETTEVERSION]) + 1).ToString();
            _data[EInfo.MINECRAFTVERSION] = (Convert.ToInt32(_data[EInfo.MINECRAFTVERSION]) + 1).ToString();
            _serialisation.setInfoValue(_data);
            _serialisation.Serialise();

            _network.send(ETarget.FRANPETTE, worker);

            Utils.debug("[FRANPETTE] minecraftStart : starting server...");

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = Utils.getRoot("start.bat");
            process.StartInfo = startInfo;
            process.Start();
            
            Utils.debug("[FRANPETTE] minecraftStart : server started !");
        }

        public void minecraftStop(BackgroundWorker worker)
        {
            _data[EInfo.MINECRAFTDATE] = DateTime.Now.ToString();
            _data[EInfo.MINECRAFTIP] = "NaN";
            _data[EInfo.MINECRAFTUSER] = Environment.UserName;
            _data[EInfo.MINECRAFTSTATE] = "Stop";
            _data[EInfo.FRANPETTEVERSION] = (Convert.ToInt32(_data[EInfo.FRANPETTEVERSION]) + 1).ToString();
            _data[EInfo.MINECRAFTVERSION] = (Convert.ToInt32(_data[EInfo.MINECRAFTVERSION]) + 1).ToString();
            _serialisation.setInfoValue(_data);
            _serialisation.Serialise();

            _network.send(ETarget.MINECRAFT, worker);
            _network.send(ETarget.FRANPETTE, worker);

            Utils.debug("[FRANPETTE] minecraftStop : server stoped !");
        }

        public void editMOTD(string message, BackgroundWorker worker)
        {
            _data[EInfo.FRANPETTEMESSAGEOFTHEDAY] = message;
            _data[EInfo.FRANPETTEVERSION] = (Convert.ToInt32(_data[EInfo.FRANPETTEVERSION]) + 1).ToString();
            _serialisation.setInfoValue(_data);
            _serialisation.Serialise();

            _network.send(ETarget.FRANPETTE, worker);
        }

        public void refresh(BackgroundWorker worker)
        {
            _network.receive(ETarget.FRANPETTE, worker);

            _serialisation.Deserialise(Utils.getRoot("FranpetteStatus.xml"));
            _data = _serialisation.getInfoValue();
        }
        
    }
}
