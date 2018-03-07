using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WindowsFormsApplication2.Sources.Franpette;
using WindowsFormsApplication2.Sources.Serialisation;

namespace WindowsFormsApplication2
{
    public partial class Window : Form
    {
        public FranpetteCore _franpette;
        private Dictionary<EInfo, String> _actuelSatus;

        private Boolean _loggedOut = false;

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
            if (refresh_info.IsBusy != true && minecraft_toogle.IsBusy != true && check_updates.IsBusy != true)
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

            _franpette.infoUpdate(worker);
        }

        private void refresh_info_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ftp_progressBar.Value = 0;
            _actuelSatus = _franpette.getInfoValue();

            // update Franpette infos
            MOTD_textBox.Text = _actuelSatus[EInfo.FRANPETTEMESSAGEOFTHEDAY];
            version_label.Text = "version " + _actuelSatus[EInfo.FRANPETTEVERSION];

            // update Minecraft infos
            state_value.Text = _actuelSatus[EInfo.MINECRAFTSTATE];
            date_value.Text = _actuelSatus[EInfo.MINECRAFTDATE];
            user_value.Text = _actuelSatus[EInfo.MINECRAFTUSER];
            host_button.Text = _actuelSatus[EInfo.MINECRAFTIP];

            /*if (host_button.Text != null && host_button.Text != "NaN")
            {
                if (FranpetteUtils.isPortOpen(host_button.Text, 25565, new TimeSpan(0, 0, 0, 3, 0)))
                    host_button.ForeColor = Color.Green;
                else
                    host_button.ForeColor = Color.Red;
            }*/

            if (state_value.Text == "Start") state_value.ForeColor = Color.Green;
            else state_value.ForeColor = Color.Red;
        }

        private void minecraftToogle()
        {
            if (refresh_info.IsBusy != true && minecraft_toogle.IsBusy != true && check_updates.IsBusy != true)
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

            _franpette.infoUpdate(worker);

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
            ftp_progressBar.Value = e.ProgressPercentage;
        }

        private void minecraft_toogle_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ftp_progressBar.Value = 0;
            refreshInfo();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (refresh_info.IsBusy != true && minecraft_toogle.IsBusy != true && check_updates.IsBusy != true)
                check_updates.RunWorkerAsync();
        }

        private void check_updates_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            _franpette.checkForUpdates(worker);
        }

        public Boolean isLoggedOut()
        {
            return _loggedOut;
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (refresh_info.IsBusy != true && minecraft_toogle.IsBusy != true && check_updates.IsBusy != true)
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
    }
}
