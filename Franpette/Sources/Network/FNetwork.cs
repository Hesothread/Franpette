using System.IO;
using System.Net;
using System.Windows.Forms;
using Franpette.Sources.Network;
using Franpette.Sources.Franpette;
using System.ComponentModel;
using System;
using System.Net.Sockets;

namespace Franpette.Sources
{
    class FNetwork : IFNetwork
    {
        private ClientFTP       _ftp;
        private Label           _progress;

        public FNetwork(Label progress)
        {
            _ftp = new ClientFTP(progress);
            _progress = progress;
        }

        public bool connect(string address)
        {
            return _ftp.setAddress(address);
        }

        public bool login(string login, string password)
        {
            return _ftp.setLogins(login, password);
        }

        // Actions depuis le serveur
        public virtual bool receive(ETarget target, BackgroundWorker worker)
        {
            switch (target)
            {
                case ETarget.FRANPETTE:
                    _ftp.transfer("Franpette/FranpetteStatus.xml", Utils.getRoot("FranpetteStatus.xml"), WebRequestMethods.Ftp.DownloadFile);
                    Utils.printLabel("franpette_ready", _progress);
                    break;
                case ETarget.MINECRAFT:
                    _ftp.transfer("Franpette/Minecraft.csv", Utils.getRoot("Minecraft_server.csv"), WebRequestMethods.Ftp.DownloadFile);

                    Utils.printLabel("franpette_checkCsv", _progress);
                    _ftp.filesToTransfer(Utils.getRoot("Minecraft_server.csv"), Utils.scanFiles(Utils.getProperty("directory", Utils.getRoot()) + "Minecraft"), WebRequestMethods.Ftp.DownloadFile, worker);

                    Utils.printLabel("franpette_checkCsv", _progress);
                    File.WriteAllLines(Utils.getRoot("Minecraft.csv"), Utils.scanFiles(Utils.getProperty("directory", Utils.getRoot()) + "Minecraft"));
                    _ftp.transfer(Utils.getRoot("Minecraft.csv"), "Franpette/Minecraft.csv", WebRequestMethods.Ftp.UploadFile);
                    break;
            }
            return true;
        }

        // Actions vers le serveur
        public virtual bool send(ETarget target, BackgroundWorker worker)
        {
            switch (target)
            {
                case ETarget.FRANPETTE:
                    _ftp.transfer(Utils.getRoot("FranpetteStatus.xml"), "Franpette/FranpetteStatus.xml", WebRequestMethods.Ftp.UploadFile);
                    break;
                case ETarget.MINECRAFT:
                    _ftp.transfer("Franpette/Minecraft.csv", Utils.getRoot("Minecraft_server.csv"), WebRequestMethods.Ftp.DownloadFile);

                    Utils.printLabel("franpette_checkCsv", _progress);
                    string[] scan = Utils.scanFiles(Utils.getProperty("directory", Utils.getRoot()) + "Minecraft");
                    _ftp.filesToTransfer(Utils.getRoot("Minecraft_server.csv"), scan, WebRequestMethods.Ftp.UploadFile, worker);

                    File.WriteAllLines(Utils.getRoot("Minecraft.csv"), scan);
                    _ftp.transfer(Utils.getRoot("Minecraft.csv"), "Franpette/Minecraft.csv", WebRequestMethods.Ftp.UploadFile);
                    break;
            }
            return true;
        }

        // Vérifie si le port est ouvert
        public bool isPortOpen(string host, int port, TimeSpan timeout)
        {
            try
            {
                using (var client = new TcpClient())
                {
                    var result = client.BeginConnect(host, port, null, null);
                    var success = result.AsyncWaitHandle.WaitOne(timeout);
                    if (!success) return false;
                    client.EndConnect(result);
                }

            }
            catch
            {
                return false;
            }
            return true;
        }

        // Récupère l'IP internet
        public string getInternetIP()
        {
            WebClient wc = new WebClient();
            string strIP = wc.DownloadString("http://checkip.dyndns.org");
            strIP = (new System.Text.RegularExpressions.Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b")).Match(strIP).Value;
            wc.Dispose();
            return strIP;
        }
    }
}
