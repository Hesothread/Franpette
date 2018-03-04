using System;
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
            login_button.Text = "Logging in...";
            if (remember_checkBox.Checked && address_textBox.Text != null && username_textBox.Text != null && password_textBox.Text != null)
            {
                FranpetteUtils.saveCredentials(address_textBox.Text, username_textBox.Text, password_textBox.Text);
            }

            if (FranpetteUtils.isValidConnection(address_textBox.Text, username_textBox.Text, password_textBox.Text))
            {
                Window win = new Window(address_textBox.Text, username_textBox.Text, password_textBox.Text);
                win.FormClosed += new FormClosedEventHandler(win_FormClosed);
                win.Show();
                this.Hide();
            }
            else
            {
                login_button.Text = "Log in";
            }
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

        private void win_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
