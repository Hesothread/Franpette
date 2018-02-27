using System;
using System.Collections.Generic;
using System.IO;

namespace WindowsFormsApplication2.Sources.Franpette
{
    static class FranpetteUtils
    {
        static string _appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public static string getAppdata()
        {
            return _appdata;
        }

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

        // Récupère l'IP internet
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
