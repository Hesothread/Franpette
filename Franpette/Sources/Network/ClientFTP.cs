using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
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
    }
}
