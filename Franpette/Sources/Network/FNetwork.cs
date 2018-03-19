using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Windows.Forms;
using Franpette.Sources.Network;
using Franpette.Sources.Franpette;
using System.ComponentModel;

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
            string[] scan = null;

            switch (target)
            {
                case ETarget.FRANPETTE:
                    _ftp.transfer("Franpette/FranpetteStatus.xml", Utils.getRoot("FranpetteStatus.xml"), WebRequestMethods.Ftp.DownloadFile);
                    Utils.printLabel("franpette_ready", _progress);
                    break;
                case ETarget.MINECRAFT:
                    _ftp.transfer("Franpette/Minecraft.csv", Utils.getRoot("Minecraft_server.csv"), WebRequestMethods.Ftp.DownloadFile);

                    Utils.printLabel("franpette_checkCsv", _progress);
                    filesToTransfer(Utils.getRoot("Minecraft_server.csv"), Utils.scanFiles(Utils.getProperty("directory", Utils.getRoot()) + "Minecraft"), WebRequestMethods.Ftp.DownloadFile, worker);

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
                    filesToTransfer(Utils.getRoot("Minecraft_server.csv"), scan, WebRequestMethods.Ftp.UploadFile, worker);

                    File.WriteAllLines(Utils.getRoot("Minecraft.csv"), scan);
                    _ftp.transfer(Utils.getRoot("Minecraft.csv"), "Franpette/Minecraft.csv", WebRequestMethods.Ftp.UploadFile);
                    break;
            }
            return true;
        }

        // Download & Upload de tous les fichiers analysés
        public void filesToTransfer(string csv, string[] scan, string method, BackgroundWorker worker)
        {
            string[] srcArray = (method == WebRequestMethods.Ftp.DownloadFile) ? File.ReadAllLines(csv) : scan;
            string[] destArray = (method == WebRequestMethods.Ftp.DownloadFile) ? scan : File.ReadAllLines(csv);

            bool found;
            int done = 0;
            int i = 0;
            int start = 0;
            int total = (from src in srcArray
                         where src.Split(';').Length == 3
                         select Convert.ToInt32(part(src, 2))).Sum();

            foreach (string src in srcArray)
            {
                string file = part(src, 0);

                // If server.jar is found -> create start.bat
                if (method == WebRequestMethods.Ftp.DownloadFile && file.Contains(".jar"))
                {
                    File.WriteAllLines(Utils.getRoot("start.bat"), new string[] {
                            "cd " + Utils.getProperty("directory", Utils.getRoot()) + Path.GetDirectoryName(file),
                            "cls",
                            "java -Xms1024M -Xmx2048M -jar " + Path.GetFileName(file) + " nogui"
                        });
                }

                found = false;
                for (i = start; i < destArray.Length; i++)
                {
                    if (src == destArray[i])
                    {
                        start++;
                        found = true;
                        break;
                    }
                    else if (file == part(destArray[i], 0))
                    {
                        start++;
                        found = true;

                        // Si le fichier est différent de la destination, on transfer !
                        if (part(src, 1) != part(destArray[i], 1))
                        {
                            if (method == WebRequestMethods.Ftp.DownloadFile)
                            {
                                Directory.CreateDirectory(Utils.getProperty("directory", Utils.getRoot()) + file.Substring(0, file.LastIndexOf('\\')));
                                _ftp.transfer("Franpette/" + file.Replace('\\', '/'), Utils.getProperty("directory", Utils.getRoot()) + file, method);
                            }
                            else if (method == WebRequestMethods.Ftp.UploadFile)
                            {
                                _ftp.transfer(Utils.getProperty("directory", Utils.getRoot()) + file, "Franpette/" + file.Replace('\\', '/'), method);
                            }
                        }

                        break;
                    }
                }

                // Si le fichier n'est pas trouvé dans la destination, on transfer !
                if (!found)
                {
                    if (method == WebRequestMethods.Ftp.DownloadFile)
                    {
                        Directory.CreateDirectory(Utils.getProperty("directory", Utils.getRoot()) + file.Substring(0, file.LastIndexOf('\\')));
                        _ftp.transfer("Franpette/" + file.Replace('\\', '/'), Utils.getProperty("directory", Utils.getRoot()) + file, method);
                    }
                    else if (method == WebRequestMethods.Ftp.UploadFile)
                    {
                        _ftp.transfer(Utils.getProperty("directory", Utils.getRoot()) + file, "Franpette/" + file.Replace('\\', '/'), method);
                    }
                }

                // On met à jour la progression total
                worker.ReportProgress((int)(done * 100.0 / (float)total));
                if (src.Split(';').Length == 3) done += Convert.ToInt32(part(src, 2));
            }
        }

        private string part(string str, int nb)
        {
            return str.Split(';')[nb];
        }
    }
}
