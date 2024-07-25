using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnicalServiceProject.Formlar
{
    public partial class FrmYeniDepartman : Form
    {
        public FrmYeniDepartman()
        {
            InitializeComponent();
        }
        TeknikServisDBEntities db= new TeknikServisDBEntities();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtDepAd.Text.Length <= 50 && TxtDepAd.Text != "" && Txtdepack.Text.Length >= 1 && Txtdepack.Text.Length <= 100)
            {
                TBLDepartment d = new TBLDepartment();
                d.AD = TxtDepAd.Text;
                d.ACIKLAMA = Txtdepack.Text;
                db.TBLDepartment.Add(d);
                db.SaveChanges();
                MessageBox.Show("Departman başarılı bir şekilde eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kayıt Yapılamadı!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.Close();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            DialogResult vazgec = MessageBox.Show("Departman ekleme işleminden vazgeçmek istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (vazgec == System.Windows.Forms.DialogResult.Yes)

            {

                this.Close();

            }
        }
    }
}
