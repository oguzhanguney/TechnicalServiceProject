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
    public partial class FrmArizaListesi : Form
    {
        public FrmArizaListesi()
        {
            InitializeComponent();
        }
        TeknikServisDBEntities db = new TeknikServisDBEntities();
        private void FrmArizaListesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLProductAcceptance
                           select new
                           {
                               x.ISLEMID,
                               CARİ = x.TBLCari.AD +" "+ x.TBLCari.SOYAD,
                               PERSONEL = x.TBLPersonnel.AD +" "+ x.TBLPersonnel.SOYAD,
                               x.GELISTARIHI,
                               x.CIKISTARIHI,
                               x.URUNSERINO
                           };
            gridControl1.DataSource = degerler.ToList();

            labelControl3.Text=db.TBLProductAcceptance.Count(x=>x.DURUM!="Kargoya Verildi").ToString();
            labelControl1.Text=db.TBLProductAcceptance.Count(x=>x.DURUM=="İşlem Tamamlandı").ToString();
            labelControl7.Text = db.TBLProductAcceptance.Count(x => x.DURUM == "Parça Bekliyor").ToString();

        }
    }
}
