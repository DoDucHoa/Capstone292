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
using CapstonePRN292._2._Business_Layer;
using System.Net;
using System.Net.Mail;

namespace CapstonePRN292._1._Form_Layer
{
    public partial class Confirm : DevExpress.XtraEditors.XtraForm
    {
        string username;
        string reEnter;
        string fullName;
        string email;
        string activationCode = RandomString();
        public Confirm()
        {
            InitializeComponent();
        }

        public Confirm(string username, string reEnter, string fullName, string email) : this()
        {
            this.username = username;
            this.reEnter = reEnter;
            this.fullName = fullName;
            this.email = email;
            sendEmail(email);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtConfirm.Text.Equals(activationCode)) {

                RegisterDAO registerDAO = new RegisterDAO();
                registerDAO.loadToDatabase(username, reEnter, fullName, email);

                MessageBox.Show("Create success.", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect code! Please check your mail again.", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
        private void sendEmail(string email)
        {
            try
            {

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("doduchoa02@gmail.com");
                msg.To.Add(email);
                msg.Subject = ("Activation Mail");
                msg.Body = ("Thank you for using our product. Here is your activation code: " + activationCode);

                SmtpClient smt = new SmtpClient();
                smt.Host = "smtp.gmail.com";
                System.Net.NetworkCredential ntcd = new NetworkCredential();
                ntcd.UserName = "doduchoa02@gmail.com";
                ntcd.Password = "hoa1562000";
                smt.Credentials = ntcd;
                smt.EnableSsl = true;
                smt.Port = 587;
                smt.Send(msg);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private static string RandomString()
        {
            const string src = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int length = 20;
            var sb = new StringBuilder();
            Random RNG = new Random();
            for (var i = 0; i < length; i++)
            {
                var c = src[RNG.Next(0, src.Length)];
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}