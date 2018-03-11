﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace WindowsFormsApplication2.Sources.Franpette
{
    static class FranpetteUtils
    {
        static string _build = "v2.8";
        static string _appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        static string _creds = "credentials.txt";

        public static string getBuildVersion()
        {
            return _build;
        }

        public static string getRoot(string path = "")
        {
            return _appdata + "\\.franpette\\" + path;
        }

        // Console.WriteLine() -> debug.log
        public static void debug(string text)
        {
            string path = getRoot("debug.log");

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path)) sw.WriteLine(DateTime.Now.ToString() + " " + text);
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path)) sw.WriteLine(DateTime.Now.ToString() + " " + text);
            }
            Console.WriteLine(text);
        }

        // Sauvegarder les credentials dans Appdata
        public static void saveCredentials(string address, string login, string password)
        {
            string[] credentials = new string[3];

            credentials[0] = "host:"+address;
            credentials[1] = "login:"+login;
            credentials[2] = "passwd:"+password;
            Directory.CreateDirectory(getRoot());
            File.WriteAllLines(getRoot(_creds), credentials);
        }

        // Récupère les identifiants sauvegardés dans Appdata
        public static string[] getCredentials()
        {
            string file = getRoot(_creds);

            if (File.Exists(file))
            {
                return File.ReadAllLines(file);
            }
            return null;
        }

        // Supprime le fichier de sauvegarde des identifiants
        public static void clearCredentials()
        {
            try
            {
                File.Delete(getRoot(_creds));
            }
            catch (DirectoryNotFoundException ex)
            {
                debug(ex.Message);
            }
        }

        // Génère le md5sum d'un fichier
        public static string getMd5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        // Donne les informations des fichiers d'un dossier
        public static string[] checkCsv(Boolean dirNameInPath = false, string directory = "")
        {
            if (directory == "") directory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

            Directory.CreateDirectory(directory);
            int start;
            List<string> files = new List<string>();
            foreach (string file in Directory.GetFiles(directory, "*", SearchOption.AllDirectories))
            {
                FileInfo fi = new FileInfo(file);
                start = directory.Length + 1;
                if (dirNameInPath) start -= Path.GetFileName(directory).Length + 1;
                files.Add(file.Substring(start, file.Length - start) + ";" + getMd5(file) + ";" + fi.Length);
            }
            return files.ToArray();
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
                request.Method = WebRequestMethods.Ftp.ListDirectory;
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
