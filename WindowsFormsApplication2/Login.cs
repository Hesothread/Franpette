using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApplication2.Sources.Franpette;

namespace WindowsFormsApplication2
{
    public partial class Login : Form
    {
        private string[] _credentials;

        public Login()
        {
            InitializeComponent();

            error.Hide();
            if ((_credentials = FranpetteUtils.getCredentials()) != null)
            {
                remember_checkBox.Hide();
                address_textBox.Text = _credentials[0];
                username_textBox.Text = _credentials[1];
                password_textBox.Text = _credentials[2];
            }
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            if (remember_checkBox.Checked && address_textBox.Text != null && username_textBox.Text != null && password_textBox.Text != null)
            {
                FranpetteUtils.saveCredentials(address_textBox.Text, username_textBox.Text, password_textBox.Text);
            }

            if (connection.IsBusy != true)
            {
                login_button.Text = "Logging in...";
                error.Hide();
                connection.RunWorkerAsync();
            }
        }

        private void connection_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            e.Result = FranpetteUtils.isValidConnection(address_textBox.Text, username_textBox.Text, password_textBox.Text);
        }

        private void connection_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((int)e.Result == 0)
            {
                Window win = new Window(address_textBox.Text, username_textBox.Text, password_textBox.Text);
                win.FormClosed += new FormClosedEventHandler(win_FormClosed);
                win.Show();
                this.Hide();
            }
            else
            {
                login_button.Text = "Log in";
                switch ((int)e.Result)
                {
                    case 1:
                        error.Text = "Invalid username/password";
                        break;
                    default:
                        error.Text = "The server is inaccessible";
                        break;
                }
                error.Show();
            }
        }

        private void win_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void Login_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.White, 1);
            g.DrawLine(p, 70, 150, 270, 150);
            g.DrawLine(p, 70, 200, 270, 200);
            g.DrawLine(p, 70, 250, 270, 250);
            g.Dispose();
        }
    }
}
