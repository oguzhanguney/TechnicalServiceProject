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
    public partial class FrmYeniKategori : Form
    {
        public FrmYeniKategori()
        {
            InitializeComponent();
        }
        TeknikServisDBEntities db=new TeknikServisDBEntities();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLCategory t = new TBLCategory();
            t.AD = TxtKategori.Text;
            db.TBLCategory.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori başarıyla eklendi.");
            this.Close();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            DialogResult vazgec = MessageBox.Show("Kategori ekleme işleminden vazgeçmek istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (vazgec == System.Windows.Forms.DialogResult.Yes)

            {

                this.Close();

            }
        }
    }
}
