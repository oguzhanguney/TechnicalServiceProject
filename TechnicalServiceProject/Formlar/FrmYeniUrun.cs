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
    public partial class FrmYeniUrun : Form
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }

        private void FrmYeniUrun_Load(object sender, EventArgs e)
        {

        }

        

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            DialogResult vazgec = MessageBox.Show("Ürün ekleme işleminden vazgeçmek istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (vazgec == System.Windows.Forms.DialogResult.Yes)

            {

                this.Close();

            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TeknikServisDBEntities db=new TeknikServisDBEntities();
            TBLProduct p =new TBLProduct();
            p.AD = TxtUrunAd.Text;
            p.ALISFIYAT=decimal.Parse(TxtAlisFiyat.Text);
            p.SATISFIYAT = decimal.Parse(TxtSatisFiyat.Text);
            p.MARKA=TxtMarka.Text;
            p.STOK = short.Parse(TxtStok.Text);
            p.KATEGORI=byte.Parse(TxtKategori.Text);
            db.TBLProduct.Add(p);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla eklendi.");
            this.Close();
        }
    }
}
