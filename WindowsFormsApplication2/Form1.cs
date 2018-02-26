using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
        private Dictionary<EInfo, String> _newStatus;

        public Window()
        {
            InitializeComponent();

            _franpette = new FranpetteCore(ftp_progressBar); // ftp_progressBar used by NetworkFTP
            _newStatus = new Dictionary<EInfo, string>();

            updateInfo();
        }

        private void refreshButtonClick(object sender, EventArgs e)
        {
            if (MOTD_textBox.Text != _newStatus[EInfo.FRANPETTEMESSAGEOFTHEDAY])
                _franpette.editMOTD(MOTD_textBox.Text);
            updateInfo();
        }

        private void startButtonClick(object sender, EventArgs e)
        {
            updateInfo();

            if (state_value.Text != "Start")
            {
                _franpette.minecraftUpdate();

                if (_franpette.getIsMinecraftUpToDate())
                    _franpette.minecraftStart();
            }
            else
            {
                _franpette.minecraftStop();
            }

            updateInfo();
        }

        private void updateInfo()
        {
            _franpette.infoUpdate();
            _newStatus = _franpette.getInfoValue();

            // update Franpette infos
            MOTD_textBox.Text = _newStatus[EInfo.FRANPETTEMESSAGEOFTHEDAY];
            version_value.Text = _newStatus[EInfo.FRANPETTEVERSION];

            // update Minecraft infos
            state_value.Text = _newStatus[EInfo.MINECRAFTSTATE];
            date_value.Text = _newStatus[EInfo.MINECRAFTDATE];
            user_value.Text = _newStatus[EInfo.MINECRAFTUSER];
            host_value.Text = _newStatus[EInfo.MINECRAFTIP];

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
    }
}
