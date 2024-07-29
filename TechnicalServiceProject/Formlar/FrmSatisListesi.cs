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
    public partial class FrmSatisListesi : Form
    {
        public FrmSatisListesi()
        {
            InitializeComponent();
        }
        TeknikServisDBEntities db = new TeknikServisDBEntities();
        private void FrmSatisListesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLProductMovement
                           select new
                           {
                               x.HAREKETID,
                               x.TBLProduct.AD,
                               x.TBLProduct.MARKA,
                               MUSTERI = x.TBLCari.AD + " " + x.TBLCari.SOYAD,
                               PERSONEL = x.TBLPersonnel.AD + " " + x.TBLPersonnel.SOYAD,
                               x.TARIH,
                               x.ADET,
                               x.FIYAT,
                               x.URUNSERINO
                           };
            gridControl1.DataSource = degerler.ToList();
        }
    }
}
