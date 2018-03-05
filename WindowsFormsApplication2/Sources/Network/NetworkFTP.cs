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
        private Label       _progress;
        private Font        _font;
        private PointF      _textPos;

        private String      _password;
        private String      _login;
        private String      _address;

        public NetworkFTP(Label progress_label)
        {
            _sw = new Stopwatch();
            _progress = progress_label;
            _font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular);
            _textPos = new PointF(0, 0);
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
                    //ftpDownload("Franpette/Minecraft/La_der_des_der/minecraft_server.jar", "test.jar", worker);
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

            _sw.Reset();

            try
            {
                using (Stream fileStream = File.OpenRead(src))
                using (Stream ftpStream = request.GetRequestStream())
                {
                    byte[] buffer = new byte[10240];
                    int read;
                    _sw.Start();
                    Console.WriteLine("[NetworkFTP] ftpUpload : ...uploading " + src);
                    while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ftpStream.Write(buffer, 0, read);
                        //worker.ReportProgress((int)(fileStream.Position * 100.0 / fileStream.Length));
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

            int total = requestSize(src, request);
            _sw.Reset();

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
                        //worker.ReportProgress((int)(fileStream.Position * 100.0 / (float)total));
                        printProgressInfo(dest, fileStream.Position, total);
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
        public void printProgressInfo(string filename, long pos, int max)
        {
            string perSeconds = "";
            if (max > 102400)
            {
                float speed = pos / (float)_sw.Elapsed.TotalSeconds;
                perSeconds = " - " + (speed / 1000).ToString("F") + " Kb/s";
                if (speed > 1000000)
                    perSeconds = " - " + (speed / 1000000).ToString("F") + " Mb/s";
            }

            float percent = ((float)pos / max) * 100f;
            string percentage = ((int)percent).ToString() + "%";

            _progress.CreateGraphics().Clear(Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130))))));
            _progress.CreateGraphics().DrawString(filename + perSeconds + " - " + percentage, _font, Brushes.White, _textPos);
        }

        // Téléchargement des fichiers
        public void filesToDownload(string server, string local, BackgroundWorker worker)
        {
            string[] localFiles = File.ReadAllLines(local);
            string[] serverFiles = File.ReadAllLines(server);

            int done = 0;
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
                        if (!FranpetteUtils.sshCommand(_address, _login, _password, "md5sum Franpette/" + file).Contains(FranpetteUtils.getMd5(file)))
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
                worker.ReportProgress((int)(done * 100.0 / (float)serverFiles.Length));
                if (done + 1 <= serverFiles.Length) done++;
            }
        }

        // Upload des fichiers
        public void filesToUpload(string local, string server, BackgroundWorker worker)
        {
            string[] localFiles = File.ReadAllLines(server);
            string[] serverFiles = File.ReadAllLines(local);

            int done = 0;
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
                        if (!FranpetteUtils.sshCommand(_address, _login, _password, "md5sum Franpette/" + file).Contains(FranpetteUtils.getMd5(file)))
                            ftpUpload(file, "Franpette/" + file, worker);
                        break;
                    }
                    i++;
                }
                if (!found) ftpUpload(file, "Franpette/" + file, worker);
                worker.ReportProgress((int)(done * 100.0 / (float)localFiles.Length));
                if (done + 1 <= localFiles.Length) done++;
            }
        }
    }
}
