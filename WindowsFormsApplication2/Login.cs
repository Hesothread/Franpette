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
                address_placeholder.Hide();
                address_textBox.Text = _credentials[0];
                username_placeholder.Hide();
                username_textBox.Text = _credentials[1];
                password_placeholder.Hide();
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
            this.Close();
        }

        private void Login_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.White, 1);
            int x2 = ClientRectangle.Width - 65;
            g.DrawLine(p, 97, 150, x2, 150);
            g.DrawLine(p, 97, 200, x2, 200);
            g.DrawLine(p, 97, 250, x2, 250);
            g.Dispose();
        }

        private void address_textBox_TextChanged(object sender, EventArgs e)
        {
            if (_credentials != null && _credentials[0] != address_textBox.Text)
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
            if (_credentials != null && _credentials[1] != username_textBox.Text)
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
            if (_credentials != null && _credentials[2] != password_textBox.Text)
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
