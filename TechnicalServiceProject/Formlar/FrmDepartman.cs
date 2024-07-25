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
    public partial class FrmDepartman : Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }
        TeknikServisDBEntities db=new TeknikServisDBEntities();
        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            var degerler = from d in db.TBLDepartment
                           select new
                           {
                               d.ID,
                               d.AD,
                               d.ACIKLAMA
                           };
            gridControl1.DataSource = degerler.ToList();
            labelControl12.Text=db.TBLDepartment.Count().ToString();
            labelControl14.Text=db.TBLPersonnel.Count().ToString();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtDepAd.Text.Length<=50 && TxtDepAd.Text!="" && Txtdepack.Text.Length>=1 && Txtdepack.Text.Length<=100)
            {
                TBLDepartment d = new TBLDepartment();
                d.AD = TxtDepAd.Text;
                d.ACIKLAMA = Txtdepack.Text;
                db.TBLDepartment.Add(d);
                db.SaveChanges();
                MessageBox.Show("Departman başarılı bir şekilde eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kayıt Yapılamadı!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id =int.Parse(TxtID.Text);
            var deger= db.TBLDepartment.Find(id);
            db.TBLDepartment.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Departman başarılı bir şekilde silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLDepartment.Find(id);
            deger.AD=TxtDepAd.Text;
            deger.ACIKLAMA =Txtdepack.Text;
            db.SaveChanges();
            MessageBox.Show("Departman başarılı bir Şekilde güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from d in db.TBLDepartment
                           select new
                           {
                               d.ID,
                               d.AD,
                               d.ACIKLAMA
                           };
            gridControl1.DataSource = degerler.ToList();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtDepAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            var aciklamavalue = gridView1.GetFocusedRowCellValue("ACIKLAMA");
            Txtdepack.Text = aciklamavalue != null ? aciklamavalue.ToString() : "";
        }
    }
}
