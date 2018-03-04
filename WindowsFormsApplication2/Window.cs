using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApplication2.Sources.Franpette;
using WindowsFormsApplication2.Sources.Serialisation;

namespace WindowsFormsApplication2
{
    public partial class Window : Form
    {
        public FranpetteCore _franpette;
        private Dictionary<EInfo, String> _actuelSatus;
        
        public Window(string address, string login, string password)
        {
            InitializeComponent();
            _franpette = new FranpetteCore(ftp_progressBar, total_progressBar);
            _franpette.connect(address, login, password);
            _actuelSatus = new Dictionary<EInfo, string>();

            refreshInfo();
        }

        private void refresh_button_Click(object sender, EventArgs e)
        {
            if (_actuelSatus.Count == 0)
                return;
            if (MOTD_textBox.Text != _actuelSatus[EInfo.FRANPETTEMESSAGEOFTHEDAY])
                _franpette.editMOTD(MOTD_textBox.Text);
            refreshInfo();
        }

        private void minecraft_button_Click(object sender, EventArgs e)
        {
            refreshInfo();

            if (state_value.Text != "Start")
            {
                if (_franpette.minecraftUpdate()) _franpette.minecraftStart();
            }
            else if (host_button.Text == FranpetteUtils.getInternetIp())
            {
                _franpette.minecraftStop();
            }

            refreshInfo();
        }

        private void refreshInfo()
        {
            _franpette.infoUpdate();
            _actuelSatus = _franpette.getInfoValue();

            // update Franpette infos
            MOTD_textBox.Text = _actuelSatus[EInfo.FRANPETTEMESSAGEOFTHEDAY];
            version_label.Text = "version " + _actuelSatus[EInfo.FRANPETTEVERSION];

            // update Minecraft infos
            state_value.Text = _actuelSatus[EInfo.MINECRAFTSTATE];
            date_value.Text = _actuelSatus[EInfo.MINECRAFTDATE];
            user_value.Text = _actuelSatus[EInfo.MINECRAFTUSER];
            host_button.Text = _actuelSatus[EInfo.MINECRAFTIP];

            if (FranpetteUtils.isPortOpen(host_button.Text, 25565, new TimeSpan(0, 0, 0, 3, 0)))
                host_button.ForeColor = Color.Green;
            else
                host_button.ForeColor = Color.Red;

            if (state_value.Text == "Start") state_value.ForeColor = Color.Green;
            else state_value.ForeColor = Color.Red;
        }

        private void host_button_Click(object sender, EventArgs e)
        {
            if (host_button.Text != null && host_button.Text != "NaN")
                Clipboard.SetText(host_button.Text);
        }
    }
}
