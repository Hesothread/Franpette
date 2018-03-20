using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using Franpette.Sources.Franpette;
using Franpette.Sources.Network;

namespace Franpette
{
    public partial class Login : Form
    {
        private Window          _win;
        private ClientFTP       _ftp;
        private string[]        _credentials;

        public Login()
        {
            InitializeComponent();

            _ftp = new ClientFTP();

            // Resources
            remember_checkBox.Text =    Utils.getString("remember_checkBox");
            address_placeholder.Text =  Utils.getString("address_placeholder");
            username_placeholder.Text = Utils.getString("username_placeholder");
            password_placeholder.Text = Utils.getString("password_placeholder");
            login_button.Text =         Utils.getString("login_button");
            build.Text =                Utils.getBuildVersion();

            fillFields();

            if (Utils.isAutoLogin() && !connection.IsBusy) connection.RunWorkerAsync();
        }

        private void fillFields()
        {
            _credentials = (File.Exists(Utils.getRoot("credentials.txt"))) ? File.ReadAllLines(Utils.getRoot("credentials.txt")) : null;

            if (_credentials != null)
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
            logIn();
        }

        private void logIn()
        {
            Directory.CreateDirectory(Utils.getRoot());
            if (remember_checkBox.Checked && address_textBox.Text != null && username_textBox.Text != null && password_textBox.Text != null)
            {
                File.WriteAllLines(Utils.getRoot("credentials.txt"), new string[] {
                    "host:" + address_textBox.Text,
                    "login:" + username_textBox.Text,
                    "passwd:" + password_textBox.Text
                });
            }

            if (connection.IsBusy != true)
            {
                login_button.Text = Utils.getString("logging_in");
                error.Hide();
                connection.RunWorkerAsync();
            }
        }

        private void connection_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            e.Result = _ftp.verifyConnection(address_textBox.Text, username_textBox.Text, password_textBox.Text);
        }

        private void connection_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            login_button.Text = Utils.getString("login_button");
            if ((int)e.Result == 0)
            {
                _win = new Window(address_textBox.Text, username_textBox.Text, password_textBox.Text);
                _win.FormClosed += new FormClosedEventHandler(win_FormClosed);
                Hide();
            }
            else
            {
                switch ((int)e.Result)
                {
                    case 1:
                        error.Text = Utils.getString("error_1");
                        break;
                    case 2:
                        error.Text = Utils.getString("error_2");
                        break;
                    case 3:
                        error.Text = Utils.getString("error_3");
                        break;
                    default:
                        error.Text = Utils.getString("error_default");
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
                Show();
            }
            else
            {
                Close();
            }
        }

        //  DESIGN & ERGONOMY
        // -------------------
        // | | | | | | | | | |
        // V V V V V V V V V V
        // -------------------

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter) logIn();
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

        private void login_button_MouseEnter(object sender, EventArgs e)
        {
            login_button.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#42dca3");
            login_button.BackColor = ColorTranslator.FromHtml("#42dca3");
            login_button.ForeColor = Color.Black;
        }

        private void login_button_MouseHover(object sender, EventArgs e)
        {
            login_button.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#42dca3");
            login_button.BackColor = ColorTranslator.FromHtml("#42dca3");
            login_button.ForeColor = Color.Black;
        }

        private void login_button_MouseLeave(object sender, EventArgs e)
        {
            login_button.BackColor = Color.Transparent;
            login_button.ForeColor = ColorTranslator.FromHtml("#42dca3");
        }
    }
}
