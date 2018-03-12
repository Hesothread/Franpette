using Franpette.Sources.Franpette;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Franpette
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        List<Panel> Panels = new List<Panel>();
        Panel VisiblePanel = null;

        private void Settings_Load(object sender, EventArgs e)
        {
            treeView.ExpandAll();

            tabControl1.Visible = false;
            foreach (TabPage page in tabControl1.TabPages)
            {
                Panel panel = page.Controls[0] as Panel;
                Panels.Add(panel);

                panel.Parent = tabControl1.Parent;
                panel.Location = tabControl1.Location;
                panel.Visible = false;
            }

            DisplayPanel(0);

            if (File.Exists(FranpetteUtils.getRoot("franpette.properties")))
            {
                foreach (string line in File.ReadAllLines(FranpetteUtils.getRoot("franpette.properties")))
                {
                    string setting = line.Split(':')[0];
                    string value = line.Split(':')[1];

                    switch (setting)
                    {
                        case "autologin":
                            autologin_checkBox.Checked = value.Equals("True") ? true : false;
                            break;
                    }
                }
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int index = int.Parse(e.Node.Tag.ToString());
            DisplayPanel(index);
        }

        private void DisplayPanel(int index)
        {
            if (Panels.Count < 1) return;

            if (VisiblePanel == Panels[index]) return;
            if (VisiblePanel != null) VisiblePanel.Visible = false;

            Panels[index].Visible = true;
            VisiblePanel = Panels[index];
        }

        private void apply_button_Click(object sender, EventArgs e)
        {
            List<string> settingsLines = new List<string>();

            settingsLines.Add("autologin:" + autologin_checkBox.Checked.ToString());

            File.WriteAllLines(FranpetteUtils.getRoot("franpette.properties"), settingsLines.ToArray());

            this.Close();
        }
    }
}
