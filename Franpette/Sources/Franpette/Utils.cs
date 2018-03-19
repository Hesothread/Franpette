using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Resources;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Franpette.Sources.Franpette
{
    static class Utils
    {
        static string           _build = "v3.1";
        static string           _appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        static string           _creds = "credentials.txt";
        static string           _properties = "franpette.properties";

        static ResourceManager  _resMan = new ResourceManager("Franpette.Resources.Lang", typeof(Program).Assembly);
        static Font             _font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular);
        static PointF           _textPos = new PointF(0, 0);

        public static string getBuildVersion()
        {
            return _build;
        }

        public static string getRoot(string path = "")
        {
            return _appdata + "\\.franpette\\" + path;
        }

        // Resources langues string
        public static string getString(string str)
        {
            CultureInfo cul = CultureInfo.CreateSpecificCulture(getProperty("lang", "en-US"));

            return _resMan.GetString(str, cul);
        }

        // Afficher un message sur un label
        public static void printLabel(string str, Label target)
        {
            string trans = getString(str);
            string message = (trans != null) ? trans : str;

            target.CreateGraphics().Clear(ColorTranslator.FromHtml("#3c6482"));
            target.CreateGraphics().DrawString(message, _font, Brushes.White, _textPos);
        }

        // Récupère la veleur d'une propriété dans le fichier franpette.properties
        public static string getProperty(string property, string byDefault)
        {
            if (File.Exists(getRoot(_properties)))
            {
                foreach (string line in File.ReadAllLines(getRoot(_properties)))
                {
                    if (line.Split(':').Length >= 2 && line.Split(':')[0] == property)
                    {
                        return line.Substring(line.IndexOf(':') + 1, line.Length - line.Split(':')[0].Length - 1);
                    }
                }
            }

            return byDefault;
        }

        // Retourne l'index de la langue actuelle
        public static int getIndexLang(ListBox list)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                if (list.Items[i].ToString().Contains("(" + getProperty("lang", "en-US") + ")"))
                {
                    return i;
                }
            }

            return 0;
        }

        // Retourne la valeur Auto Login
        public static bool isAutoLogin()
        {
            if (File.Exists(getRoot("franpette.properties")))
            {
                foreach (string line in File.ReadAllLines(getRoot("franpette.properties")))
                {
                    if (line.Split(':')[0] == "autologin")
                    {
                        return line.Split(':')[1].Equals("True") ? true : false;
                    }
                }
            }

            return false;
        }

        // Console.WriteLine() -> debug.log
        public static void debug(string text)
        {
            string path = getRoot("debug.log");

            using (StreamWriter sw = (!File.Exists(path)) ? File.CreateText(path) : File.AppendText(path))
            {
                sw.WriteLine(DateTime.Now.ToString() + " " + text);
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

            return (File.Exists(file)) ? File.ReadAllLines(file) : null;
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
                debug("[Utils] clearCredentials : " + ex.Message);
            }
        }

        // Génère le md5sum d'un fichier
        public static string getMD5(string filename)
        {
            using (FileStream file = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return BitConverter.ToString(MD5.Create().ComputeHash(file)).Replace("-", string.Empty).ToLower();
            }
        }

        // Donne les informations des fichiers d'un dossier
        public static string[] scanFiles(string folder)
        {
            List<string> fList = new List<string>();

            Directory.CreateDirectory(folder);
            foreach (string file in Directory.GetFiles(folder, "*", SearchOption.AllDirectories))
            {
                int start = folder.Length - Path.GetFileName(folder).Length;
                fList.Add(file.Substring(start, file.Length - start) + ";" + getMD5(file) + ";" + (new FileInfo(file)).Length);
            }
            return fList.ToArray();
        }

        // Vérifie si les identifiants sont corrects
        public static int isValidConnection(string address, string login, string password)
        {
            if (address == "" || login == "" || password == "") return 3;

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
    }
}
