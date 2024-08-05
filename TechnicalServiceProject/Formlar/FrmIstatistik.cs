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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }
        TeknikServisDBEntities db = new TeknikServisDBEntities();
        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            labelControl2.Text = db.TBLProduct.Count().ToString();
            labelControl3.Text = db.TBLCategory.Count().ToString();
            labelControl5.Text = db.TBLProduct.Sum(x => x.STOK).ToString();
            labelControl7.Text = "10";
            labelControl19.Text = (from x in db.TBLProduct
                                   orderby x.STOK descending
                                   select x.AD + " / " + x.MARKA).FirstOrDefault();
            labelControl17.Text = (from x in db.TBLProduct
                                   orderby x.STOK ascending
                                   select x.AD + " / " + x.MARKA).FirstOrDefault();
            labelControl13.Text = (from x in db.TBLProduct
                                   orderby x.SATISFIYAT descending
                                   select x.AD + " / " + x.MARKA).FirstOrDefault();
            labelControl11.Text = (from x in db.TBLProduct
                                   orderby x.SATISFIYAT ascending
                                   select x.AD + " / " + x.MARKA).FirstOrDefault();
            labelControl25.Text = (from x in db.TBLProduct
                                   where x.KATEGORI == 4
                                   select x.STOK).Sum(x => x.Value).ToString();


            labelControl23.Text = (from x in db.TBLProduct
                                   where x.KATEGORI == 1
                                   select x.STOK).Sum(x => x.Value).ToString();
            labelControl21.Text = (from x in db.TBLProduct
                                   where x.KATEGORI == 3
                                   select x.STOK).Sum(x => x.Value).ToString();
            labelControl39.Text = (from x in db.TBLProduct
                                   select x.MARKA).Distinct().Count().ToString();
            labelControl35.Text = db.TBLProductAcceptance.Count().ToString();

            labelControl15.Text = db.maxkategoriurun().FirstOrDefault();

            labelControl27.Text = db.TBLProductAcceptance.Count(x => x.DURUM == "Kargoya Verildi").ToString();
            labelControl29.Text = db.TBLProductAcceptance.Count(x => x.DURUM == "İşlem Tamamlandı").ToString();
            var today = DateTime.Today;
            labelControl31.Text = db.TBLProductAcceptance.Count(x => x.GELISTARIHI == today).ToString();

            labelControl33.Text = db.TBLProductAcceptance.Count(x => x.DURUM == "İşlem Görüyor").ToString();
            var marka = db.TBLProduct.GroupBy(p => p.MARKA).OrderByDescending(g => g.Count()).FirstOrDefault();
            labelControl37.Text = marka.Key;

            labelControl9.Text=db.TBLProductMovement.Count(x=>x.TARIH==today).ToString();

        }
    }
}
