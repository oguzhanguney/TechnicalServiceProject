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

        TeknikServisDBEntities db = new TeknikServisDBEntities();

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLProductMovement m = new TBLProductMovement();
            m.URUN = int.Parse(lookUpEdit1.EditValue.ToString());
            m.MUSTERI = int.Parse(lookUpEdit2.EditValue.ToString());
            m.PERSONEL = short.Parse(lookUpEdit3.EditValue.ToString());
            m.TARIH = DateTime.Parse(TxtTarih.Text);
            m.ADET = short.Parse(TxtAdet.Text);
            m.FIYAT = decimal.Parse(TxtSatis.Text);
            m.URUNSERINO = TxtSeri.Text;
            db.TBLProductMovement.Add(m);

            int urunid = int.Parse(lookUpEdit1.EditValue.ToString());
            var urun = db.TBLProduct.Find(urunid);
            if (urun != null)
            {
                urun.STOK -= short.Parse(TxtAdet.Text);
                if (urun.STOK < 0)
                {
                    MessageBox.Show("Ürün stoğu yetersiz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.SaveChanges();
                MessageBox.Show("Ürün satışı yapıldı");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ürün bulunamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            DialogResult vazgec = MessageBox.Show("Ürün satışı işleminden vazgeçmek istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (vazgec == System.Windows.Forms.DialogResult.Yes)

            {

                this.Close();

            }
        }

        private void pictureEdit9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmUrunSatis_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = (from x in db.TBLProduct
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD,
                                                     x.MARKA
                                                 }).ToList();
            lookUpEdit2.Properties.DataSource = (from x in db.TBLCari
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD=x.AD+" "+x.SOYAD
                                                 }).ToList();
            lookUpEdit3.Properties.DataSource = (from x in db.TBLPersonnel
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD = x.AD + " " + x.SOYAD
                                                 }).ToList();
        }
    }
}
