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
using System.Text.RegularExpressions;
using CapstonePRN292._2._Business_Layer;

namespace CapstonePRN292._1._Form_Layer
{
    public partial class AddCustomer : DevExpress.XtraEditors.XtraForm
    {
        public AddCustomer()
        {
            InitializeComponent();
            pickDate.Format = DateTimePickerFormat.Custom;
            pickDate.CustomFormat = "MM-dd-yyyy";
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string fullname = txtFullname.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;
            string birth = pickDate.Text;

            if (checkValid(fullname, email, address)) {
                DepotDAO dao = new DepotDAO();
                dao.loadUserToDatabase(fullname, email, address, birth);

                MessageBox.Show("Create success.", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
        }

        private bool checkValid(string fullName, string email, string address)
        {
            Regex regexEmail = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
            bool result = regexEmail.IsMatch(email); //check valid email    

            if (fullName.Equals(""))
            {
                MessageBox.Show("Full Name is empty!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullname.Focus();
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

            return true;
        }
    }
}