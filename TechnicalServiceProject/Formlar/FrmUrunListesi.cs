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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }

        TeknikServisDBEntities db=new TeknikServisDBEntities();

        void metot1()
        {
            var degerler = from p in db.TBLProduct
                           select new
                           {
                               p.ID,
                               p.AD,
                               p.MARKA,
                               KATEGORI = p.TBLCategory.AD,
                               p.STOK,
                               p.ALISFIYAT,
                               p.SATISFIYAT
                           };
            gridControl1.DataSource = degerler.ToList();

            
        }
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            //Listeleme
            metot1();
            //kategori listeleme
            lookupcateg.Properties.DataSource = db.TBLCategory
                                                .Select(p => new {p.ID,p.AD})
                                                .ToList();

        }

        
        private void BtnKaydet_Click_1(object sender, EventArgs e)
        {
            TBLProduct p = new TBLProduct();
            p.AD = TxtUrunAd.Text;
            p.MARKA = TxtMarka.Text;
            p.ALISFIYAT = decimal.Parse(TxtAlisFiyat.Text);
            p.SATISFIYAT = decimal.Parse(TxtSatisFiyat.Text);
            p.STOK = short.Parse(TxtStok.Text);
            p.DURUM = false;
            p.KATEGORI=byte.Parse( lookupcateg.EditValue.ToString());
            db.TBLProduct.Add(p);
            db.SaveChanges();
            MessageBox.Show("Ürün başarılı bir şekilde eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void BtnListele_Click(object sender, EventArgs e)
        {
            metot1();
        }


        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text=gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtUrunAd.Text=gridView1.GetFocusedRowCellValue("AD").ToString();
            TxtMarka.Text=gridView1.GetFocusedRowCellValue("MARKA").ToString();
            TxtAlisFiyat.Text=gridView1.GetFocusedRowCellValue("ALISFIYAT").ToString();
            TxtSatisFiyat.Text=gridView1.GetFocusedRowCellValue("SATISFIYAT").ToString();
            TxtStok.Text=gridView1.GetFocusedRowCellValue("STOK").ToString();
            lookupcateg.Text=gridView1.GetFocusedRowCellValue("KATEGORI").ToString();
        }


        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id=int.Parse(TxtID.Text);
            var deger = db.TBLProduct.Find(id);
            db.TBLProduct.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Ürün başarılı bir şekilde silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger=db.TBLProduct.Find(id);
            deger.AD = TxtUrunAd.Text;
            deger.STOK=short.Parse(TxtStok.Text);
            deger.MARKA=TxtMarka.Text;
            deger.ALISFIYAT = decimal.Parse(TxtAlisFiyat.Text);
            deger.SATISFIYAT=decimal.Parse(TxtSatisFiyat.Text);
            deger.KATEGORI=byte.Parse(lookupcateg.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ürün başarılı bir Şekilde güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TxtID.Text = "";
            TxtUrunAd.Text = "";
            TxtMarka.Text = "";
            TxtAlisFiyat.Text = "";
            TxtSatisFiyat.Text = "";
            TxtStok.Text = "";
            lookupcateg.EditValue = "";

        }
    }
}
