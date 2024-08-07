using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnicalServiceProject.Formlar
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }

        private void btnGönder_Click(object sender, EventArgs e)
        {
            MailMessage mail= new MailMessage();
            string frommail = "travelerrezervasyon@gmail.com";
            string password = "klgotwzwpqdnrhzp";
            string alici = txtalici.Text;
            string konu=txtkonu.Text;
            string icerik=txticerik.Text;
            mail.From=(new MailAddress(frommail));
            mail.To.Add(alici);
            mail.Subject = konu;
            mail.Body = icerik;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com",587);
            smtp.Credentials=new NetworkCredential(frommail,password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
            MessageBox.Show("Mail Gönderildi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
