using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Resources;
using System.Windows.Forms;
using Franpette.Sources.Franpette;
using Franpette.Sources.Serialisation;

namespace Franpette
{
    public partial class Window : Form
    {
        public Core                         _core;
        private Dictionary<EInfo, String>   _actuelSatus;
        private Boolean                     _loggedOut = false;
        private ResourceManager             _resMan;
        private CultureInfo                 _cul;

        public Window(string address, string login, string password)
        {
            InitializeComponent();

            _resMan = new ResourceManager("Franpette.Resources.Lang", typeof(Program).Assembly);
            _cul = CultureInfo.CreateSpecificCulture(Utils.getLangTag());

            // Resources
            MOTD_label.Text =                           _resMan.GetString("MOTD_label", _cul);
            apps_groupbox.Text =                        _resMan.GetString("apps_groupbox", _cul);
            file_menuItem.Text =                        _resMan.GetString("file_menuItem", _cul);
            edit_menuItem.Text =                        _resMan.GetString("edit_menuItem", _cul);
            view_menuItem.Text =                        _resMan.GetString("view_menuItem", _cul);
            server_menuItem.Text =                      _resMan.GetString("server_menuItem", _cul);
            help_menuItem.Text =                        _resMan.GetString("help_menuItem", _cul);
            showFilesToolStripMenuItem.Text =           _resMan.GetString("showFilesToolStripMenuItem", _cul);
            exitToolStripMenuItem.Text =                _resMan.GetString("exitToolStripMenuItem", _cul);
            clearCredentialsToolStripMenuItem.Text =    _resMan.GetString("clearCredentialsToolStripMenuItem", _cul);
            settingsToolStripMenuItem.Text =            _resMan.GetString("settingsToolStripMenuItem", _cul);
            refreshToolStripMenuItem.Text =             _resMan.GetString("refreshToolStripMenuItem", _cul);
            cancelToolStripMenuItem.Text =              _resMan.GetString("cancelToolStripMenuItem", _cul);
            disconnectToolStripMenuItem.Text =          _resMan.GetString("disconnectToolStripMenuItem", _cul);
            checkForUpdatesToolStripMenuItem.Text =     _resMan.GetString("checkForUpdatesToolStripMenuItem", _cul);
            reportABugToolStripMenuItem.Text =          _resMan.GetString("reportABugToolStripMenuItem", _cul);
            aboutToolStripMenuItem.Text =               _resMan.GetString("aboutToolStripMenuItem", _cul);

            _core = new Core(progress_label);
            _actuelSatus = new Dictionary<EInfo, string>();

            _core.connect(address, login, password);

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

            if (_actuelSatus.Count != 0)
            {
                if (MOTD_textBox.Text != _actuelSatus[EInfo.FRANPETTEMESSAGEOFTHEDAY])
                    _core.editMOTD(MOTD_textBox.Text, worker);
            }

            _core.refresh(worker);

            if (state_value.Text != "Start")
            {
                if (_core.minecraftUpdate(worker)) _core.minecraftStart(worker);
            }
            else if (host_button.Text == Utils.getInternetIp())
            {
                _core.minecraftStop(worker);
            }
        }

        private void minecraft_toogle_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage >= 0)
                ftp_progressBar.Value = e.ProgressPercentage;

            total_progress.Text = e.ProgressPercentage + "%";
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
            Process.Start("https://turbet.nalo-corp.net/Franpette/#about");
        }

        private void reportABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/deshtros/Franpette/issues/new");
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }
    }
}
