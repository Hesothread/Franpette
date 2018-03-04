using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApplication2.Sources.Franpette
{
    static class FranpetteUtils
    {
        static string _appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        // Sauvegarder les credentials dans Appdata
        public static void saveCredentials(string address, string login, string password)
        {
            string[] credentials = new string[3];

            credentials[0] = address;
            credentials[1] = login;
            credentials[2] = password;
            Directory.CreateDirectory(_appdata + "/.franpette");
            File.WriteAllLines(_appdata + "/.franpette/franpette.credentials", credentials);
        }

        // Récupère les identifiants sauvegardés dans Appdata
        public static string[] getCredentials()
        {
            string file = _appdata + "/.franpette/franpette.credentials";

            if (File.Exists(file))
            {
                return File.ReadAllLines(file);
            }
            return null;
        }

        // Crée un fichier.csv d'informations des fichiers d'un dossier
        public static void checkFilesToCsv(string folder)
        {
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
            List<string> files = new List<string>();
            foreach (string file in Directory.GetFiles(folder, "*", SearchOption.AllDirectories))
            {
                FileInfo fi = new FileInfo(file);
                files.Add(file + ";" + fi.Length.ToString() + ";" + fi.LastWriteTime.ToString());
            }
            File.WriteAllLines(folder + ".csv", files.ToArray());
            Console.WriteLine("[NetworkFTP] checkFilesToCsv : " + folder + ".csv created successfuly !");
        }

        // Vérifie si les identifiants sont corrects
        public static int isValidConnection(string address, string login, string password)
        {
            if (address == "" || login == "" || password == "")
                return 3;

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + address + "/");
                request.Credentials = new NetworkCredential(login, password);
                request.Method = WebRequestMethods.Ftp.PrintWorkingDirectory;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;

                if (response.StatusCode == FtpStatusCode.NotLoggedIn)
                    return 1;
                else
                    return 2;
            }
            return 0;
        }

        // Vérifie si le port est ouvert
        public static Boolean isPortOpen(string host, int port, TimeSpan timeout)
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
        public static string getInternetIp()
        {
            WebClient wc = new WebClient();
            string strIP = wc.DownloadString("http://checkip.dyndns.org");
            strIP = (new System.Text.RegularExpressions.Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b")).Match(strIP).Value;
            wc.Dispose();
            return strIP;
        }

    }
}
