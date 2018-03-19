using System;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Franpette.Sources.Network;
using Franpette.Sources.Franpette;
using System.ComponentModel;
using System.Resources;
using System.Globalization;

namespace Franpette.Sources
{
    class NetworkFTP : IFranpetteNetwork
    {
        private Stopwatch       _sw;
        private Label           _progress;
        private Font            _font;
        private PointF          _textPos;
        
        private String          _password;
        private String          _login;
        private String          _address;

        private ResourceManager _resMan;
        private CultureInfo     _cul;

        public NetworkFTP(Label progress_label)
        {
            _sw = new Stopwatch();
            _progress = progress_label;
            _font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular);
            _textPos = new PointF(0, 0);

            _resMan = new ResourceManager("Franpette.Resources.Lang", typeof(Program).Assembly);
            _cul = CultureInfo.CreateSpecificCulture(Utils.getProperty("lang", "en-US"));
        }

        public Boolean connect(string address)
        {
            _address = address;
            return true;
        }

        public Boolean login(string login, string password)
        {
            _login = login;
            _password = password;
            return true;
        }

        // Actions depuis le serveur
        public virtual Boolean downloadFile(ETarget target, BackgroundWorker worker)
        {
            switch (target)
            {
                case ETarget.FRANPETTE:
                    ftpTransfer("Franpette/FranpetteStatus.xml", Utils.getRoot("FranpetteStatus.xml"), WebRequestMethods.Ftp.DownloadFile);
                    printLabel(_resMan.GetString("franpette_ready", _cul), _progress);
                    break;
                case ETarget.MINECRAFT:
                    printLabel(_resMan.GetString("franpette_checkCsv", _cul), _progress);
                    Utils.scanFiles(Utils.getProperty("directory", Utils.getRoot()) + "Minecraft");

                    ftpTransfer("Franpette/Minecraft.csv", Utils.getRoot("Minecraft_server.csv"), WebRequestMethods.Ftp.DownloadFile);
                    filesToDownload(Utils.getRoot("Minecraft_server.csv"), Utils.getRoot("Minecraft.csv"), worker);

                    printLabel(_resMan.GetString("franpette_checkCsv", _cul), _progress);
                    Utils.scanFiles(Utils.getProperty("directory", Utils.getRoot()) + "Minecraft");

                    ftpTransfer(Utils.getRoot("Minecraft.csv"), "Franpette/Minecraft.csv", WebRequestMethods.Ftp.UploadFile);
                    break;
            }
            return true;
        }

        // Actions vers le serveur
        public virtual Boolean uploadFile(ETarget target, BackgroundWorker worker)
        {
            switch (target)
            {
                case ETarget.FRANPETTE:
                    ftpTransfer(Utils.getRoot("FranpetteStatus.xml"), "Franpette/FranpetteStatus.xml", WebRequestMethods.Ftp.UploadFile);
                    break;
                case ETarget.MINECRAFT:
                    printLabel(_resMan.GetString("franpette_checkCsv", _cul), _progress);
                    Utils.scanFiles(Utils.getProperty("directory", Utils.getRoot()) + "Minecraft");

                    ftpTransfer("Franpette/Minecraft.csv", Utils.getRoot("Minecraft_server.csv"), WebRequestMethods.Ftp.DownloadFile);
                    filesToUpload(Utils.getRoot("Minecraft.csv"), Utils.getRoot("Minecraft_server.csv"), worker);
                    ftpTransfer(Utils.getRoot("Minecraft.csv"), "Franpette/Minecraft.csv", WebRequestMethods.Ftp.UploadFile);
                    break;
            }
            return true;
        }

        // Récupération de la taille du fichier téléchargé pour la progressBar
        private int requestSize(string path, FtpWebRequest request)
        {
            WebRequest sizeRequest = WebRequest.Create("ftp://" + _address + "/" + path);
            sizeRequest.Credentials = request.Credentials;
            sizeRequest.Method = WebRequestMethods.Ftp.GetFileSize;
            return (int)sizeRequest.GetResponse().ContentLength;
        }

        // Afficher au dessus de la barre de progression un message
        public void printLabel(string message, Label targetLabel)
        {
            targetLabel.CreateGraphics().Clear(Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130))))));
            targetLabel.CreateGraphics().DrawString(message, _font, Brushes.White, _textPos);
        }

        // Download & Upload process
        private void ftpTransfer(string src, string dest, string webRequestMethod)
        {
            Stream  srcStream = null;
            Stream  destStream = null;
            int     fileSize = 0;
            
            _sw.Reset();
            try
            {
                string targetName = (webRequestMethod == WebRequestMethods.Ftp.DownloadFile) ? src : dest;
                string filename = (webRequestMethod == WebRequestMethods.Ftp.DownloadFile) ? dest : src;

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + _address + "/" + targetName);
                request.Credentials = new NetworkCredential(_login, _password);
                request.Method = webRequestMethod;

                if (webRequestMethod == WebRequestMethods.Ftp.DownloadFile)
                {
                    srcStream = request.GetResponse().GetResponseStream();
                    destStream = File.Create(filename);
                    fileSize = requestSize(src, request);
                }
                else
                {
                    srcStream = File.OpenRead(filename);
                    destStream = request.GetRequestStream();
                    fileSize = (int)srcStream.Length;
                }

                using (srcStream)
                using (destStream)
                {
                    byte[] buffer = new byte[10240];
                    int read;
                    _sw.Start();
                    while ((read = srcStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        destStream.Write(buffer, 0, read);

                        long filePos = (webRequestMethod == WebRequestMethods.Ftp.DownloadFile) ? destStream.Position : srcStream.Position;

                        string perSeconds = "";
                        if (fileSize > 100000)
                        {
                            float speed = filePos / (float)_sw.Elapsed.TotalSeconds;
                            perSeconds = " - " + (speed / 1000).ToString("F") + " Kb/s";
                            if (speed > 1000000) perSeconds = " - " + (speed / 1000000).ToString("F") + " Mb/s";
                        }

                        float percent = ((float)filePos / fileSize) * 100f;
                        string percentage = ((int)percent).ToString() + "%";

                        printLabel(Path.GetFileName(filename) + perSeconds + " - " + percentage, _progress);
                    }
                    _sw.Stop();
                }
            }
            catch (WebException e)
            {
                Utils.debug("[Error] " + e.Message);
            }
        }

        // Téléchargement des fichiers
        public void filesToDownload(string server, string local, BackgroundWorker worker)
        {
            string[] localFiles = File.ReadAllLines(local);
            string[] serverFiles = File.ReadAllLines(server);

            int total = 0;
            foreach (string line in serverFiles)
            {
                if (line.Split(';').Length == 3)
                {
                    total += Convert.ToInt32(part(line, 2));
                }
            }

            int done = 0;
            Boolean found;
            int i = 0;
            int start = 0;

            foreach (string serv in serverFiles)
            {
                string file = part(serv, 0);

                // If server.jar is found -> create start.bat
                if (file.Contains(".jar"))
                {
                    File.WriteAllLines(Utils.getRoot("start.bat"), new string[] {
                        "cd " + Utils.getProperty("directory", Utils.getRoot()) + Path.GetDirectoryName(file),
                        "cls",
                        "java -Xms1024M -Xmx2048M -jar " + Path.GetFileName(file) + " nogui"
                    });
                }

                found = false;
                for (i = start; i < localFiles.Length; i++)
                {
                    if (serv == localFiles[i])
                    {
                        start++;
                        found = true;
                        break;
                    }
                    else if (file == part(localFiles[i], 0))
                    {
                        start++;
                        found = true;
                        
                        if (part(serv, 1) != part(localFiles[i], 1))
                        {
                            Directory.CreateDirectory(Utils.getProperty("directory", Utils.getRoot()) + file.Substring(0, file.LastIndexOf('\\')));
                            ftpTransfer("Franpette/" + file.Replace('\\', '/'), Utils.getProperty("directory", Utils.getRoot()) + file, WebRequestMethods.Ftp.DownloadFile);
                        }

                        break;
                    }
                }

                if (!found)
                {
                    Directory.CreateDirectory(Utils.getProperty("directory", Utils.getRoot()) + file.Substring(0, file.LastIndexOf('\\')));
                    ftpTransfer("Franpette/" + file.Replace('\\', '/'), Utils.getProperty("directory", Utils.getRoot()) + file, WebRequestMethods.Ftp.DownloadFile);
                }

                worker.ReportProgress((int)(done * 100.0 / (float)total));

                if (serv.Split(';').Length == 3)
                {
                    done += Convert.ToInt32(part(serv, 2));
                }
            }
        }

        // Upload des fichiers
        public void filesToUpload(string local, string server, BackgroundWorker worker)
        {
            string[] localFiles = File.ReadAllLines(server);
            string[] serverFiles = File.ReadAllLines(local);

            int total = 0;
            foreach (string line in serverFiles)
            {
                if (line.Split(';').Length == 3)
                {
                    total += Convert.ToInt32(part(line, 2));
                }
            }

            int done = 0;
            Boolean found;
            int i = 0;
            int start = 0;

            foreach (string serv in serverFiles)
            {
                string file = part(serv, 0);

                found = false;
                for (i = start;  i < localFiles.Length; i++)
                {
                    if (serv == localFiles[i])
                    {
                        start++;
                        found = true;
                        break;
                    }
                    else if (file == part(localFiles[i], 0))
                    {
                        start++;
                        found = true;

                        if (part(serv, 1) != part(localFiles[i], 1))
                        {
                            ftpTransfer(Utils.getProperty("directory", Utils.getRoot()) + file, "Franpette/" + file.Replace('\\', '/'), WebRequestMethods.Ftp.UploadFile);
                        }

                        break;
                    }
                }

                if (!found)
                {
                    ftpTransfer(Utils.getProperty("directory", Utils.getRoot()) + file, "Franpette/" + file.Replace('\\', '/'), WebRequestMethods.Ftp.UploadFile);
                }

                worker.ReportProgress((int)(done * 100.0 / (float)total));

                if (serv.Split(';').Length == 3)
                {
                    done += Convert.ToInt32(part(serv, 2));
                }
            }
        }

        private string part(string str, int nb)
        {
            return str.Split(';')[nb];
        }
    }
}
