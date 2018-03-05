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
            this.minecraft_button = new System.Windows.Forms.Button();
            this.apps_groupbox = new System.Windows.Forms.GroupBox();
            this.host_button = new System.Windows.Forms.Button();
            this.host_label = new System.Windows.Forms.Label();
            this.user_value = new System.Windows.Forms.Label();
            this.user_label = new System.Windows.Forms.Label();
            this.date_value = new System.Windows.Forms.Label();
            this.date_label = new System.Windows.Forms.Label();
            this.state_value = new System.Windows.Forms.Label();
            this.state_label = new System.Windows.Forms.Label();
            this.version_label = new System.Windows.Forms.Label();
            this.ftp_progressBar = new System.Windows.Forms.ProgressBar();
            this.refresh_button = new System.Windows.Forms.Button();
            this.MOTD_textBox = new System.Windows.Forms.TextBox();
            this.MOTD_label = new System.Windows.Forms.Label();
            this.refresh_info = new System.ComponentModel.BackgroundWorker();
            this.minecraft_toogle = new System.ComponentModel.BackgroundWorker();
            this.progress_label = new System.Windows.Forms.Label();
            this.apps_groupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // minecraft_button
            // 
            this.minecraft_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minecraft_button.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minecraft_button.ForeColor = System.Drawing.Color.White;
            this.minecraft_button.Location = new System.Drawing.Point(6, 19);
            this.minecraft_button.Name = "minecraft_button";
            this.minecraft_button.Size = new System.Drawing.Size(123, 23);
            this.minecraft_button.TabIndex = 0;
            this.minecraft_button.Text = "Minecraft";
            this.minecraft_button.UseVisualStyleBackColor = true;
            this.minecraft_button.Click += new System.EventHandler(this.minecraft_button_Click);
            // 
            // apps_groupbox
            // 
            this.apps_groupbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.apps_groupbox.Controls.Add(this.host_button);
            this.apps_groupbox.Controls.Add(this.host_label);
            this.apps_groupbox.Controls.Add(this.user_value);
            this.apps_groupbox.Controls.Add(this.user_label);
            this.apps_groupbox.Controls.Add(this.date_value);
            this.apps_groupbox.Controls.Add(this.date_label);
            this.apps_groupbox.Controls.Add(this.state_value);
            this.apps_groupbox.Controls.Add(this.state_label);
            this.apps_groupbox.Controls.Add(this.minecraft_button);
            this.apps_groupbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.apps_groupbox.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apps_groupbox.ForeColor = System.Drawing.Color.White;
            this.apps_groupbox.Location = new System.Drawing.Point(9, 207);
            this.apps_groupbox.Name = "apps_groupbox";
            this.apps_groupbox.Size = new System.Drawing.Size(696, 165);
            this.apps_groupbox.TabIndex = 3;
            this.apps_groupbox.TabStop = false;
            this.apps_groupbox.Text = "Applications";
            // 
            // host_button
            // 
            this.host_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130)))));
            this.host_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.host_button.Location = new System.Drawing.Point(577, 19);
            this.host_button.Name = "host_button";
            this.host_button.Size = new System.Drawing.Size(107, 23);
            this.host_button.TabIndex = 10;
            this.host_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.host_button.UseVisualStyleBackColor = false;
            this.host_button.Click += new System.EventHandler(this.host_button_Click);
            // 
            // host_label
            // 
            this.host_label.AutoSize = true;
            this.host_label.Location = new System.Drawing.Point(525, 24);
            this.host_label.Name = "host_label";
            this.host_label.Size = new System.Drawing.Size(55, 16);
            this.host_label.TabIndex = 9;
            this.host_label.Text = "host ip :";
            // 
            // user_value
            // 
            this.user_value.AutoSize = true;
            this.user_value.ForeColor = System.Drawing.Color.White;
            this.user_value.Location = new System.Drawing.Point(449, 24);
            this.user_value.Name = "user_value";
            this.user_value.Size = new System.Drawing.Size(65, 16);
            this.user_value.TabIndex = 8;
            this.user_value.Text = "username";
            // 
            // user_label
            // 
            this.user_label.AutoSize = true;
            this.user_label.ForeColor = System.Drawing.Color.White;
            this.user_label.Location = new System.Drawing.Point(411, 24);
            this.user_label.Name = "user_label";
            this.user_label.Size = new System.Drawing.Size(41, 16);
            this.user_label.TabIndex = 7;
            this.user_label.Text = "user :";
            // 
            // date_value
            // 
            this.date_value.AutoSize = true;
            this.date_value.ForeColor = System.Drawing.Color.White;
            this.date_value.Location = new System.Drawing.Point(258, 24);
            this.date_value.Name = "date_value";
            this.date_value.Size = new System.Drawing.Size(144, 16);
            this.date_value.TabIndex = 6;
            this.date_value.Text = "01/01/2018 01:23:45";
            // 
            // date_label
            // 
            this.date_label.AutoSize = true;
            this.date_label.ForeColor = System.Drawing.Color.White;
            this.date_label.Location = new System.Drawing.Point(222, 24);
            this.date_label.Name = "date_label";
            this.date_label.Size = new System.Drawing.Size(42, 16);
            this.date_label.TabIndex = 5;
            this.date_label.Text = "date :";
            // 
            // state_value
            // 
            this.state_value.AutoSize = true;
            this.state_value.ForeColor = System.Drawing.Color.White;
            this.state_value.Location = new System.Drawing.Point(180, 24);
            this.state_value.Name = "state_value";
            this.state_value.Size = new System.Drawing.Size(36, 16);
            this.state_value.TabIndex = 4;
            this.state_value.Text = "State";
            // 
            // state_label
            // 
            this.state_label.AutoSize = true;
            this.state_label.Location = new System.Drawing.Point(139, 24);
            this.state_label.Name = "state_label";
            this.state_label.Size = new System.Drawing.Size(44, 16);
            this.state_label.TabIndex = 3;
            this.state_label.Text = "state :";
            // 
            // version_label
            // 
            this.version_label.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.version_label.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.version_label.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.version_label.Location = new System.Drawing.Point(0, 375);
            this.version_label.Name = "version_label";
            this.version_label.Size = new System.Drawing.Size(714, 16);
            this.version_label.TabIndex = 8;
            this.version_label.Text = "version xx";
            this.version_label.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // ftp_progressBar
            // 
            this.ftp_progressBar.AccessibleName = "";
            this.ftp_progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ftp_progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130)))));
            this.ftp_progressBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.ftp_progressBar.ForeColor = System.Drawing.Color.White;
            this.ftp_progressBar.Location = new System.Drawing.Point(9, 166);
            this.ftp_progressBar.Name = "ftp_progressBar";
            this.ftp_progressBar.Size = new System.Drawing.Size(696, 31);
            this.ftp_progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ftp_progressBar.TabIndex = 9;
            this.ftp_progressBar.Tag = "";
            // 
            // refresh_button
            // 
            this.refresh_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refresh_button.AutoSize = true;
            this.refresh_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refresh_button.ForeColor = System.Drawing.Color.White;
            this.refresh_button.Image = ((System.Drawing.Image)(resources.GetObject("refresh_button.Image")));
            this.refresh_button.Location = new System.Drawing.Point(677, 9);
            this.refresh_button.Margin = new System.Windows.Forms.Padding(0);
            this.refresh_button.Name = "refresh_button";
            this.refresh_button.Padding = new System.Windows.Forms.Padding(2);
            this.refresh_button.Size = new System.Drawing.Size(28, 28);
            this.refresh_button.TabIndex = 21;
            this.refresh_button.UseVisualStyleBackColor = true;
            this.refresh_button.Click += new System.EventHandler(this.refresh_button_Click);
            // 
            // MOTD_textBox
            // 
            this.MOTD_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MOTD_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130)))));
            this.MOTD_textBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MOTD_textBox.ForeColor = System.Drawing.Color.White;
            this.MOTD_textBox.Location = new System.Drawing.Point(9, 9);
            this.MOTD_textBox.Margin = new System.Windows.Forms.Padding(0);
            this.MOTD_textBox.Multiline = true;
            this.MOTD_textBox.Name = "MOTD_textBox";
            this.MOTD_textBox.Size = new System.Drawing.Size(696, 115);
            this.MOTD_textBox.TabIndex = 22;
            this.MOTD_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MOTD_label
            // 
            this.MOTD_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MOTD_label.AutoSize = true;
            this.MOTD_label.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MOTD_label.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.MOTD_label.Location = new System.Drawing.Point(581, 124);
            this.MOTD_label.Name = "MOTD_label";
            this.MOTD_label.Size = new System.Drawing.Size(121, 16);
            this.MOTD_label.TabIndex = 23;
            this.MOTD_label.Text = "message of the day";
            this.MOTD_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // refresh_info
            // 
            this.refresh_info.WorkerReportsProgress = true;
            this.refresh_info.DoWork += new System.ComponentModel.DoWorkEventHandler(this.refresh_info_DoWork);
            this.refresh_info.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.refresh_info_ProgressChanged);
            this.refresh_info.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.refresh_info_RunWorkerCompleted);
            // 
            // minecraft_toogle
            // 
            this.minecraft_toogle.WorkerReportsProgress = true;
            this.minecraft_toogle.DoWork += new System.ComponentModel.DoWorkEventHandler(this.minecraft_toogle_DoWork);
            this.minecraft_toogle.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.minecraft_toogle_ProgressChanged);
            this.minecraft_toogle.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.minecraft_toogle_RunWorkerCompleted);
            // 
            // progress_label
            // 
            this.progress_label.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progress_label.Location = new System.Drawing.Point(12, 148);
            this.progress_label.Name = "progress_label";
            this.progress_label.Size = new System.Drawing.Size(690, 16);
            this.progress_label.TabIndex = 24;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(714, 391);
            this.Controls.Add(this.progress_label);
            this.Controls.Add(this.refresh_button);
            this.Controls.Add(this.MOTD_label);
            this.Controls.Add(this.MOTD_textBox);
            this.Controls.Add(this.ftp_progressBar);
            this.Controls.Add(this.version_label);
            this.Controls.Add(this.apps_groupbox);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(730, 430);
            this.Name = "Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Franpette - host your friends";
            this.apps_groupbox.ResumeLayout(false);
            this.apps_groupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button minecraft_button;
        private System.Windows.Forms.GroupBox apps_groupbox;
        private System.Windows.Forms.Label state_label;
        private System.Windows.Forms.Label date_value;
        private System.Windows.Forms.Label date_label;
        private System.Windows.Forms.Label state_value;
        private System.Windows.Forms.Label user_value;
        private System.Windows.Forms.Label user_label;
        private System.Windows.Forms.Label host_label;
        private System.Windows.Forms.Label version_label;
        private System.Windows.Forms.ProgressBar ftp_progressBar;
        private System.Windows.Forms.Button host_button;
        private System.Windows.Forms.Button refresh_button;
        private System.Windows.Forms.TextBox MOTD_textBox;
        private System.Windows.Forms.Label MOTD_label;
        private System.ComponentModel.BackgroundWorker refresh_info;
        private System.ComponentModel.BackgroundWorker minecraft_toogle;
        private System.Windows.Forms.Label progress_label;
    }
}

