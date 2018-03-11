namespace Updater
{
    partial class Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.update_progressBar = new System.Windows.Forms.ProgressBar();
            this.update_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // update_progressBar
            // 
            this.update_progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.update_progressBar.Location = new System.Drawing.Point(12, 39);
            this.update_progressBar.Name = "update_progressBar";
            this.update_progressBar.Size = new System.Drawing.Size(481, 43);
            this.update_progressBar.TabIndex = 0;
            // 
            // update_label
            // 
            this.update_label.AutoSize = true;
            this.update_label.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update_label.Location = new System.Drawing.Point(12, 20);
            this.update_label.Name = "update_label";
            this.update_label.Size = new System.Drawing.Size(143, 16);
            this.update_label.TabIndex = 1;
            this.update_label.Text = "Franpette is updating...";
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(505, 94);
            this.Controls.Add(this.update_label);
            this.Controls.Add(this.update_progressBar);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Updater";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar update_progressBar;
        private System.Windows.Forms.Label update_label;
    }
}

