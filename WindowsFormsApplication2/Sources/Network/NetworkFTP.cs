using System;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApplication2.Sources.Network;
using WindowsFormsApplication2.Sources.Franpette;
using System.ComponentModel;

namespace WindowsFormsApplication2.Sources
{
    class NetworkFTP : IFranpetteNetwork
    {
        private Stopwatch   _sw;
        private ProgressBar _progress;
        private Font        _font;
        private PointF      _textPos;

        private String      _password;
        private String      _login;
        private String      _address;

        public NetworkFTP(ProgressBar progress)
        {
            _sw = new Stopwatch();
            _progress = progress;
            _font = new Font("Monospaced", 8, FontStyle.Regular);
            _textPos = new PointF(10, _progress.Height / 2 - 7);
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
                    ftpDownload("Franpette/FranpetteStatus.xml", "FranpetteStatus.xml", worker);
                    break;
                case ETarget.MINECRAFT:
                    FranpetteUtils.checkFilesToCsv("Minecraft");
                    ftpDownload("Franpette/Minecraft.csv", "server.csv", worker);
                    filesToDownload("server.csv", "Minecraft.csv", worker);
                    if (!File.Exists("servMinecraft.bat")) ftpDownload("Franpette/servMinecraft.bat", "servMinecraft.bat", worker);
                    // Eviter de tout réuploader après un download complet !
                    FranpetteUtils.checkFilesToCsv("Minecraft");
                    ftpUpload("Minecraft.csv", "Franpette/Minecraft.csv", worker);
                    break;
                default:
                    Console.Write("[NETWORK FTP] downloadFile : Target is missing.");
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
                    ftpUpload("FranpetteStatus.xml", "Franpette/FranpetteStatus.xml", worker);
                    break;
                case ETarget.MINECRAFT:
                    FranpetteUtils.checkFilesToCsv("Minecraft");
                    ftpDownload("Franpette/Minecraft.csv", "server.csv", worker);
                    filesToUpload("Minecraft.csv", "server.csv", worker);
                    ftpUpload("Minecraft.csv", "Franpette/Minecraft.csv", worker);
                    break;
                default:
                    Console.Write("[NETWORK FTP] uploadFile : Target is missing.");
                    break;
            }
            return true;
        }

        // Connexion à un Path sur le server FTP avec les identifiants
        private FtpWebRequest requestMethod(string path, string method)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + _address + "/" + path);
            request.Credentials = new NetworkCredential(_login, _password);
            request.Method = method;
            return request;
        }

        // Récupération de la taille du fichier téléchargé pour la progressBar
        private int requestSize(string path, FtpWebRequest request)
        {
            WebRequest sizeRequest = WebRequest.Create("ftp://" + _address + "/" + path);
            sizeRequest.Credentials = request.Credentials;
            sizeRequest.Method = WebRequestMethods.Ftp.GetFileSize;
            return (int)sizeRequest.GetResponse().ContentLength;
        }

        // Upload
        private void ftpUpload(string src, string dest, BackgroundWorker worker)
        {
            FtpWebRequest request = requestMethod(dest, WebRequestMethods.Ftp.UploadFile);

            try
            {
                using (Stream fileStream = File.OpenRead(src))
                using (Stream ftpStream = request.GetRequestStream())
                {
                    byte[] buffer = new byte[102400];
                    int read;
                    _sw.Start();
                    Console.WriteLine("[NetworkFTP] ftpUpload : ...uploading " + src);
                    while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ftpStream.Write(buffer, 0, read);
                        worker.ReportProgress((int)(fileStream.Position * 100.0 / fileStream.Length));
                        printProgressInfo(src, fileStream.Position, (int)fileStream.Length);
                    }
                    _sw.Stop();
                    Console.WriteLine("[NetworkFTP] ftpUpload : " + src + " uploaded !");
                }
            }
            catch (WebException e)
            {
                Console.WriteLine("[NetworkFTP] ftpDownload : " + e.Message);
            }
        }

        // Download
        private void ftpDownload(string src, string dest, BackgroundWorker worker)
        {
            FtpWebRequest request = requestMethod(src, WebRequestMethods.Ftp.DownloadFile);

            try
            {
                using (Stream ftpStream = request.GetResponse().GetResponseStream())
                using (Stream fileStream = File.Create(dest))
                {
                    byte[] buffer = new byte[102400];
                    int read;
                    _sw.Start();
                    Console.WriteLine("[NetworkFTP] ftpDownload : ...downloading " + dest);
                    while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, read);
                        worker.ReportProgress((int)(fileStream.Position * 100.0 / (float)requestSize(src, request)));
                        printProgressInfo(dest, fileStream.Position, requestSize(src, request));
                    }
                    _sw.Stop();
                    Console.WriteLine("[NetworkFTP] ftpDownload : " + dest + " downloaded !");
                }
            }
            catch (WebException e)
            {
                Console.WriteLine("[NetworkFTP] ftpDownload : " + e.Message);
            }
        }

        // Afficher les infos d'upload ou de download sur la progressBar
        public void printProgressInfo(string filename, long min, int max)
        {
            float speed = min / (float)_sw.Elapsed.TotalSeconds;
            float percent = ((float)min / max) * 100f;

            string perSeconds = (int)(speed / 1000) + " Kio/s";
            string percentage = ((int)percent).ToString() + "%";

            _progress.CreateGraphics().DrawString(filename + " - " + perSeconds + " - " + percentage, _font, Brushes.Black, _textPos);
        }

        // Téléchargement des fichiers
        public void filesToDownload(string server, string local, BackgroundWorker worker)
        {
            string[] localFiles = File.ReadAllLines(local);
            string[] serverFiles = File.ReadAllLines(server);

            Boolean found;
            int i = 0;
            int start = 0;

            foreach (string serv in serverFiles)
            {
                string file = serv.Split(';')[0].Replace('\\', '/');

                found = false;
                i = start;
                while (i < localFiles.Length)
                {
                    if (serv == localFiles[i])
                    {
                        start++;
                        found = true;
                        break;
                    }
                    else if (serv.Split(';')[0] == localFiles[i].Split(';')[0])
                    {
                        start++;
                        found = true;
                        Directory.CreateDirectory(file.Substring(0, file.LastIndexOf('/')));
                        ftpDownload("Franpette/" + file, file, worker);
                        break;
                    }
                    i++;
                }
                if (!found)
                {
                    Directory.CreateDirectory(file.Substring(0, file.LastIndexOf('/')));
                    ftpDownload("Franpette/" + file, file, worker);
                }
            }
        }

        // Upload des fichiers
        public void filesToUpload(string local, string server, BackgroundWorker worker)
        {
            string[] localFiles = File.ReadAllLines(server);
            string[] serverFiles = File.ReadAllLines(local);

            Boolean found;
            int i = 0;
            int start = 0;

            foreach (string serv in serverFiles)
            {
                string file = serv.Split(';')[0].Replace('\\', '/');

                found = false;
                i = start;
                while (i < localFiles.Length)
                {
                    if (serv == localFiles[i])
                    {
                        start++;
                        found = true;
                        break;
                    }
                    else if (serv.Split(';')[0] == localFiles[i].Split(';')[0])
                    {
                        start++;
                        found = true;
                        ftpUpload(file, "Franpette/" + file, worker);
                        break;
                    }
                    i++;
                }
                if (!found) ftpUpload(file, "Franpette/" + file, worker);
            }
        }
    }
}
