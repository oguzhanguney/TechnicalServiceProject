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
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }

        TeknikServisDBEntities db=new TeknikServisDBEntities();

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLCategory
                           select new
                           {
                               x.ID,
                               x.AD
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLCategory t=new TBLCategory();
            t.AD = TxtKategoriAd.Text;
            db.TBLCategory.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori başarıyla kaydedildi.");

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLCategory
                           select new
                           {
                               x.ID,
                               x.AD
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtKategoriAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
        }

        private void groupControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id =int.Parse(TxtID.Text);
            var deger=db.TBLCategory.Find(id);
            db.TBLCategory.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Kategori başarılı bir şekilde silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLCategory.Find(id);
            deger.AD = TxtKategoriAd.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori başarılı bir Şekilde güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
