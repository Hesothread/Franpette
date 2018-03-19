using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using Franpette.Sources.Franpette;

namespace Franpette.Sources.Network
{
    class ClientFTP
    {
        private Label       _progress;
        private Stopwatch   _sw;

        private string      _address;
        private string      _login;
        private string      _password;

        public ClientFTP(Label progress)
        {
            _progress = progress;
            _sw = new Stopwatch();
        }

        public Boolean setAddress(string address)
        {
            if (address == "")
                return false;
            _address = address;
            return true;
        }

        public Boolean setLogins(string login, string password)
        {
            if (login == "" || password == "")
                return false;
            _login = login;
            _password = password;
            return true;
        }

        // Download & Upload process
        public void transfer(string src, string dest, string method)
        {
            Stream  srcStream = null;
            Stream  destStream = null;
            int     fileSize = 0;
            long    filePos = 0;

            _sw.Reset();
            try
            {
                string ftpName = (method == WebRequestMethods.Ftp.DownloadFile) ? src : dest;
                string locName = (method == WebRequestMethods.Ftp.DownloadFile) ? dest : src;

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + _address + "/" + ftpName);
                request.Credentials = new NetworkCredential(_login, _password);
                request.Method = method;

                if (method == WebRequestMethods.Ftp.DownloadFile)
                {
                    srcStream = request.GetResponse().GetResponseStream();
                    destStream = File.Create(locName);
                    fileSize = requestSize(src, request);
                }
                else
                {
                    srcStream = File.OpenRead(locName);
                    destStream = request.GetRequestStream();
                    fileSize = (int)srcStream.Length;
                }

                using (srcStream)
                using (destStream)
                {
                    byte[] buffer = new byte[102400];
                    int read;
                    _sw.Start();
                    while ((read = srcStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        destStream.Write(buffer, 0, read);

                        filePos = (method == WebRequestMethods.Ftp.DownloadFile) ? destStream.Position : srcStream.Position;

                        Utils.printLabel(Path.GetFileName(locName) + " - " + getSpeedText(filePos, fileSize, _sw.Elapsed.TotalSeconds) + " - " + getPercentText(filePos, fileSize), _progress);
                    }
                    _sw.Stop();
                }
            }
            catch (WebException e)
            {
                Utils.debug(e.Message);
            }
        }

        // Calculate transfer speed
        private string getSpeedText(long pos, int size, double elapsedTime)
        {
            float speed = pos / (float)elapsedTime;

            if (size > 100000)
            {
                return (speed > 1000000) ? (speed / 1000000).ToString("F") + " Mb/s" : (speed / 1000).ToString("F") + " Kb/s";
            }

            return "???";
        }

        // Calculate transfer percentage
        private string getPercentText(long pos, int size)
        {
            float percent = (pos / (float)size) * 100f;

            return ((int)percent).ToString() + "%";
        }

        // Récupération de la taille du fichier téléchargé
        private int requestSize(string path, FtpWebRequest request)
        {
            WebRequest sizeRequest = WebRequest.Create("ftp://" + _address + "/" + path);
            sizeRequest.Credentials = request.Credentials;
            sizeRequest.Method = WebRequestMethods.Ftp.GetFileSize;
            return (int)sizeRequest.GetResponse().ContentLength;
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
                                transfer("Franpette/" + file.Replace('\\', '/'), Utils.getProperty("directory", Utils.getRoot()) + file, method);
                            }
                            else if (method == WebRequestMethods.Ftp.UploadFile)
                            {
                                transfer(Utils.getProperty("directory", Utils.getRoot()) + file, "Franpette/" + file.Replace('\\', '/'), method);
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
                        transfer("Franpette/" + file.Replace('\\', '/'), Utils.getProperty("directory", Utils.getRoot()) + file, method);
                    }
                    else if (method == WebRequestMethods.Ftp.UploadFile)
                    {
                        transfer(Utils.getProperty("directory", Utils.getRoot()) + file, "Franpette/" + file.Replace('\\', '/'), method);
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
