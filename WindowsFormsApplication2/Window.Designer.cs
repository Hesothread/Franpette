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
            this.host_value = new System.Windows.Forms.Button();
            this.host_label = new System.Windows.Forms.Label();
            this.user_value = new System.Windows.Forms.Label();
            this.user_label = new System.Windows.Forms.Label();
            this.date_value = new System.Windows.Forms.Label();
            this.date_label = new System.Windows.Forms.Label();
            this.state_value = new System.Windows.Forms.Label();
            this.state_label = new System.Windows.Forms.Label();
            this.MOTD_textBox = new System.Windows.Forms.TextBox();
            this.version_label = new System.Windows.Forms.Label();
            this.version_value = new System.Windows.Forms.Label();
            this.ftp_progressBar = new System.Windows.Forms.ProgressBar();
            this.total_progressBar = new System.Windows.Forms.ProgressBar();
            this.MOTD_label = new System.Windows.Forms.Label();
            this.refresh_pictureBox = new System.Windows.Forms.PictureBox();
            this.apps_groupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refresh_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // start_button
            // 
            this.start_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_button.ForeColor = System.Drawing.Color.White;
            this.start_button.Location = new System.Drawing.Point(6, 19);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(123, 23);
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
            this.apps_groupbox.Font = new System.Drawing.Font("Minecraftia", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apps_groupbox.ForeColor = System.Drawing.Color.White;
            this.apps_groupbox.Location = new System.Drawing.Point(12, 174);
            this.apps_groupbox.Name = "apps_groupbox";
            this.apps_groupbox.Size = new System.Drawing.Size(686, 210);
            this.apps_groupbox.TabIndex = 3;
            this.apps_groupbox.TabStop = false;
            this.apps_groupbox.Text = "Applications";
            // 
            // host_value
            // 
            this.host_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(99)))), ((int)(((byte)(130)))));
            this.host_value.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.host_value.Location = new System.Drawing.Point(584, 19);
            this.host_value.Name = "host_value";
            this.host_value.Size = new System.Drawing.Size(94, 23);
            this.host_value.TabIndex = 10;
            this.host_value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.host_value.UseVisualStyleBackColor = false;
            this.host_value.Click += new System.EventHandler(this.host_valueClick);
            // 
            // host_label
            // 
            this.host_label.AutoSize = true;
            this.host_label.Location = new System.Drawing.Point(534, 24);
            this.host_label.Name = "host_label";
            this.host_label.Size = new System.Drawing.Size(49, 16);
            this.host_label.TabIndex = 9;
            this.host_label.Text = "host ip :";
            // 
            // user_value
            // 
            this.user_value.AutoSize = true;
            this.user_value.ForeColor = System.Drawing.Color.White;
            this.user_value.Location = new System.Drawing.Point(449, 24);
            this.user_value.Name = "user_value";
            this.user_value.Size = new System.Drawing.Size(64, 16);
            this.user_value.TabIndex = 8;
            this.user_value.Text = "username";
            // 
            // user_label
            // 
            this.user_label.AutoSize = true;
            this.user_label.ForeColor = System.Drawing.Color.White;
            this.user_label.Location = new System.Drawing.Point(412, 24);
            this.user_label.Name = "user_label";
            this.user_label.Size = new System.Drawing.Size(40, 16);
            this.user_label.TabIndex = 7;
            this.user_label.Text = "user :";
            // 
            // date_value
            // 
            this.date_value.AutoSize = true;
            this.date_value.ForeColor = System.Drawing.Color.White;
            this.date_value.Location = new System.Drawing.Point(267, 24);
            this.date_value.Name = "date_value";
            this.date_value.Size = new System.Drawing.Size(126, 16);
            this.date_value.TabIndex = 6;
            this.date_value.Text = "01/01/2018 01:23:45";
            // 
            // date_label
            // 
            this.date_label.AutoSize = true;
            this.date_label.ForeColor = System.Drawing.Color.White;
            this.date_label.Location = new System.Drawing.Point(233, 24);
            this.date_label.Name = "date_label";
            this.date_label.Size = new System.Drawing.Size(38, 16);
            this.date_label.TabIndex = 5;
            this.date_label.Text = "date :";
            // 
            // state_value
            // 
            this.state_value.AutoSize = true;
            this.state_value.ForeColor = System.Drawing.Color.White;
            this.state_value.Location = new System.Drawing.Point(180, 24);
            this.state_value.Name = "state_value";
            this.state_value.Size = new System.Drawing.Size(39, 16);
            this.state_value.TabIndex = 4;
            this.state_value.Text = "State";
            // 
            // state_label
            // 
            this.state_label.AutoSize = true;
            this.state_label.Location = new System.Drawing.Point(139, 24);
            this.state_label.Name = "state_label";
            this.state_label.Size = new System.Drawing.Size(43, 16);
            this.state_label.TabIndex = 3;
            this.state_label.Text = "state :";
            // 
            // MOTD_textBox
            // 
            this.MOTD_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130)))));
            this.MOTD_textBox.Font = new System.Drawing.Font("Minecraftia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MOTD_textBox.ForeColor = System.Drawing.Color.White;
            this.MOTD_textBox.Location = new System.Drawing.Point(12, 14);
            this.MOTD_textBox.Margin = new System.Windows.Forms.Padding(5);
            this.MOTD_textBox.Multiline = true;
            this.MOTD_textBox.Name = "MOTD_textBox";
            this.MOTD_textBox.Size = new System.Drawing.Size(686, 94);
            this.MOTD_textBox.TabIndex = 6;
            // 
            // version_label
            // 
            this.version_label.AutoSize = true;
            this.version_label.Font = new System.Drawing.Font("Minecraftia", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.version_label.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.version_label.Location = new System.Drawing.Point(626, 383);
            this.version_label.Name = "version_label";
            this.version_label.Size = new System.Drawing.Size(52, 16);
            this.version_label.TabIndex = 7;
            this.version_label.Text = "version";
            // 
            // version_value
            // 
            this.version_value.AutoSize = true;
            this.version_value.Font = new System.Drawing.Font("Minecraftia", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.version_value.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.version_value.Location = new System.Drawing.Point(673, 383);
            this.version_value.Name = "version_value";
            this.version_value.Size = new System.Drawing.Size(29, 16);
            this.version_value.TabIndex = 8;
            this.version_value.Text = "xxx";
            // 
            // ftp_progressBar
            // 
            this.ftp_progressBar.AccessibleName = "";
            this.ftp_progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130)))));
            this.ftp_progressBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.ftp_progressBar.ForeColor = System.Drawing.Color.White;
            this.ftp_progressBar.Location = new System.Drawing.Point(12, 130);
            this.ftp_progressBar.Name = "ftp_progressBar";
            this.ftp_progressBar.Size = new System.Drawing.Size(686, 29);
            this.ftp_progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ftp_progressBar.TabIndex = 9;
            this.ftp_progressBar.Tag = "";
            // 
            // total_progressBar
            // 
            this.total_progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130)))));
            this.total_progressBar.ForeColor = System.Drawing.Color.White;
            this.total_progressBar.Location = new System.Drawing.Point(12, 158);
            this.total_progressBar.Name = "total_progressBar";
            this.total_progressBar.Size = new System.Drawing.Size(686, 10);
            this.total_progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.total_progressBar.TabIndex = 18;
            // 
            // MOTD_label
            // 
            this.MOTD_label.AutoSize = true;
            this.MOTD_label.Font = new System.Drawing.Font("Minecraftia", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MOTD_label.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.MOTD_label.Location = new System.Drawing.Point(585, 107);
            this.MOTD_label.Name = "MOTD_label";
            this.MOTD_label.Size = new System.Drawing.Size(116, 16);
            this.MOTD_label.TabIndex = 19;
            this.MOTD_label.Text = "message of the day";
            // 
            // refresh_pictureBox
            // 
            this.refresh_pictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.refresh_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("refresh_pictureBox.Image")));
            this.refresh_pictureBox.Location = new System.Drawing.Point(681, 8);
            this.refresh_pictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.refresh_pictureBox.Name = "refresh_pictureBox";
            this.refresh_pictureBox.Padding = new System.Windows.Forms.Padding(3);
            this.refresh_pictureBox.Size = new System.Drawing.Size(22, 22);
            this.refresh_pictureBox.TabIndex = 20;
            this.refresh_pictureBox.TabStop = false;
            this.refresh_pictureBox.Click += new System.EventHandler(this.refresh_pictureBox_Click);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(712, 402);
            this.Controls.Add(this.refresh_pictureBox);
            this.Controls.Add(this.MOTD_label);
            this.Controls.Add(this.total_progressBar);
            this.Controls.Add(this.ftp_progressBar);
            this.Controls.Add(this.version_value);
            this.Controls.Add(this.version_label);
            this.Controls.Add(this.MOTD_textBox);
            this.Controls.Add(this.apps_groupbox);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Franpette";
            this.apps_groupbox.ResumeLayout(false);
            this.apps_groupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refresh_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.GroupBox apps_groupbox;
        private System.Windows.Forms.Label state_label;
        private System.Windows.Forms.Label date_value;
        private System.Windows.Forms.Label date_label;
        private System.Windows.Forms.Label state_value;
        private System.Windows.Forms.Label user_value;
        private System.Windows.Forms.Label user_label;
        private System.Windows.Forms.Label host_label;
        private System.Windows.Forms.TextBox MOTD_textBox;
        private System.Windows.Forms.Label version_label;
        private System.Windows.Forms.Label version_value;
        private System.Windows.Forms.ProgressBar ftp_progressBar;
        private System.Windows.Forms.ProgressBar total_progressBar;
        private System.Windows.Forms.Label MOTD_label;
        private System.Windows.Forms.Button host_value;
        private System.Windows.Forms.PictureBox refresh_pictureBox;
    }
}

