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
        TeknikServisDBEntities db = new TeknikServisDBEntities();
        private void FrmFaturaListesi_Load(object sender, EventArgs e)
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
            txtcari.Properties.DataSource = db.TBLCari
                .Select(p => new { p.ID, CARI = p.AD + " " + p.SOYAD })
                .ToList();
            txtpersonel.Properties.DataSource = db.TBLPersonnel
                .Select(p => new { p.ID, PERSONEL = p.AD + " " + p.SOYAD })
                .ToList();
        }

        private void BtnListele_Click(object sender, EventArgs e)
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

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLBillingInfo t= new TBLBillingInfo();
            t.SERI=Txtseri.Text;
            t.SIRANO=txtsırano.Text;
            t.TARIH=DateTime.Parse( txttarih.Text);
            t.SAAT=txtsaat.Text;
            t.VERGIDAIRE=txtvergidairesi.Text;
            t.CARI=int.Parse(txtcari.EditValue.ToString());
            t.PERSONEL=short.Parse(txtpersonel.EditValue.ToString());
            db.TBLBillingInfo.Add(t);
            db.SaveChanges();
            MessageBox.Show("Fatura sisteme kaydedilmiştir,Kalem girişi yapabilirsiniz.");
        }
    }
}
