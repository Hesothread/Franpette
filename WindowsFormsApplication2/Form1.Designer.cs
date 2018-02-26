namespace WindowsFormsApplication2
{
    partial class Window
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.apps_groupbox = new System.Windows.Forms.GroupBox();
            this.host_value = new System.Windows.Forms.Label();
            this.host_label = new System.Windows.Forms.Label();
            this.user_value = new System.Windows.Forms.Label();
            this.user_label = new System.Windows.Forms.Label();
            this.date_value = new System.Windows.Forms.Label();
            this.date_label = new System.Windows.Forms.Label();
            this.state_value = new System.Windows.Forms.Label();
            this.state_label = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.MOTD_textBox = new System.Windows.Forms.TextBox();
            this.version_label = new System.Windows.Forms.Label();
            this.version_value = new System.Windows.Forms.Label();
            this.ftp_progressBar = new System.Windows.Forms.ProgressBar();
            this.apps_groupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(6, 19);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Minecraft";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButtonClick);
            // 
            // apps_groupbox
            // 
            this.apps_groupbox.Controls.Add(this.host_value);
            this.apps_groupbox.Controls.Add(this.host_label);
            this.apps_groupbox.Controls.Add(this.user_value);
            this.apps_groupbox.Controls.Add(this.user_label);
            this.apps_groupbox.Controls.Add(this.date_value);
            this.apps_groupbox.Controls.Add(this.date_label);
            this.apps_groupbox.Controls.Add(this.state_value);
            this.apps_groupbox.Controls.Add(this.state_label);
            this.apps_groupbox.Controls.Add(this.startButton);
            this.apps_groupbox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.apps_groupbox.Location = new System.Drawing.Point(12, 151);
            this.apps_groupbox.Name = "apps_groupbox";
            this.apps_groupbox.Size = new System.Drawing.Size(678, 125);
            this.apps_groupbox.TabIndex = 3;
            this.apps_groupbox.TabStop = false;
            this.apps_groupbox.Text = "Applications";
            // 
            // host_value
            // 
            this.host_value.AutoSize = true;
            this.host_value.ForeColor = System.Drawing.Color.RoyalBlue;
            this.host_value.Location = new System.Drawing.Point(577, 24);
            this.host_value.Name = "host_value";
            this.host_value.Size = new System.Drawing.Size(0, 13);
            this.host_value.TabIndex = 10;
            // 
            // host_label
            // 
            this.host_label.AutoSize = true;
            this.host_label.Location = new System.Drawing.Point(534, 24);
            this.host_label.Name = "host_label";
            this.host_label.Size = new System.Drawing.Size(44, 13);
            this.host_label.TabIndex = 9;
            this.host_label.Text = "host ip :";
            // 
            // user_value
            // 
            this.user_value.AutoSize = true;
            this.user_value.ForeColor = System.Drawing.Color.RoyalBlue;
            this.user_value.Location = new System.Drawing.Point(446, 24);
            this.user_value.Name = "user_value";
            this.user_value.Size = new System.Drawing.Size(0, 13);
            this.user_value.TabIndex = 8;
            // 
            // user_label
            // 
            this.user_label.AutoSize = true;
            this.user_label.Location = new System.Drawing.Point(414, 24);
            this.user_label.Name = "user_label";
            this.user_label.Size = new System.Drawing.Size(33, 13);
            this.user_label.TabIndex = 7;
            this.user_label.Text = "user :";
            // 
            // date_value
            // 
            this.date_value.AutoSize = true;
            this.date_value.ForeColor = System.Drawing.Color.RoyalBlue;
            this.date_value.Location = new System.Drawing.Point(269, 24);
            this.date_value.Name = "date_value";
            this.date_value.Size = new System.Drawing.Size(0, 13);
            this.date_value.TabIndex = 6;
            // 
            // date_label
            // 
            this.date_label.AutoSize = true;
            this.date_label.Location = new System.Drawing.Point(212, 24);
            this.date_label.Name = "date_label";
            this.date_label.Size = new System.Drawing.Size(57, 13);
            this.date_label.TabIndex = 5;
            this.date_label.Text = "started at :";
            // 
            // state_value
            // 
            this.state_value.AutoSize = true;
            this.state_value.ForeColor = System.Drawing.Color.RoyalBlue;
            this.state_value.Location = new System.Drawing.Point(136, 24);
            this.state_value.Name = "state_value";
            this.state_value.Size = new System.Drawing.Size(0, 13);
            this.state_value.TabIndex = 4;
            // 
            // state_label
            // 
            this.state_label.AutoSize = true;
            this.state_label.Location = new System.Drawing.Point(102, 24);
            this.state_label.Name = "state_label";
            this.state_label.Size = new System.Drawing.Size(36, 13);
            this.state_label.TabIndex = 3;
            this.state_label.Text = "state :";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(18, 122);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 4;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButtonClick);
            // 
            // MOTD_textBox
            // 
            this.MOTD_textBox.Location = new System.Drawing.Point(12, 12);
            this.MOTD_textBox.Multiline = true;
            this.MOTD_textBox.Name = "MOTD_textBox";
            this.MOTD_textBox.Size = new System.Drawing.Size(678, 85);
            this.MOTD_textBox.TabIndex = 6;
            // 
            // version_label
            // 
            this.version_label.AutoSize = true;
            this.version_label.Location = new System.Drawing.Point(617, 127);
            this.version_label.Name = "version_label";
            this.version_label.Size = new System.Drawing.Size(47, 13);
            this.version_label.TabIndex = 7;
            this.version_label.Text = "version :";
            // 
            // version_value
            // 
            this.version_value.AutoSize = true;
            this.version_value.Location = new System.Drawing.Point(665, 127);
            this.version_value.Name = "version_value";
            this.version_value.Size = new System.Drawing.Size(0, 13);
            this.version_value.TabIndex = 8;
            // 
            // ftp_progressBar
            // 
            this.ftp_progressBar.AccessibleName = "";
            this.ftp_progressBar.Location = new System.Drawing.Point(99, 122);
            this.ftp_progressBar.Name = "ftp_progressBar";
            this.ftp_progressBar.Size = new System.Drawing.Size(510, 23);
            this.ftp_progressBar.TabIndex = 9;
            this.ftp_progressBar.Tag = "";
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 288);
            this.Controls.Add(this.ftp_progressBar);
            this.Controls.Add(this.version_value);
            this.Controls.Add(this.version_label);
            this.Controls.Add(this.MOTD_textBox);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.apps_groupbox);
            this.Name = "Window";
            this.Text = "Franpette";
            this.apps_groupbox.ResumeLayout(false);
            this.apps_groupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.GroupBox apps_groupbox;
        private System.Windows.Forms.Label state_label;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label date_value;
        private System.Windows.Forms.Label date_label;
        private System.Windows.Forms.Label state_value;
        private System.Windows.Forms.Label user_value;
        private System.Windows.Forms.Label user_label;
        private System.Windows.Forms.Label host_value;
        private System.Windows.Forms.Label host_label;
        private System.Windows.Forms.TextBox MOTD_textBox;
        private System.Windows.Forms.Label version_label;
        private System.Windows.Forms.Label version_value;
        private System.Windows.Forms.ProgressBar ftp_progressBar;
    }
}

