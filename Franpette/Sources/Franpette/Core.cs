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

        public Core(Label progress)
        {
            _serialisation = new XMLInfoSerialisation();
            _network = new FNetwork(progress);

            _data = new Dictionary<EInfo, string>();
        }

        internal  Dictionary<EInfo, string> getData()
        {
            return _data;
        }

        public void connect(string address, string login, string password)
        {
            _network.connect(address);
            _network.login(login, password);
        }

        public void applicationToogle(string state, string ip, BackgroundWorker worker)
        {
            if (state != "Start" && _network.receive(ETarget.MINECRAFT, worker)) // le serveur peut être lancé
            {
                _data[EInfo.MINECRAFTDATE] = DateTime.Now.ToString();
                _data[EInfo.MINECRAFTIP] = _network.getInternetIP();
                _data[EInfo.MINECRAFTUSER] = Environment.UserName;
                _data[EInfo.MINECRAFTSTATE] = "Start";
                _data[EInfo.FRANPETTEVERSION] = (Convert.ToInt32(_data[EInfo.FRANPETTEVERSION]) + 1).ToString();
                _data[EInfo.MINECRAFTVERSION] = (Convert.ToInt32(_data[EInfo.MINECRAFTVERSION]) + 1).ToString();
                _serialisation.setInfoValue(_data);
                _serialisation.Serialise();

                _network.send(ETarget.FRANPETTE, worker);

                Utils.debug("[Core] applicationToogle : starting server...");

                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = Utils.getRoot("start.bat");
                process.StartInfo = startInfo;
                process.Start();

                Utils.debug("[Core] applicationToogle : server started !");
            }
            else if (ip == _network.getInternetIP()) // l'utilisateur a lancé le serveur, il peut le stoper
            {
                _data[EInfo.MINECRAFTDATE] = DateTime.Now.ToString();
                _data[EInfo.MINECRAFTIP] = "NaN";
                _data[EInfo.MINECRAFTUSER] = Environment.UserName;
                _data[EInfo.MINECRAFTSTATE] = "Stop";
                _data[EInfo.FRANPETTEVERSION] = (Convert.ToInt32(_data[EInfo.FRANPETTEVERSION]) + 1).ToString();
                _data[EInfo.MINECRAFTVERSION] = (Convert.ToInt32(_data[EInfo.MINECRAFTVERSION]) + 1).ToString();
                _serialisation.setInfoValue(_data);
                _serialisation.Serialise();

                Utils.debug("[Core] applicationToogle : stoping server...");

                _network.send(ETarget.MINECRAFT, worker);
                _network.send(ETarget.FRANPETTE, worker);

                Utils.debug("[Core] applicationToogle : server stoped !");
            }
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
