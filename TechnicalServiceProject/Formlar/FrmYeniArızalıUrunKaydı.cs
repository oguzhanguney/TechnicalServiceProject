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
    public partial class FrmYeniArızalıUrunKaydı : Form
    {
        public FrmYeniArızalıUrunKaydı()
        {
            InitializeComponent();
        }
        TeknikServisDBEntities db = new TeknikServisDBEntities();
        private void btnMusteri_Click(object sender, EventArgs e)
        {
            var verigetir = db.TBLProductMovement.SingleOrDefault(x => x.URUNSERINO == TxtSeri.Text);
            if (verigetir != null)
            {
                
                lookupcustom.EditValue = verigetir.TBLCari.ID.ToString();
                lookUpEdit1.EditValue = verigetir.TBLPersonnel.ID.ToString();

            }
            else
            {
                MessageBox.Show("Seri numarasına ait satış bulunamadı", "Bilgi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            //Müşteri
            lookupcustom.Properties.DataSource = (from x in db.TBLCari
                                                  select new
                                                  {
                                                      x.ID,
                                                      x.AD
                                                  }).ToList();

            TBLProductAcceptance a = new TBLProductAcceptance();
            a.PERSONEL=short.Parse(lookUpEdit1.EditValue.ToString());
            a.CARI=int.Parse(lookupcustom.EditValue.ToString());    
            a.GELISTARIHI = DateTime.Parse(TxtTarih.Text);
            a.URUNSERINO = TxtSeri.Text;
            a.DURUM = "Ürün Alındı";
            var komut= db.TBLProductMovement.FirstOrDefault(y => y.URUNSERINO == TxtSeri.Text);
            if (komut!=null)
            {
                db.TBLProductAcceptance.Add(a);
                db.SaveChanges();
                MessageBox.Show("Arıza kaydı başarıyla gerçekleşti.");
            }
            else
            {
                MessageBox.Show("Bu seri numarasına ait satış bilgisi bulunmamaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            this.Close();

        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            DialogResult vazgec = MessageBox.Show("Arıza Kaydı işleminden vazgeçmek istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (vazgec == System.Windows.Forms.DialogResult.Yes)

            {

                this.Close();

            }
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmYeniArızalıUrunKaydı_Load(object sender, EventArgs e)
        {
            //Müşteri
            lookupcustom.Properties.DataSource = (from x in db.TBLCari
                                                  select new
                                                  {
                                                      x.ID,
                                                      Musteri = x.AD + " " + x.SOYAD
                                                  }).ToList();
            lookUpEdit1.Properties.DataSource = (from x in db.TBLPersonnel
                                                 select new
                                                 {
                                                     x.ID,
                                                     Personel = x.AD + " " + x.SOYAD
                                                 }).ToList();
        }

        private void TxtTarih_Click(object sender, EventArgs e)
        {
            TxtTarih.Text = DateTime.Now.ToShortDateString();
        }
    }
}
