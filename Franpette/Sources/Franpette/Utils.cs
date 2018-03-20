using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Franpette.Sources.Franpette
{
    static class Utils
    {
        static string           _build = "v3.1";
        static string           _appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
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

            target.CreateGraphics().Clear(Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130))))));
            target.CreateGraphics().DrawString(message, _font, Brushes.White, _textPos);
        }

        // Récupère la veleur d'une propriété dans le fichier franpette.properties
        public static string getProperty(string property, string byDefault = "")
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

        // Donne les informations des fichiers d'un dossier
        public static string[] scanFiles(string folder)
        {
            List<string> fList = new List<string>();

            Directory.CreateDirectory(folder);
            foreach (string filename in Directory.GetFiles(folder, "*", SearchOption.AllDirectories))
            {
                int start = folder.Length - Path.GetFileName(folder).Length;

                using (FileStream file = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    fList.Add(filename.Substring(start, filename.Length - start) + ";"
                        + BitConverter.ToString(MD5.Create().ComputeHash(file)).Replace("-", string.Empty).ToLower() + ";"
                        + (new FileInfo(filename)).Length);
                }
            }
            return fList.ToArray();
        }
    }
}
