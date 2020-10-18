using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CapstonePRN292.DBHelper;

namespace CapstonePRN292
{
    public partial class LoginX : DevExpress.XtraEditors.XtraForm
    {
        public LoginX()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string us = txtUsername.Text;
            string pw = txtPassword.Text;
            DBConnection connection = new DBConnection();
            if (!us.Equals(""))
            {
                if (!pw.Equals(""))
                {
                    if (connection.checkLogin(us, pw))
                    {
                        DepotX fr = new DepotX();
                        this.Hide();
                        fr.ShowDialog();
                        this.Show();
                        txtUsername.Clear();
                        txtPassword.Clear();
                        txtUsername.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Wrong username or password!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUsername.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Password is empty!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                }
            }
            else
            {
                MessageBox.Show("Username is empty!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {

        }

        private void LoginX_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit ?", "Notify", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}