namespace WindowsFormsApplication2
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.username_textBox = new System.Windows.Forms.TextBox();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.address_textBox = new System.Windows.Forms.TextBox();
            this.login_title_label = new System.Windows.Forms.Label();
            this.login_button = new System.Windows.Forms.Button();
            this.username_pictureBox = new System.Windows.Forms.PictureBox();
            this.password_pictureBox = new System.Windows.Forms.PictureBox();
            this.address_pictureBox = new System.Windows.Forms.PictureBox();
            this.remember_checkBox = new System.Windows.Forms.CheckBox();
            this.connection = new System.ComponentModel.BackgroundWorker();
            this.error = new System.Windows.Forms.TextBox();
            this.build = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.username_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.password_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.address_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // username_textBox
            // 
            this.username_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130)))));
            this.username_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.username_textBox.Font = new System.Drawing.Font("Minecraftia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_textBox.ForeColor = System.Drawing.Color.White;
            this.username_textBox.Location = new System.Drawing.Point(70, 122);
            this.username_textBox.Name = "username_textBox";
            this.username_textBox.Size = new System.Drawing.Size(200, 28);
            this.username_textBox.TabIndex = 0;
            this.username_textBox.TabStop = false;
            // 
            // password_textBox
            // 
            this.password_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130)))));
            this.password_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password_textBox.Font = new System.Drawing.Font("Minecraftia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_textBox.ForeColor = System.Drawing.Color.White;
            this.password_textBox.Location = new System.Drawing.Point(70, 172);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(200, 28);
            this.password_textBox.TabIndex = 1;
            this.password_textBox.TabStop = false;
            this.password_textBox.UseSystemPasswordChar = true;
            // 
            // address_textBox
            // 
            this.address_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130)))));
            this.address_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.address_textBox.Font = new System.Drawing.Font("Minecraftia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address_textBox.ForeColor = System.Drawing.Color.White;
            this.address_textBox.Location = new System.Drawing.Point(70, 222);
            this.address_textBox.Name = "address_textBox";
            this.address_textBox.Size = new System.Drawing.Size(200, 28);
            this.address_textBox.TabIndex = 2;
            this.address_textBox.TabStop = false;
            // 
            // login_title_label
            // 
            this.login_title_label.AutoSize = true;
            this.login_title_label.Font = new System.Drawing.Font("Minecraftia", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_title_label.ForeColor = System.Drawing.Color.White;
            this.login_title_label.Location = new System.Drawing.Point(101, 28);
            this.login_title_label.Name = "login_title_label";
            this.login_title_label.Size = new System.Drawing.Size(114, 47);
            this.login_title_label.TabIndex = 3;
            this.login_title_label.Text = "LOGIN";
            // 
            // login_button
            // 
            this.login_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login_button.Font = new System.Drawing.Font("Minecraftia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_button.ForeColor = System.Drawing.Color.White;
            this.login_button.Location = new System.Drawing.Point(54, 313);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(200, 50);
            this.login_button.TabIndex = 4;
            this.login_button.Text = "Log in";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // username_pictureBox
            // 
            this.username_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("username_pictureBox.Image")));
            this.username_pictureBox.Location = new System.Drawing.Point(30, 118);
            this.username_pictureBox.Name = "username_pictureBox";
            this.username_pictureBox.Size = new System.Drawing.Size(32, 32);
            this.username_pictureBox.TabIndex = 5;
            this.username_pictureBox.TabStop = false;
            // 
            // password_pictureBox
            // 
            this.password_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("password_pictureBox.Image")));
            this.password_pictureBox.Location = new System.Drawing.Point(30, 168);
            this.password_pictureBox.Name = "password_pictureBox";
            this.password_pictureBox.Size = new System.Drawing.Size(32, 32);
            this.password_pictureBox.TabIndex = 6;
            this.password_pictureBox.TabStop = false;
            // 
            // address_pictureBox
            // 
            this.address_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("address_pictureBox.Image")));
            this.address_pictureBox.Location = new System.Drawing.Point(30, 218);
            this.address_pictureBox.Name = "address_pictureBox";
            this.address_pictureBox.Size = new System.Drawing.Size(32, 32);
            this.address_pictureBox.TabIndex = 7;
            this.address_pictureBox.TabStop = false;
            // 
            // remember_checkBox
            // 
            this.remember_checkBox.AutoSize = true;
            this.remember_checkBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.remember_checkBox.Font = new System.Drawing.Font("Minecraftia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remember_checkBox.ForeColor = System.Drawing.Color.White;
            this.remember_checkBox.Location = new System.Drawing.Point(102, 279);
            this.remember_checkBox.Name = "remember_checkBox";
            this.remember_checkBox.Size = new System.Drawing.Size(109, 27);
            this.remember_checkBox.TabIndex = 8;
            this.remember_checkBox.Text = "Remember";
            this.remember_checkBox.UseVisualStyleBackColor = true;
            // 
            // connection
            // 
            this.connection.DoWork += new System.ComponentModel.DoWorkEventHandler(this.connection_DoWork);
            this.connection.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.connection_RunWorkerCompleted);
            // 
            // error
            // 
            this.error.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130)))));
            this.error.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.error.Cursor = System.Windows.Forms.Cursors.Default;
            this.error.Font = new System.Drawing.Font("Minecraftia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.error.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.error.Location = new System.Drawing.Point(2, 367);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(307, 28);
            this.error.TabIndex = 9;
            this.error.Text = "Connection error message";
            this.error.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // build
            // 
            this.build.AutoSize = true;
            this.build.Font = new System.Drawing.Font("Minecraftia", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.build.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.build.Location = new System.Drawing.Point(250, 400);
            this.build.Name = "build";
            this.build.Size = new System.Drawing.Size(61, 16);
            this.build.TabIndex = 10;
            this.build.Text = "build x.x.x";
            this.build.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(311, 416);
            this.Controls.Add(this.build);
            this.Controls.Add(this.error);
            this.Controls.Add(this.remember_checkBox);
            this.Controls.Add(this.address_pictureBox);
            this.Controls.Add(this.password_pictureBox);
            this.Controls.Add(this.username_pictureBox);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.login_title_label);
            this.Controls.Add(this.address_textBox);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.username_textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Franpette";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Login_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.username_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.password_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.address_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox username_textBox;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.TextBox address_textBox;
        private System.Windows.Forms.Label login_title_label;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.PictureBox username_pictureBox;
        private System.Windows.Forms.PictureBox password_pictureBox;
        private System.Windows.Forms.PictureBox address_pictureBox;
        private System.Windows.Forms.CheckBox remember_checkBox;
        private System.ComponentModel.BackgroundWorker connection;
        private System.Windows.Forms.TextBox error;
        private System.Windows.Forms.Label build;
    }
}