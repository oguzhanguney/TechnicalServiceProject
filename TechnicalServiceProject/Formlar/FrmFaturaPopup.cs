using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnicalServiceProject.Formlar
{
    public partial class FrmFaturaPopup : DevExpress.XtraEditors.XtraForm
    {
        public FrmFaturaPopup()
        {
            InitializeComponent();
        }
        public int id;
        private void FrmFaturaPopup_Load(object sender, EventArgs e)
        {
            TeknikServisDBEntities db = new TeknikServisDBEntities();
            gridControl1.DataSource = (from x in db.TBLBillingDetail
                                       select new
                                       {
                                           x.URUN,
                                           x.ADET,
                                           x.FIYAT,
                                           x.TUTAR,
                                           x.FATURAID
                                       }).Where(x => x.FATURAID == id).ToList();

            gridControl2.DataSource = (from x in db.TBLBillingInfo
                                       select new
                                       {
                                           x.ID,
                                           x.SERI,
                                           x.SIRANO,
                                           x.TARIH,
                                           x.SAAT,
                                           x.VERGIDAIRE,
                                           CARI=x.TBLCari.AD + " " + x.TBLCari.SOYAD,
                                           PERSONEL=x.TBLPersonnel.AD+" "+x.TBLPersonnel.SOYAD
                                       }).Where(x=>x.ID == id).ToList();
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string path = $"Fatura_{timestamp}.pdf";
            gridControl1.ExportToPdf(path);
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string path = $"Fatura_{timestamp}.xls";
            gridControl1.ExportToXls(path);
        }
    }
}
