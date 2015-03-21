using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Web;

namespace GUI_Task
{
    public partial class frmEmail : Form
    {
        string extracted = "";

        public frmEmail()
        {
            InitializeComponent();
        }

        private void send_Click(object sender, EventArgs e)
        {   
            // *******   To Add Another Email Except GMail *****//
            
            //MailAddress address = new MailAddress(); 

            // ************************************************//

            //extracted = MemberShip.GetUser();
            //smtp.Text = "smtp.gmail.com";
            
            MailMessage mail = new MailMessage("usama.naveed.hussain@gmail.com", "naveed_hussain02@live.com", subject.Text, body.Text);
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            // client.Host = "stmp.gmail.com";
            client.Port = 587;
            // client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("usama.naveed.hussain@gmail.com", "waleedtablet");
            client.EnableSsl = true;
            client.Send(mail);
            MessageBox.Show("Mail Sent", "Success", MessageBoxButtons.OK);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void frmEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
