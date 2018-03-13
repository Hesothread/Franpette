namespace Franpette
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Connection");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Language");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.tree_label = new System.Windows.Forms.Label();
            this.apply_button = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox0 = new System.Windows.Forms.GroupBox();
            this.autologin_label = new System.Windows.Forms.Label();
            this.autologin_checkBox = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lang_listBox = new System.Windows.Forms.ListBox();
            this.langInfo_label = new System.Windows.Forms.Label();
            this.langList_label = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox0.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tree_label
            // 
            this.tree_label.AutoSize = true;
            this.tree_label.Location = new System.Drawing.Point(12, 9);
            this.tree_label.Name = "tree_label";
            this.tree_label.Size = new System.Drawing.Size(78, 16);
            this.tree_label.TabIndex = 0;
            this.tree_label.Text = "Select page:";
            // 
            // apply_button
            // 
            this.apply_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.apply_button.Location = new System.Drawing.Point(12, 434);
            this.apply_button.Name = "apply_button";
            this.apply_button.Size = new System.Drawing.Size(176, 38);
            this.apply_button.TabIndex = 1;
            this.apply_button.Text = "Apply";
            this.apply_button.UseVisualStyleBackColor = true;
            this.apply_button.Click += new System.EventHandler(this.apply_button_Click);
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130)))));
            this.treeView.ForeColor = System.Drawing.Color.White;
            this.treeView.Location = new System.Drawing.Point(12, 28);
            this.treeView.Name = "treeView";
            treeNode1.Name = "connection";
            treeNode1.Tag = "0";
            treeNode1.Text = "Connection";
            treeNode2.Name = "language";
            treeNode2.Tag = "1";
            treeNode2.Text = "Language";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.treeView.Size = new System.Drawing.Size(176, 400);
            this.treeView.TabIndex = 4;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Location = new System.Drawing.Point(194, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 473);
            this.panel1.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(460, 478);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(452, 449);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox0);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(443, 440);
            this.panel2.TabIndex = 0;
            // 
            // groupBox0
            // 
            this.groupBox0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130)))));
            this.groupBox0.Controls.Add(this.autologin_label);
            this.groupBox0.Controls.Add(this.autologin_checkBox);
            this.groupBox0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox0.ForeColor = System.Drawing.Color.White;
            this.groupBox0.Location = new System.Drawing.Point(3, 3);
            this.groupBox0.Name = "groupBox0";
            this.groupBox0.Size = new System.Drawing.Size(437, 434);
            this.groupBox0.TabIndex = 0;
            this.groupBox0.TabStop = false;
            this.groupBox0.Text = "Connection";
            // 
            // autologin_label
            // 
            this.autologin_label.AutoSize = true;
            this.autologin_label.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.autologin_label.Location = new System.Drawing.Point(7, 26);
            this.autologin_label.Name = "autologin_label";
            this.autologin_label.Size = new System.Drawing.Size(94, 16);
            this.autologin_label.TabIndex = 1;
            this.autologin_label.Text = "autologin_label";
            // 
            // autologin_checkBox
            // 
            this.autologin_checkBox.AutoSize = true;
            this.autologin_checkBox.Location = new System.Drawing.Point(10, 45);
            this.autologin_checkBox.Name = "autologin_checkBox";
            this.autologin_checkBox.Size = new System.Drawing.Size(139, 20);
            this.autologin_checkBox.TabIndex = 0;
            this.autologin_checkBox.Text = "autologin_checkBox";
            this.autologin_checkBox.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(452, 449);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Location = new System.Drawing.Point(6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(442, 440);
            this.panel3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130)))));
            this.groupBox1.Controls.Add(this.lang_listBox);
            this.groupBox1.Controls.Add(this.langInfo_label);
            this.groupBox1.Controls.Add(this.langList_label);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 434);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Language";
            // 
            // lang_listBox
            // 
            this.lang_listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130)))));
            this.lang_listBox.ForeColor = System.Drawing.Color.White;
            this.lang_listBox.FormattingEnabled = true;
            this.lang_listBox.ItemHeight = 16;
            this.lang_listBox.Items.AddRange(new object[] {
            "English (en_US)",
            "Français (fr)",
            "Español (es)"});
            this.lang_listBox.Location = new System.Drawing.Point(10, 45);
            this.lang_listBox.Name = "lang_listBox";
            this.lang_listBox.Size = new System.Drawing.Size(239, 356);
            this.lang_listBox.TabIndex = 3;
            // 
            // langInfo_label
            // 
            this.langInfo_label.AutoSize = true;
            this.langInfo_label.Location = new System.Drawing.Point(6, 404);
            this.langInfo_label.Name = "langInfo_label";
            this.langInfo_label.Size = new System.Drawing.Size(343, 16);
            this.langInfo_label.TabIndex = 2;
            this.langInfo_label.Text = "If you change the language, you need to restart Franpette.";
            // 
            // langList_label
            // 
            this.langList_label.AutoSize = true;
            this.langList_label.Location = new System.Drawing.Point(7, 26);
            this.langList_label.Name = "langList_label";
            this.langList_label.Size = new System.Drawing.Size(101, 16);
            this.langList_label.TabIndex = 1;
            this.langList_label.Text = "Select language:";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(661, 486);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.apply_button);
            this.Controls.Add(this.tree_label);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox0.ResumeLayout(false);
            this.groupBox0.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tree_label;
        private System.Windows.Forms.Button apply_button;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox0;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label autologin_label;
        private System.Windows.Forms.CheckBox autologin_checkBox;
        private System.Windows.Forms.Label langInfo_label;
        private System.Windows.Forms.Label langList_label;
        private System.Windows.Forms.ListBox lang_listBox;
    }
}