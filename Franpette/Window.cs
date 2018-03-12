using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Franpette.Sources.Franpette;
using Franpette.Sources.Serialisation;

namespace Franpette
{
    public partial class Window : Form
    {
        public FranpetteCore                _franpette;
        private Dictionary<EInfo, String>   _actuelSatus;

        private Boolean                     _loggedOut = false;

        public Window(string address, string login, string password)
        {
            InitializeComponent();

            _franpette = new FranpetteCore(progress_label);
            _actuelSatus = new Dictionary<EInfo, string>();

            _franpette.connect(address, login, password);

            refreshInfo();
        }

        private void refresh_button_Click(object sender, EventArgs e)
        {
            refreshInfo();
        }

        private void minecraft_button_Click(object sender, EventArgs e)
        {
            minecraftToogle();
        }

        private void host_button_Click(object sender, EventArgs e)
        {
            if (host_button.Text != null && host_button.Text != "NaN")
                Clipboard.SetText(host_button.Text);
        }

        private void refreshInfo()
        {
            if (refresh_info.IsBusy != true && minecraft_toogle.IsBusy != true)
                refresh_info.RunWorkerAsync();
        }

        private void refresh_info_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if (_actuelSatus.Count != 0)
            {
                if (MOTD_textBox.Text != _actuelSatus[EInfo.FRANPETTEMESSAGEOFTHEDAY])
                    _franpette.editMOTD(MOTD_textBox.Text, worker);
            }

            _franpette.refresh(worker);
        }

        private void refresh_info_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ftp_progressBar.Value = 0;
            _actuelSatus = _franpette.getData();

            MOTD_textBox.Text = _actuelSatus[EInfo.FRANPETTEMESSAGEOFTHEDAY];
            version_label.Text = "version " + _actuelSatus[EInfo.FRANPETTEVERSION];
            state_value.Text = _actuelSatus[EInfo.MINECRAFTSTATE];
            date_value.Text = _actuelSatus[EInfo.MINECRAFTDATE];
            user_value.Text = _actuelSatus[EInfo.MINECRAFTUSER];
            host_button.Text = _actuelSatus[EInfo.MINECRAFTIP];

            if (state_value.Text == "Start") state_value.ForeColor = Color.Green;
            else state_value.ForeColor = Color.Red;
        }

        private void minecraftToogle()
        {
            if (refresh_info.IsBusy != true && minecraft_toogle.IsBusy != true)
                minecraft_toogle.RunWorkerAsync();
        }

        private void minecraft_toogle_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if (_actuelSatus.Count != 0)
            {
                if (MOTD_textBox.Text != _actuelSatus[EInfo.FRANPETTEMESSAGEOFTHEDAY])
                    _franpette.editMOTD(MOTD_textBox.Text, worker);
            }

            _franpette.refresh(worker);

            if (state_value.Text != "Start")
            {
                if (_franpette.minecraftUpdate(worker)) _franpette.minecraftStart(worker);
            }
            else if (host_button.Text == FranpetteUtils.getInternetIp())
            {
                _franpette.minecraftStop(worker);
            }
        }

        private void minecraft_toogle_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage >= 0)
                ftp_progressBar.Value = e.ProgressPercentage;

            total_progress.Text = "Remaining ";
            int state = Convert.ToInt32(e.UserState);
            if (state > 1000000000)
                total_progress.Text += (state / 1000000000.0).ToString("F") + "G";
            else
                total_progress.Text += state / 1000000 + "M";
            total_progress.Text += " - " + e.ProgressPercentage + "%";
        }

        private void minecraft_toogle_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ftp_progressBar.Value = 0;
            total_progress.Text = "";
            refreshInfo();
            this.WindowState = FormWindowState.Minimized;
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.DownloadFile(new Uri("https://turbet.nalo-corp.net/builds/updater.exe"), "updater.exe");

            if (File.Exists("updater.exe"))
            {
                Process.Start("updater.exe");
                this.Close();
            }
        }

        public Boolean isLoggedOut()
        {
            return _loggedOut;
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (refresh_info.IsBusy != true && minecraft_toogle.IsBusy != true)
            {
                _loggedOut = true;
                this.Close();
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshInfo();
        }

        private void clearCredentialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FranpetteUtils.clearCredentials();
        }

        private void showFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(FranpetteUtils.getRoot());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://turbet.nalo-corp.net/Franpette/#about");
        }

        private void reportABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/deshtros/Franpette/issues/new");
        }
    }
}
