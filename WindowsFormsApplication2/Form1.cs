using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication2.Sources;
using WindowsFormsApplication2.Sources.Franpette;
using WindowsFormsApplication2.Sources.Network;
using WindowsFormsApplication2.Sources.Serialisation;

namespace WindowsFormsApplication2
{
    public partial class Window : Form
    {
        public FranpetteCore _franpette;
        private Dictionary<EInfo, String> _actuelSatus;
        
        public Window()
        {
            InitializeComponent();
            _franpette = new FranpetteCore(ftp_progressBar, total_progressBar, login_textBox.Text, password_textBox.Text, address_textBox.Text);
            _actuelSatus = new Dictionary<EInfo, string>();

            if (File.Exists(FranpetteUtils.getAppdata() + "/.franpette/franpette.credentials"))
            {
                remember_checkBox.Hide();
                string[] credsLines = File.ReadAllLines(FranpetteUtils.getAppdata() + "/.franpette/franpette.credentials");
                address_textBox.Text = credsLines[0];
                login_textBox.Text = credsLines[1];
                password_textBox.Text = credsLines[2];
            }
        }

        private void refreshButtonClick(object sender, EventArgs e)
        {
            if (_actuelSatus.Count == 0)
                return;
            if (MOTD_textBox.Text != _actuelSatus[EInfo.FRANPETTEMESSAGEOFTHEDAY])
                _franpette.editMOTD(MOTD_textBox.Text);
            updateInfo();
        }

        private void startButtonClick(object sender, EventArgs e)
        {
            if (_franpette.isConnected())
            {
                updateInfo();

                if (state_value.Text != "Start")
                {
                    if (_franpette.minecraftUpdate()) _franpette.minecraftStart();
                }
                else if (host_value.Text == FranpetteUtils.getInternetIp())
                {
                    _franpette.minecraftStop();
                }

                updateInfo();
            }
            else
                Console.WriteLine("[Form1] startButtonClick : not connected !");
        }

        private void updateInfo()
        {
            _franpette.infoUpdate();
            _actuelSatus = _franpette.getInfoValue();

            // update Franpette infos
            MOTD_textBox.Text = _actuelSatus[EInfo.FRANPETTEMESSAGEOFTHEDAY];
            version_value.Text = _actuelSatus[EInfo.FRANPETTEVERSION];

            // update Minecraft infos
            state_value.Text = _actuelSatus[EInfo.MINECRAFTSTATE];
            date_value.Text = _actuelSatus[EInfo.MINECRAFTDATE];
            user_value.Text = _actuelSatus[EInfo.MINECRAFTUSER];
            host_value.Text = _actuelSatus[EInfo.MINECRAFTIP];

            if (FranpetteUtils.isPortOpen(host_value.Text, 25565, new TimeSpan(0, 0, 0, 3, 0)))
                host_value.ForeColor = Color.Green;
            else
                host_value.ForeColor = Color.Red;

            if (state_value.Text == "Start")
            {
                state_value.ForeColor = Color.Green;
                date_label.Text = "started at :";
            }
            else
            {
                state_value.ForeColor = Color.Red;
                date_label.Text = "stoped at :";
            }
        }

        private void connect_buttonClick(object sender, EventArgs e)
        {
            if (connect_button.Text == "Connected")
            {
                connect_button.Text = "Disconnected";
                _franpette.disconnect();
            }
            else
            {
                connect_button.Text = "Connected";
                if (remember_checkBox.Checked && address_textBox.Text != null && login_textBox.Text != null && password_textBox.Text != null)
                    FranpetteUtils.saveCredentials(address_textBox.Text, login_textBox.Text, password_textBox.Text);
                _franpette.connect(address_textBox.Text, login_textBox.Text, password_textBox.Text);
                updateInfo();
            }
        }

        private void host_valueClick(object sender, EventArgs e)
        {
            if (host_value.Text != null && host_value.Text != "NaN")
                Clipboard.SetText(host_value.Text);
        }
    }
}
