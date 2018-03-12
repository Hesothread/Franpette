using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Franpette.Sources.Franpette;

namespace Franpette
{
    public partial class Login : Form
    {
        private Window _win;
        private string[] _credentials;

        public Login()
        {
            InitializeComponent();

            build.Text = FranpetteUtils.getBuildVersion();
            fillFields();

            if (FranpetteUtils.isAutoLogin() && connection.IsBusy != true)
                connection.RunWorkerAsync();
        }

        private void fillFields()
        {
            if ((_credentials = FranpetteUtils.getCredentials()) != null)
            {
                remember_checkBox.Hide();
                address_placeholder.Hide();
                address_textBox.Text = _credentials[0].Split(':')[1];
                username_placeholder.Hide();
                username_textBox.Text = _credentials[1].Split(':')[1];
                password_placeholder.Hide();
                password_textBox.Text = _credentials[2].Split(':')[1];
            }
            else
            {
                remember_checkBox.Checked = false;
                remember_checkBox.Show();
                address_placeholder.Show();
                username_placeholder.Show();
                password_placeholder.Show();
                address_textBox.Text = "";
                username_textBox.Text = "";
                password_textBox.Text = "";
            }
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            if (remember_checkBox.Checked && address_textBox.Text != null && username_textBox.Text != null && password_textBox.Text != null)
            {
                FranpetteUtils.saveCredentials(address_textBox.Text, username_textBox.Text, password_textBox.Text);
            }
            else
            {
                Directory.CreateDirectory(FranpetteUtils.getRoot());
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
            login_button.Text = "Log in";
            if ((int)e.Result == 0)
            {
                _win = new Window(address_textBox.Text, username_textBox.Text, password_textBox.Text);
                _win.FormClosed += new FormClosedEventHandler(win_FormClosed);
                _win.Show();
                this.Hide();
            }
            else
            {
                switch ((int)e.Result)
                {
                    case 1:
                        error.Text = "Invalid username/password";
                        break;
                    case 2:
                        error.Text = "The server is inaccessible";
                        break;
                    case 3:
                        error.Text = "One of the fields is not filled";
                        break;
                    default:
                        error.Text = "Error during the connection";
                        break;
                }
                error.Show();
            }
        }

        private void win_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_win.isLoggedOut())
            {
                fillFields();
                this.Show();
            }
            else
            {
                this.Close();
            }
        }

        private void Login_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.White, 1);
            int x2 = ClientRectangle.Width - 65;
            g.DrawLine(p, 97, 232, x2, 232);
            g.DrawLine(p, 97, 282, x2, 282);
            g.DrawLine(p, 97, 332, x2, 332);
            g.Dispose();
        }

        private void address_textBox_TextChanged(object sender, EventArgs e)
        {
            if (_credentials != null && _credentials[0].Split(':')[1] != address_textBox.Text)
            {
                remember_checkBox.Show();
            }
            else if (_credentials != null)
            {
                remember_checkBox.Hide();
            }
        }

        private void username_textBox_TextChanged(object sender, EventArgs e)
        {
            if (_credentials != null && _credentials[1].Split(':')[1] != username_textBox.Text)
            {
                remember_checkBox.Show();
            }
            else if (_credentials != null)
            {
                remember_checkBox.Hide();
            }
        }

        private void password_textBox_TextChanged(object sender, EventArgs e)
        {
            if (_credentials != null && _credentials[2].Split(':')[1] != password_textBox.Text)
            {
                remember_checkBox.Show();
            }
            else if (_credentials != null)
            {
                remember_checkBox.Hide();
            }
        }

        private void username_placeholder_Enter(object sender, EventArgs e)
        {
            if (password_textBox.Text == "") password_placeholder.Show();
            if (address_textBox.Text == "") address_placeholder.Show();
            username_placeholder.Hide();
            username_textBox.Focus();
        }

        private void password_placeholder_Enter(object sender, EventArgs e)
        {
            if (username_textBox.Text == "") username_placeholder.Show();
            if (address_textBox.Text == "") address_placeholder.Show();
            password_placeholder.Hide();
            password_textBox.Focus();
        }

        private void address_placeholder_Enter(object sender, EventArgs e)
        {
            if (username_textBox.Text == "") username_placeholder.Show();
            if (password_textBox.Text == "") password_placeholder.Show();
            address_placeholder.Hide();
            address_textBox.Focus();
        }

        private void username_textBox_Enter(object sender, EventArgs e)
        {
            if (password_textBox.Text == "") password_placeholder.Show();
            if (address_textBox.Text == "") address_placeholder.Show();
        }

        private void password_textBox_Enter(object sender, EventArgs e)
        {
            if (username_textBox.Text == "") username_placeholder.Show();
            if (address_textBox.Text == "") address_placeholder.Show();
        }

        private void address_textBox_Enter(object sender, EventArgs e)
        {
            if (username_textBox.Text == "") username_placeholder.Show();
            if (password_textBox.Text == "") password_placeholder.Show();
        }
    }
}
