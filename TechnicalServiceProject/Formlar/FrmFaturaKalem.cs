using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnicalServiceProject.Formlar
{
    public partial class FrmFaturaKalem : Form
    {
        public FrmFaturaKalem()
        {
            InitializeComponent();
        }

        private void listele()
        {
            var degerler = from d in db.TBLBillingDetail
                           select new
                           {
                               d.FATURADETAYID,
                               d.URUN,
                               d.ADET,
                               d.FIYAT,
                               d.TUTAR,
                               d.FATURAID
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        TeknikServisDBEntities db = new TeknikServisDBEntities();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLBillingDetail b = new TBLBillingDetail();
            b.URUN = lookupurun.Text;
            b.ADET = short.Parse(txtadet.Text);
            b.FIYAT = decimal.Parse(txtfiyat.Text);
            b.TUTAR = decimal.Parse(txttutar.Text);
            if (!int.TryParse(txtfaturaıd.Text, out int faturaId))
            {
                // Uyarı mesajı göster
                MessageBox.Show("Lütfen geçerli bir Fatura ID girin.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Kaydetme işlemini sonlandır
            }
            b.FATURAID = faturaId;
            db.TBLBillingDetail.Add(b);
            db.SaveChanges();
            MessageBox.Show("Faturaya ait kalem girişi başarıyla yapıldı.");
            listele();
        }

        private void FrmFaturaKalem_Load(object sender, EventArgs e)
        {
            listele();

            lookupurun.Properties.DataSource = db.TBLProduct.Select(x => new { x.ID, x.AD, x.MARKA }).ToList();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLBillingDetail.Find(id);
            db.TBLBillingDetail.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Fatura Kalemi başarılı bir şekilde silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLBillingDetail.Find(id);
            deger.URUN = lookupurun.Text;
            deger.ADET = short.Parse(txtadet.Text);
            deger.FIYAT = decimal.Parse(txtfiyat.Text);
            deger.TUTAR = decimal.Parse(txttutar.Text);
            deger.FATURAID = int.Parse(txtfaturaıd.Text);
            db.SaveChanges();
            MessageBox.Show("Fatura Kalemi başarılı bir Şekilde güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TxtID.Text = "";
            lookupurun.EditValue = null;
            txtadet.Text = "";
            txtfiyat.Text = "";
            txttutar.Text = "";
            txtfaturaıd.Text = "";
        }

        private void lookupurun_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupurun.EditValue != null)
            {
                var selectedId = (int)lookupurun.EditValue;

                var selectproduct = db.TBLProduct.FirstOrDefault(x => x.ID == selectedId);
                if (selectproduct != null)
                {
                    // Fiyatı otomatik olarak getir
                    txtfiyat.Text = selectproduct.SATISFIYAT.ToString();
                    CalculateTotal();
                }
            }

        }
        public void CalculateTotal()
        {
            // Adet ve fiyatın geçerli olup olmadığını kontrol et
            if (decimal.TryParse(txtfiyat.Text, out decimal price) && short.TryParse(txtadet.Text, out short quantity))
            {
                decimal total = price * quantity;
                txttutar.Text = total.ToString();
            }

            
        }

        private void txtadet_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("FATURADETAYID").ToString();
            lookupurun.Text = gridView1.GetFocusedRowCellValue("URUN").ToString();
            txtadet.Text = gridView1.GetFocusedRowCellValue("ADET").ToString();
            txtfiyat.Text = gridView1.GetFocusedRowCellValue("FIYAT").ToString();
            txttutar.Text = gridView1.GetFocusedRowCellValue("TUTAR").ToString();
            txtfaturaıd.Text = gridView1.GetFocusedRowCellValue("FATURAID").ToString();
        }
    }
}
