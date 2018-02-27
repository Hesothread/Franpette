using System;
using System.Collections.Generic;
using System.IO;

namespace WindowsFormsApplication2.Sources.Franpette
{
    static class FranpetteUtils
    {
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
