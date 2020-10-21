using CapstonePRN292._2._Business_Layer;
using CapstonePRN292.DBHelper;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapstonePRN292._1._Form_Layer
{
    public partial class RegisterX : DevExpress.XtraEditors.XtraForm
    {
        public RegisterX()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string reEnter = txtReEnter.Text;
            string fullName = txtFullname.Text;
            string email = txtEmail.Text;
            bool isCheck = chkAgree.Checked;
            
            if (checkValid(username, password, reEnter, fullName, email, isCheck))
            {
                RegisterDAO registerDAO = new RegisterDAO();
                registerDAO.loadToDatabase(username, reEnter, fullName, email);

                MessageBox.Show("Create success.", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private bool checkValid(string username, string password, string reEnter, string fullName, string email, bool isCheck)
        {
            Regex regexEmail = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
            bool result = regexEmail.IsMatch(email); //check valid email
            DBConnection dBConnection = new DBConnection();
            bool checkExist = dBConnection.checkExistUsername(username);

            if (username.Equals(""))
            {
                MessageBox.Show("User name is empty!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }
            if (checkExist)
            {
                MessageBox.Show("User name is existed!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Clear();
                txtUsername.Focus();
                return false;
            }
            if (fullName.Equals(""))
            {
                MessageBox.Show("Full Name is empty!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullname.Focus();
                return false;
            }
            if (password.Equals(""))
            {
                MessageBox.Show("Password is empty!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }
            if (reEnter.Equals(""))
            {
                MessageBox.Show("Re-Enter password is empty!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReEnter.Focus();
                return false;
            }
            if (!password.Equals(reEnter))
            {
                MessageBox.Show("Re-enter password does not match!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReEnter.Focus();
                return false;
            }
            if (email.Equals(""))
            {
                MessageBox.Show("Email is empty!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            if (!result)
            {
                MessageBox.Show("Email format: xxx@xxx.xxx", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            if (!isCheck)
            {
                MessageBox.Show("Please confirm term and service!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            return true;
        }
    }
}