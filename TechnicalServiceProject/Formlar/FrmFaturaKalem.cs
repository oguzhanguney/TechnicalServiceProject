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
    public partial class FrmFaturaKalem : Form
    {
        public FrmFaturaKalem()
        {
            InitializeComponent();
        }
        TeknikServisDBEntities db=new TeknikServisDBEntities();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLBillingDetail b = new TBLBillingDetail();
            b.URUN = Txturun.Text;
            b.ADET=short.Parse( txtadet.Text);
            b.FIYAT=decimal.Parse(txtfiyat.Text);
            b.TUTAR=decimal.Parse(txttutar.Text);
            b.FATURAID=int.Parse(txtfaturaıd.Text);
            db.TBLBillingDetail.Add(b);
            db.SaveChanges();
            MessageBox.Show("Faturaya ait kalem girişi başarıyla yapıldı.");
        }

        private void FrmFaturaKalem_Load(object sender, EventArgs e)
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

        private void BtnListele_Click(object sender, EventArgs e)
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
    }
}
