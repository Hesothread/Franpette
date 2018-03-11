using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Updater
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
            update("https://turbet.nalo-corp.net/builds/franpette.exe", "franpette.exe");
        }

        private void update(string file, string path)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_Changed;
                wc.DownloadFileCompleted += wc_Completed;
                wc.DownloadFileAsync(new Uri(file), path);
            }
        }

        private void wc_Changed(object sender, DownloadProgressChangedEventArgs e)
        {
            update_progressBar.Value = e.ProgressPercentage;
        }

        private void wc_Completed(object sender, AsyncCompletedEventArgs e)
        {
            update_progressBar.Value = 0;

            if (e.Error != null)
            {
                MessageBox.Show("An error ocurred while trying to update !");
            }

            MessageBox.Show("Franpette will restart...");

            if (File.Exists("franpette.exe"))
            {
                Process.Start("franpette.exe");
                this.Close();
            }
        }
    }
}
