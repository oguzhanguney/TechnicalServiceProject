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
    public partial class FrmFaturaKalemleri : Form
    {
        public FrmFaturaKalemleri()
        {
            InitializeComponent();
        }
        TeknikServisDBEntities db = new TeknikServisDBEntities();

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (txtfaturaıd.Text != "")
            {
                int id = int.Parse(txtfaturaıd.Text);
                var degerler = (from d in db.TBLBillingDetail
                                select new
                                {
                                    d.FATURADETAYID,
                                    d.URUN,
                                    d.ADET,
                                    d.FIYAT,
                                    d.TUTAR,
                                    d.FATURAID

                                }).Where(x => x.FATURAID == id);
                gridControl1.DataSource = degerler.ToList();
            }

            else
            {
                var dg = (from u in db.TBLBillingDetail.Where(x => x.TBLBillingInfo.SERI == txtserino.Text | x.TBLBillingInfo.SIRANO == txtsırano.Text)
                          select new
                          {
                              u.URUN,
                              u.TBLBillingInfo.SIRANO,
                              u.TBLBillingInfo.SERI,
                              u.ADET,
                              u.FIYAT,
                              u.TUTAR,
                              u.FATURAID,
                              CARI = u.TBLBillingInfo.TBLCari.AD + " " + u.TBLBillingInfo.TBLCari.SOYAD
                          });
                gridControl1.DataSource = dg.ToList();
            }

            


        }


    }
}
