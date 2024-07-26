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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        TeknikServisDBEntities db= new TeknikServisDBEntities();
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            var degerler = from p in db.TBLPersonnel
                           select new
                           {
                               p.ID,
                               p.AD,
                               p.SOYAD,
                               p.FOTOGRAF,
                               p.MAIL,
                               p.TELEFON
                           };
            gridControl1.DataSource = degerler.ToList();

            lookUpEdit1.Properties.DataSource= db.TBLDepartment
                .Select(p => new {p.ID,p.AD})
                .ToList();

            string ad1, soyad1,ad2,soyad2,ad3,soyad3,ad4,soyad4;
            ad1 =  db.TBLPersonnel.First(x => x.ID == 1).AD;
            soyad1 =  db.TBLPersonnel.First(x => x.ID == 1).SOYAD;
            Txtperadsoyad.Text = ad1 + " " + soyad1;
            txtpermail.Text=db.TBLPersonnel.First(x=>x.ID == 1).MAIL.ToLower();
            Txtperdep.Text="("+db.TBLPersonnel.First(x=>x.ID==1).TBLDepartment.AD+")";

            ad2 = db.TBLPersonnel.First(x => x.ID == 2).AD;
            soyad2 = db.TBLPersonnel.First(x => x.ID == 2).SOYAD;
            textBox3.Text = ad2 + " " + soyad2;
            textBox2.Text = db.TBLPersonnel.First(x => x.ID == 2).MAIL.ToLower();
            textBox1.Text = "(" + db.TBLPersonnel.First(x => x.ID == 2).TBLDepartment.AD + ")";

            ad3 = db.TBLPersonnel.First(x => x.ID == 3).AD;
            soyad3 = db.TBLPersonnel.First(x => x.ID == 3).SOYAD;
            textBox6.Text = ad3 + " " + soyad3;
            textBox5.Text = db.TBLPersonnel.First(x => x.ID == 3).MAIL.ToLower();
            textBox4.Text = "(" + db.TBLPersonnel.First(x => x.ID == 3).TBLDepartment.AD + ")";

            ad4 = db.TBLPersonnel.First(x => x.ID == 4).AD;
            soyad4 = db.TBLPersonnel.First(x => x.ID == 4).SOYAD;
            textBox9.Text = ad4 + " " + soyad4;
            textBox8.Text = db.TBLPersonnel.First(x => x.ID == 4).MAIL.ToLower();
            textBox7.Text = "(" + db.TBLPersonnel.First(x => x.ID == 4).TBLDepartment.AD + ")";
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLPersonnel d = new TBLPersonnel();
            d.AD = Txtad.Text;
            d.SOYAD = Txtsoyad.Text;
            d.FOTOGRAF = Txtfoto.Text;
            d.MAIL =txtpersonelmail.Text;
            d.TELEFON = Txttel.Text;
            d.DEPARTMAN = byte.Parse(lookUpEdit1.EditValue.ToString());

            db.TBLPersonnel.Add(d);
            db.SaveChanges();
            MessageBox.Show("Personel başarılı bir şekilde eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLPersonnel.Find(id);
            db.TBLPersonnel.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Personel başarılı bir şekilde silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLPersonnel.Find(id);
            deger.AD = Txtad.Text;
            deger.SOYAD = Txtsoyad.Text;
            deger.FOTOGRAF = Txtfoto.Text;
            deger.MAIL = txtpersonelmail.Text;
            deger.TELEFON = Txttel.Text;
            deger.DEPARTMAN=byte.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Personel başarılı bir Şekilde güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from p in db.TBLPersonnel
                           select new
                           {
                               p.ID,
                               p.AD,
                               p.SOYAD,
                               p.FOTOGRAF,
                               p.MAIL,
                               p.TELEFON
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            Txtad.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            Txtsoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
            Txttel.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();
            txtpersonelmail.Text = gridView1.GetFocusedRowCellValue("MAIL").ToString();
            var fotovalue = gridView1.GetFocusedRowCellValue("FOTOGRAF");
            Txtfoto.Text = fotovalue != null ? fotovalue.ToString() : "";
        }
    }
}
