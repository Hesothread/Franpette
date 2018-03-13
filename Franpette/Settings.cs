using Franpette.Sources.Franpette;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace Franpette
{
    public partial class Settings : Form
    {
        private ResourceManager _resMan;
        private CultureInfo     _cul;

        public Settings()
        {
            InitializeComponent();

            _resMan = new ResourceManager("Franpette.Resources.Lang", typeof(Program).Assembly);
            _cul = CultureInfo.CreateSpecificCulture(Utils.getLangTag());

            // Resources
            this.Text =                 _resMan.GetString("settings_window", _cul);
            tree_label.Text =           _resMan.GetString("tree_label", _cul);

            treeView.Nodes[0].Text =    _resMan.GetString("treeView_connection", _cul);
            groupBox0.Text =            _resMan.GetString("treeView_connection", _cul);
            treeView.Nodes[1].Text =    _resMan.GetString("treeView_language", _cul);
            groupBox1.Text =            _resMan.GetString("treeView_language", _cul);

            autologin_label.Text =      _resMan.GetString("autologin_label", _cul);
            autologin_checkBox.Text =   _resMan.GetString("autologin_checkBox", _cul);

            langList_label.Text =       _resMan.GetString("langList_label", _cul);
            langInfo_label.Text =       _resMan.GetString("langInfo_label", _cul);

            apply_button.Text =         _resMan.GetString("apply_button", _cul);
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

            autologin_checkBox.Checked = Utils.isAutoLogin();
            lang_listBox.SetSelected(Utils.getIndexLang(lang_listBox), true);
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
            settingsLines.Add("lang:" + lang_listBox.SelectedItem.ToString().Split('(')[1].Substring(0, lang_listBox.SelectedItem.ToString().Split('(')[1].Length - 1));

            File.WriteAllLines(Utils.getRoot("franpette.properties"), settingsLines.ToArray());

            MessageBox.Show(_resMan.GetString("settings_saved", _cul));
        }
    }
}
