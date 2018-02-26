using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication2.Sources.Network;

namespace WindowsFormsApplication2.Sources
{
    class NetworkFTP : IFranpetteNetwork
    {
        const string FTP_SERVER_HOST = "ftp://xxx.xxx.xxx.xxx/";

        private Stopwatch   _sw;
        private ProgressBar _progress;
        private Font        _font;
        private PointF      _textPos;

        public NetworkFTP(ProgressBar progress)
        {
            _sw = new Stopwatch();
            _progress = progress;
            _font = new Font("Monospaced", 8, FontStyle.Regular);
            _textPos = new PointF(10, _progress.Height / 2 - 7);
        }

        // Actions depuis le serveur
        public virtual Boolean downloadFile(ETarget target)
        {
            switch (target)
            {
                case ETarget.FRANPETTE:
                    ftpDownload("Franpette/FranpetteStatus.xml", "FranpetteStatus.xml");
                    break;
                case ETarget.MINECRAFT:
                    checkFilesToCsv("Minecraft");
                    ftpDownload("Franpette/Minecraft.csv", "server.csv");
                    List<string> list = listOfFiles("server.csv", "Minecraft.csv");
                    list.ForEach(path => ftpDownload("Franpette/" + path, path));
                    break;
                default:
                    Console.Write("[NETWORK FTP] downloadFile : Target is missing.");
                    break;
            }
            return true;
        }

        // Actions vers le serveur
        public virtual Boolean uploadFile(ETarget target)
        {
            switch (target)
            {
                case ETarget.FRANPETTE:
                    ftpUpload("FranpetteStatus.xml", "Franpette/FranpetteStatus.xml");
                    break;
                case ETarget.MINECRAFT:
                    checkFilesToCsv("Minecraft");
                    ftpDownload("Franpette/Minecraft.csv", "server.csv");
                    listOfFiles("Minecraft.csv", "server.csv").ForEach(path => ftpUpload(path, "Franpette/" + path));
                    ftpUpload("Minecraft.csv", "Franpette/Minecraft.csv");
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
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FTP_SERVER_HOST + path);
            request.Credentials = new NetworkCredential("xxx", "ddddd");
            request.Method = method;
            return request;
        }

        // Récupération de la taille du fichier téléchargé pour la progressBar
        private int requestSize(string path, FtpWebRequest request)
        {
            WebRequest sizeRequest = WebRequest.Create(FTP_SERVER_HOST + path);
            sizeRequest.Credentials = request.Credentials;
            sizeRequest.Method = WebRequestMethods.Ftp.GetFileSize;
            return (int)sizeRequest.GetResponse().ContentLength;
        }

        // Upload
        private void ftpUpload(string src, string dest)
        {
            FtpWebRequest request = requestMethod(dest, WebRequestMethods.Ftp.UploadFile);

            using (Stream fileStream = File.OpenRead(src))
            using (Stream ftpStream = request.GetRequestStream())
            {
                _progress.Maximum = (int)fileStream.Length;

                byte[] buffer = new byte[102400];
                int read;
                _sw.Start();
                Console.WriteLine("[NetworkFTP] ftpUpload : ...uploading " + src);
                while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ftpStream.Write(buffer, 0, read);
                    _progress.Value = (int)fileStream.Position;
                    printProgressInfo(src);
                }
                _sw.Stop();
                Console.WriteLine("[NetworkFTP] ftpUpload : " + src + " uploaded !");
                _progress.Value = 0;
            }
        }

        // Download
        private void ftpDownload(string src, string dest)
        {
            FtpWebRequest request = requestMethod(src, WebRequestMethods.Ftp.DownloadFile);
            
            using (Stream ftpStream = request.GetResponse().GetResponseStream())
            using (Stream fileStream = File.Create(dest))
            {
                _progress.Maximum = requestSize(src, request);

                byte[] buffer = new byte[102400];
                int read;
                _sw.Start();
                Console.WriteLine("[NetworkFTP] ftpDownload : ...downloading " + dest);
                while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fileStream.Write(buffer, 0, read);
                    _progress.Value = (int)fileStream.Position;
                    printProgressInfo(src);
                }
                _sw.Stop();
                Console.WriteLine("[NetworkFTP] ftpDownload : " + dest + " downloaded !");
                _progress.Value = 0;
            }
        }

        // Afficher les infos d'upload ou de download sur la progressBar
        public void printProgressInfo(string filename)
        {
            float speed = _progress.Value / (float)_sw.Elapsed.TotalSeconds;
            float percent = ((float)_progress.Value / _progress.Maximum) * 100f;
            float timeLeft = (_progress.Maximum - _progress.Value) / speed;

            string perSeconds = (int)(speed / 1000) + " Kio/s";
            string percentage = "(" + ((int)percent).ToString() + ")% completed";

            /*string remainTime = "";
            timeLeft++;
            if (timeLeft <= 60)
                remainTime = "Remaining time: " + (int)timeLeft + " seconds";
            else if (timeLeft <= 3600)
                remainTime = "Remaining time: " + (int)(timeLeft) / 60 + " m " + (int)(timeLeft) % 60 + " s";
            else
                remainTime = "Remaining time: " + (int)(timeLeft) / 3600 + " h " + ((int)(timeLeft) % 3600) / 60 + " m " + ((int)(timeLeft) % 3600) % 60 + " s";*/

            _progress.CreateGraphics().DrawString(filename + " : " + perSeconds + " - " + percentage, _font, Brushes.Black, _textPos);
        }

        // Create Minecraft.csv with all files info
        public void checkFilesToCsv(string folder)
        {
            string[] lines = new string[Directory.GetFiles(folder, "*", SearchOption.AllDirectories).Length + 1];
            int i = 0;
            lines[i] = "path;length;lastWriteTime";
            foreach (string file in Directory.GetFiles(folder, "*", SearchOption.AllDirectories))
            {
                FileInfo fi = new FileInfo(file);
                lines[++i] = file + ";" + fi.Length.ToString() + ";" + fi.LastWriteTime.ToString();
            }
            File.WriteAllLines(folder + ".csv", lines);
            Console.WriteLine(folder + ".csv created successfuly !");
        }

        // Liste les fichiers differents
        public List<string> listOfFiles(string biggerCsv, string smallerCsv)
        {
            List<string> list = new List<string>();

            string[] Files1 = File.ReadAllLines(smallerCsv);
            string[] Files2 = File.ReadAllLines(biggerCsv);

            int i = 0;
            int decal = 0;
            while (i < Files1.Length)
            {
                if (Files1[i] != Files2[i + decal])
                {
                    if (Files1[i].Split(';')[0] == Files2[i + decal].Split(';')[0])
                    {
                        list.Add(Files2[i + decal].Split(';')[0].Replace('\\', '/'));
                    }
                    else
                    {
                        if (Files1.Length < Files2.Length)
                        {
                            list.Add(Files2[i + decal].Split(';')[0].Replace('\\', '/'));
                            decal++;
                        }
                    }
                }
                i++;
            }
            return list;
        }
    }
}
