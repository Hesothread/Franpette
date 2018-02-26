using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Diagnostics;
using System.Windows.Forms;
using WindowsFormsApplication2.Sources.Network;
using WindowsFormsApplication2.Sources.Serialisation;

namespace WindowsFormsApplication2.Sources.Franpette
{
    public class FranpetteCore
    {
        //private List<IApplication>  _application;
        private ISerialisation      _serialisation;
        private IFranpetteNetwork   _network;

        private Dictionary<EInfo, String>   _data;

        private Boolean _isMinecraftUpToDate = false;

        public FranpetteCore(ProgressBar progressBar)
        {
            _data = new Dictionary<EInfo, String>();
            _serialisation = new XMLInfoSerialisation();
            _network = new NetworkFTP(progressBar);
        }

        internal  Dictionary<EInfo, String> getInfoValue()
        {
            return _data;
        }

        public Boolean getIsMinecraftUpToDate()
        {
            return _isMinecraftUpToDate;
        }

        public void minecraftUpdate()
        {
            if (_data[EInfo.MINECRAFTSTATE] != "Start")
            {
                if (!_network.downloadFile(ETarget.MINECRAFT))
                {
                    Console.WriteLine("[FRANPETTE] Minecraft Update : can't download files");
                    _isMinecraftUpToDate = false;
                    return;
                }
            }
            else
            {
                Console.WriteLine("[FRANPETTE] Minecraft Update : Minecraft state is already Start");
                _isMinecraftUpToDate = false;
                return;
            }
            _isMinecraftUpToDate = true;

            Console.WriteLine("[FRANPETTE] Minecraft Update : update finished.");
        }

        public void minecraftStart()
        {
            // New Minecraft status values
            _data[EInfo.MINECRAFTDATE] = DateTime.Now.ToString();
            _data[EInfo.MINECRAFTIP] = getInternetIp();
            _data[EInfo.MINECRAFTUSER] = Environment.UserName;
            _data[EInfo.MINECRAFTSTATE] = "Start";
            _data[EInfo.FRANPETTEVERSION] = (Convert.ToInt32(_data[EInfo.FRANPETTEVERSION]) + 1).ToString();
            _data[EInfo.MINECRAFTVERSION] = (Convert.ToInt32(_data[EInfo.MINECRAFTVERSION]) + 1).ToString();
            // Serialisation
            _serialisation.setInfoValue(_data);
            _serialisation.Serialise();
            // Upload new status
            _network.uploadFile(ETarget.FRANPETTE);

            Console.WriteLine("[FRANPETTE] minecraftStart : starting server...");
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "servMinecraft.bat";
            process.StartInfo = startInfo;
            process.Start();
            Console.WriteLine("[FRANPETTE] minecraftStart : server started !");
        }

        public void minecraftStop()
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
            _network.uploadFile(ETarget.MINECRAFT);
            _network.uploadFile(ETarget.FRANPETTE);

            Console.WriteLine("[FRANPETTE] minecraftStop : server stoped !");
        }

        public void editMOTD(string message)
        {
            // New Message of the day
            _data[EInfo.FRANPETTEMESSAGEOFTHEDAY] = message;
            _data[EInfo.FRANPETTEVERSION] = (Convert.ToInt32(_data[EInfo.FRANPETTEVERSION]) + 1).ToString();
            // Serialisation
            _serialisation.setInfoValue(_data);
            _serialisation.Serialise();
            // Upload new status
            _network.uploadFile(ETarget.FRANPETTE);
        }

        public void infoUpdate()
        {
            _network.downloadFile(ETarget.FRANPETTE);
            _serialisation.Deserialise("FranpetteStatus.xml");
            _data = _serialisation.getInfoValue();
        }

        public static string getInternetIp()
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            string strIP = wc.DownloadString("http://checkip.dyndns.org");
            strIP = (new System.Text.RegularExpressions.Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b")).Match(strIP).Value;
            wc.Dispose();
            return strIP;
        }
    }
}
