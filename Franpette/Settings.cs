using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using Franpette.Sources.Franpette;

namespace Franpette
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            // Resources
            Text =                      Utils.getString("settings_window");
            tree_label.Text =           Utils.getString("tree_label");
            treeView.Nodes[0].Text =    Utils.getString("treeView_connection");
            groupBox0.Text =            Utils.getString("treeView_connection");
            treeView.Nodes[1].Text =    Utils.getString("treeView_language");
            groupBox1.Text =            Utils.getString("treeView_language");
            treeView.Nodes[2].Text =    Utils.getString("treeView_directories");
            groupBox2.Text =            Utils.getString("treeView_directories");
            autologin_label.Text =      Utils.getString("autologin_label");
            autologin_checkBox.Text =   Utils.getString("autologin_checkBox");
            langList_label.Text =       Utils.getString("langList_label");
            langInfo_label.Text =       Utils.getString("langInfo_label");
            cld_button.Text =           Utils.getString("cld_button");
            cld_label.Text =            Utils.getString("cld_label");
            apply_button.Text =         Utils.getString("apply_button");
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

            autologin_checkBox.Checked = (Utils.getProperty("autologin").Equals("True")) ? true : false;

            lang_listBox.SetSelected(getIndexLang(lang_listBox), true);

            cld_value.Text = Utils.getProperty("directory", Utils.getRoot());
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
            File.WriteAllLines(Utils.getRoot("franpette.properties"), new string[] {
                "autologin:" + autologin_checkBox.Checked.ToString(),
                "lang:" + lang_listBox.SelectedItem.ToString().Split('(')[1].Substring(0, lang_listBox.SelectedItem.ToString().Split('(')[1].Length - 1),
                "directory:" + cld_value.Text
            });

            Utils.debug("[Settings] changes saved");
            Close();
        }

        private void cld_button_Click(object sender, EventArgs e)
        {
            folderBrowser.ShowDialog();
            cld_value.Text = folderBrowser.SelectedPath + "\\";
        }

        // Retourne l'index de la langue courante
        private int getIndexLang(ListBox list)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                if (list.Items[i].ToString().Contains("(" + Utils.getProperty("lang", "en-US") + ")"))
                {
                    return i;
                }
            }

            return 0;
        }
    }
}
