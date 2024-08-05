using DevExpress.XtraEditors;
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
    public partial class FrmFaturaListesi : Form
    {
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }

        private void listele()
        {
            var degerler = from b in db.TBLBillingInfo
                           select new
                           {
                               b.ID,
                               b.SERI,
                               b.SIRANO,
                               b.TARIH,
                               b.SAAT,
                               b.VERGIDAIRE,
                               CARI = b.TBLCari.AD + " " + b.TBLCari.SOYAD,
                               PERSONEL = b.TBLPersonnel.AD + " " + b.TBLPersonnel.SOYAD

                           };
            gridControl1.DataSource = degerler.ToList();
        }
        TeknikServisDBEntities db = new TeknikServisDBEntities();
        private void FrmFaturaListesi_Load(object sender, EventArgs e)
        {
            listele();

            txtcari.Properties.DataSource = db.TBLCari
                .Select(p => new { p.ID, CARI = p.AD + " " + p.SOYAD })
                .ToList();
            txtpersonel.Properties.DataSource = db.TBLPersonnel
                .Select(p => new { p.ID, PERSONEL = p.AD + " " + p.SOYAD })
                .ToList();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLBillingInfo t = new TBLBillingInfo();
            t.SERI = Txtseri.Text;
            t.SIRANO = txtsırano.Text;
            t.TARIH = DateTime.Parse(txttarih.Text);
            t.SAAT = txtsaat.Text;
            t.VERGIDAIRE = txtvergidairesi.Text;
            t.CARI = int.Parse(txtcari.EditValue.ToString());
            t.PERSONEL = short.Parse(txtpersonel.EditValue.ToString());
            db.TBLBillingInfo.Add(t);
            db.SaveChanges();
            MessageBox.Show("Fatura sisteme kaydedilmiştir,Kalem girişi yapabilirsiniz.");
            listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaPopup fr = new FrmFaturaPopup();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            fr.Show();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLBillingInfo.Find(id);
            db.TBLBillingInfo.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Fatura başarılı bir şekilde silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            listele();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLBillingInfo.Find(id);
            deger.SERI = Txtseri.Text;
            deger.SIRANO = txtsırano.Text;
            deger.TARIH = DateTime.Parse(txttarih.Text);
            deger.SAAT = txtsaat.Text;
            deger.VERGIDAIRE = txtvergidairesi.Text;
            deger.CARI = int.Parse(txtcari.EditValue.ToString());
            deger.PERSONEL = short.Parse(txtpersonel.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Fatura başarıyla güncellenmiştir.");
            listele();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            Txtseri.Text = gridView1.GetFocusedRowCellValue("SERI").ToString();
            txtsırano.Text = gridView1.GetFocusedRowCellValue("SIRANO").ToString();
            txttarih.Text = gridView1.GetFocusedRowCellValue("TARIH").ToString();
            txtsaat.Text = gridView1.GetFocusedRowCellValue("SAAT").ToString();
            txtvergidairesi.Text = gridView1.GetFocusedRowCellValue("VERGIDAIRE").ToString();
            txtcari.Text = gridView1.GetFocusedRowCellValue("CARI").ToString();
            txtpersonel.Text = gridView1.GetFocusedRowCellValue("PERSONEL").ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TxtID.Text = "";
            Txtseri.Text = "";
            txtsırano.Text = "";
            txttarih.Text = "";
            txtsaat.Text = "";
            txtvergidairesi.Text = "";
            txtcari.EditValue = "";
            txtpersonel.EditValue = "";
        }
    }
}
