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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.start_button = new System.Windows.Forms.Button();
            this.apps_groupbox = new System.Windows.Forms.GroupBox();
            this.host_value = new System.Windows.Forms.Label();
            this.host_label = new System.Windows.Forms.Label();
            this.user_value = new System.Windows.Forms.Label();
            this.user_label = new System.Windows.Forms.Label();
            this.date_value = new System.Windows.Forms.Label();
            this.date_label = new System.Windows.Forms.Label();
            this.state_value = new System.Windows.Forms.Label();
            this.state_label = new System.Windows.Forms.Label();
            this.refresh_button = new System.Windows.Forms.Button();
            this.MOTD_textBox = new System.Windows.Forms.TextBox();
            this.version_label = new System.Windows.Forms.Label();
            this.version_value = new System.Windows.Forms.Label();
            this.ftp_progressBar = new System.Windows.Forms.ProgressBar();
            this.login_textBox = new System.Windows.Forms.TextBox();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.address_textBox = new System.Windows.Forms.TextBox();
            this.connect_button = new System.Windows.Forms.Button();
            this.login_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.address_label = new System.Windows.Forms.Label();
            this.remember_checkBox = new System.Windows.Forms.CheckBox();
            this.total_progressBar = new System.Windows.Forms.ProgressBar();
            this.MOTD_label = new System.Windows.Forms.Label();
            this.apps_groupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // start_button
            // 
            this.start_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.start_button.Location = new System.Drawing.Point(6, 19);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(75, 23);
            this.start_button.TabIndex = 0;
            this.start_button.Text = "Minecraft";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.startButtonClick);
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
            this.apps_groupbox.Controls.Add(this.start_button);
            this.apps_groupbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.apps_groupbox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.apps_groupbox.Location = new System.Drawing.Point(15, 189);
            this.apps_groupbox.Name = "apps_groupbox";
            this.apps_groupbox.Size = new System.Drawing.Size(675, 155);
            this.apps_groupbox.TabIndex = 3;
            this.apps_groupbox.TabStop = false;
            this.apps_groupbox.Text = "Applications";
            // 
            // host_value
            // 
            this.host_value.AutoSize = true;
            this.host_value.ForeColor = System.Drawing.SystemColors.ControlLight;
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
            this.user_value.ForeColor = System.Drawing.SystemColors.ControlLight;
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
            this.date_value.ForeColor = System.Drawing.SystemColors.ControlLight;
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
            // refresh_button
            // 
            this.refresh_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.refresh_button.Location = new System.Drawing.Point(117, 136);
            this.refresh_button.Name = "refresh_button";
            this.refresh_button.Size = new System.Drawing.Size(115, 39);
            this.refresh_button.TabIndex = 4;
            this.refresh_button.Text = "Refresh infos";
            this.refresh_button.UseVisualStyleBackColor = true;
            this.refresh_button.Click += new System.EventHandler(this.refreshButtonClick);
            // 
            // MOTD_textBox
            // 
            this.MOTD_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MOTD_textBox.Location = new System.Drawing.Point(238, 12);
            this.MOTD_textBox.Multiline = true;
            this.MOTD_textBox.Name = "MOTD_textBox";
            this.MOTD_textBox.Size = new System.Drawing.Size(452, 101);
            this.MOTD_textBox.TabIndex = 6;
            // 
            // version_label
            // 
            this.version_label.AutoSize = true;
            this.version_label.Location = new System.Drawing.Point(12, 149);
            this.version_label.Name = "version_label";
            this.version_label.Size = new System.Drawing.Size(42, 13);
            this.version_label.TabIndex = 7;
            this.version_label.Text = "Version";
            // 
            // version_value
            // 
            this.version_value.AutoSize = true;
            this.version_value.Location = new System.Drawing.Point(58, 149);
            this.version_value.Name = "version_value";
            this.version_value.Size = new System.Drawing.Size(0, 13);
            this.version_value.TabIndex = 8;
            // 
            // ftp_progressBar
            // 
            this.ftp_progressBar.AccessibleName = "";
            this.ftp_progressBar.BackColor = System.Drawing.SystemColors.Window;
            this.ftp_progressBar.Location = new System.Drawing.Point(238, 136);
            this.ftp_progressBar.Name = "ftp_progressBar";
            this.ftp_progressBar.Size = new System.Drawing.Size(452, 29);
            this.ftp_progressBar.TabIndex = 9;
            this.ftp_progressBar.Tag = "";
            // 
            // login_textBox
            // 
            this.login_textBox.AccessibleDescription = "pk";
            this.login_textBox.AccessibleName = "ooo";
            this.login_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.login_textBox.Location = new System.Drawing.Point(51, 12);
            this.login_textBox.Name = "login_textBox";
            this.login_textBox.Size = new System.Drawing.Size(181, 20);
            this.login_textBox.TabIndex = 10;
            this.login_textBox.Tag = "azeaze";
            this.login_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // password_textBox
            // 
            this.password_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password_textBox.Location = new System.Drawing.Point(51, 37);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.PasswordChar = '*';
            this.password_textBox.Size = new System.Drawing.Size(181, 20);
            this.password_textBox.TabIndex = 11;
            this.password_textBox.Tag = "";
            this.password_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.password_textBox.UseSystemPasswordChar = true;
            // 
            // address_textBox
            // 
            this.address_textBox.AccessibleDescription = "pk";
            this.address_textBox.AccessibleName = "ooo";
            this.address_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.address_textBox.Location = new System.Drawing.Point(51, 63);
            this.address_textBox.Name = "address_textBox";
            this.address_textBox.Size = new System.Drawing.Size(181, 20);
            this.address_textBox.TabIndex = 12;
            this.address_textBox.Tag = "azeaze";
            this.address_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // connect_button
            // 
            this.connect_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.connect_button.Location = new System.Drawing.Point(51, 89);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(181, 24);
            this.connect_button.TabIndex = 13;
            this.connect_button.Text = "Connect to the server";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.connect_buttonClick);
            // 
            // login_label
            // 
            this.login_label.AutoSize = true;
            this.login_label.Location = new System.Drawing.Point(12, 15);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(33, 13);
            this.login_label.TabIndex = 14;
            this.login_label.Text = "Login";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(12, 40);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(30, 13);
            this.password_label.TabIndex = 15;
            this.password_label.Text = "Pass";
            // 
            // address_label
            // 
            this.address_label.AutoSize = true;
            this.address_label.Location = new System.Drawing.Point(12, 66);
            this.address_label.Name = "address_label";
            this.address_label.Size = new System.Drawing.Size(29, 13);
            this.address_label.TabIndex = 16;
            this.address_label.Text = "Addr";
            // 
            // remember_checkBox
            // 
            this.remember_checkBox.AutoSize = true;
            this.remember_checkBox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.remember_checkBox.FlatAppearance.BorderSize = 0;
            this.remember_checkBox.Location = new System.Drawing.Point(15, 95);
            this.remember_checkBox.Name = "remember_checkBox";
            this.remember_checkBox.Size = new System.Drawing.Size(15, 14);
            this.remember_checkBox.TabIndex = 17;
            this.remember_checkBox.UseVisualStyleBackColor = true;
            // 
            // total_progressBar
            // 
            this.total_progressBar.BackColor = System.Drawing.SystemColors.Window;
            this.total_progressBar.Location = new System.Drawing.Point(238, 165);
            this.total_progressBar.Name = "total_progressBar";
            this.total_progressBar.Size = new System.Drawing.Size(452, 10);
            this.total_progressBar.TabIndex = 18;
            // 
            // MOTD_label
            // 
            this.MOTD_label.AutoSize = true;
            this.MOTD_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MOTD_label.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.MOTD_label.Location = new System.Drawing.Point(604, 113);
            this.MOTD_label.Name = "MOTD_label";
            this.MOTD_label.Size = new System.Drawing.Size(86, 12);
            this.MOTD_label.TabIndex = 19;
            this.MOTD_label.Text = "Message of the day";
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(99)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(702, 357);
            this.Controls.Add(this.MOTD_label);
            this.Controls.Add(this.total_progressBar);
            this.Controls.Add(this.remember_checkBox);
            this.Controls.Add(this.address_label);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.login_label);
            this.Controls.Add(this.connect_button);
            this.Controls.Add(this.address_textBox);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.login_textBox);
            this.Controls.Add(this.ftp_progressBar);
            this.Controls.Add(this.version_value);
            this.Controls.Add(this.version_label);
            this.Controls.Add(this.MOTD_textBox);
            this.Controls.Add(this.refresh_button);
            this.Controls.Add(this.apps_groupbox);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Franpette";
            this.apps_groupbox.ResumeLayout(false);
            this.apps_groupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.GroupBox apps_groupbox;
        private System.Windows.Forms.Label state_label;
        private System.Windows.Forms.Button refresh_button;
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
        private System.Windows.Forms.TextBox login_textBox;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.TextBox address_textBox;
        private System.Windows.Forms.Button connect_button;
        private System.Windows.Forms.Label login_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Label address_label;
        private System.Windows.Forms.CheckBox remember_checkBox;
        private System.Windows.Forms.ProgressBar total_progressBar;
        private System.Windows.Forms.Label MOTD_label;
    }
}

