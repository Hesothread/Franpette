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
using Microsoft.WindowsAPICodePack.Taskbar;

namespace Franpette
{
    public partial class Window : Form
    {
        public Core                         _core;

        private Dictionary<EInfo, String>   _actuelSatus;
        private bool                        _loggedOut = false;

        public Window(string address, string login, string password)
        {
            InitializeComponent();

            // Resources
            MOTD_label.Text =                           Utils.getString("MOTD_label");
            apps_groupbox.Text =                        Utils.getString("apps_groupbox");
            file_menuItem.Text =                        Utils.getString("file_menuItem");
            edit_menuItem.Text =                        Utils.getString("edit_menuItem");
            view_menuItem.Text =                        Utils.getString("view_menuItem");
            server_menuItem.Text =                      Utils.getString("server_menuItem");
            help_menuItem.Text =                        Utils.getString("help_menuItem");
            showFilesToolStripMenuItem.Text =           Utils.getString("showFilesToolStripMenuItem");
            exitToolStripMenuItem.Text =                Utils.getString("exitToolStripMenuItem");
            clearCredentialsToolStripMenuItem.Text =    Utils.getString("clearCredentialsToolStripMenuItem");
            settingsToolStripMenuItem.Text =            Utils.getString("settingsToolStripMenuItem");
            refreshToolStripMenuItem.Text =             Utils.getString("refreshToolStripMenuItem");
            cancelToolStripMenuItem.Text =              Utils.getString("cancelToolStripMenuItem");
            disconnectToolStripMenuItem.Text =          Utils.getString("disconnectToolStripMenuItem");
            checkForUpdatesToolStripMenuItem.Text =     Utils.getString("checkForUpdatesToolStripMenuItem");
            reportABugToolStripMenuItem.Text =          Utils.getString("reportABugToolStripMenuItem");
            aboutToolStripMenuItem.Text =               Utils.getString("aboutToolStripMenuItem");

            _core = new Core(progress_label);
            _actuelSatus = new Dictionary<EInfo, string>();

            _core.connect(address, login, password);

            refreshInfo();

            Show();
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

            if (_actuelSatus.Count != 0 && MOTD_textBox.Text != _actuelSatus[EInfo.FRANPETTEMESSAGEOFTHEDAY])
            {
                _core.editMOTD(MOTD_textBox.Text, worker);
            }

            _core.refresh(worker);
        }

        private void refresh_info_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ftp_progressBar.Value = 0;
            _actuelSatus = _core.getData();

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
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);

            if (_actuelSatus.Count != 0)
            {
                if (MOTD_textBox.Text != _actuelSatus[EInfo.FRANPETTEMESSAGEOFTHEDAY])
                    _core.editMOTD(MOTD_textBox.Text, worker);
            }

            _core.refresh(worker);

            _core.applicationToogle(state_value.Text, host_button.Text, worker);
        }

        private void minecraft_toogle_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage >= 0)
                ftp_progressBar.Value = e.ProgressPercentage;

            total_progress.Text = e.ProgressPercentage + "%";

            TaskbarManager.Instance.SetProgressValue(e.ProgressPercentage, 100);
        }

        private void minecraft_toogle_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
            ftp_progressBar.Value = 0;
            total_progress.Text = "";
            refreshInfo();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.DownloadFile(new Uri("http://hesothread.com/builds/updater.exe"), "updater.exe");

            if (File.Exists("updater.exe"))
            {
                Process.Start("updater.exe");
                this.Close();
            }
        }

        public bool isLoggedOut()
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
            Utils.clearCredentials();
        }

        private void showFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Utils.getRoot());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://hesothread.com/#about");
        }

        private void reportABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Hesothread/Franpette/issues/new");
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }
    }
}
