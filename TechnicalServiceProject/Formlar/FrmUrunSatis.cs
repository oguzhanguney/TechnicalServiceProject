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
    public partial class FrmUrunSatis : Form
    {
        public FrmUrunSatis()
        {
            InitializeComponent();
        }

        TeknikServisDBEntities db=new TeknikServisDBEntities();

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLProductMovement m = new TBLProductMovement();
            m.URUN=int.Parse(TxtUrunıd.Text);
            m.MUSTERI=int.Parse(TxtMusteri.Text);
            m.PERSONEL=short.Parse(TxtPersonel.Text);
            m.TARIH=DateTime.Parse(TxtTarih.Text);
            m.ADET=short.Parse(TxtAdet.Text);
            m.FIYAT=decimal.Parse(TxtSatis.Text);
            m.URUNSERINO=TxtSeri.Text;
            db.TBLProductMovement.Add(m);
            db.SaveChanges();
            MessageBox.Show("Ürün satışı yapıldı");
            this.Close();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            DialogResult vazgec = MessageBox.Show("Cari ekleme işleminden vazgeçmek istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (vazgec == System.Windows.Forms.DialogResult.Yes)

            {

                this.Close();

            }
        }
    }
}
