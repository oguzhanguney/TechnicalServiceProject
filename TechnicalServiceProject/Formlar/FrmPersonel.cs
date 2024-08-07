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
        private void listele()
        {
            var degerler = from p in db.TBLPersonnel
                           select new
                           {
                               p.ID,
                               p.AD,
                               p.SOYAD,
                               DEP = p.TBLDepartment.AD,
                               p.MAIL,
                               p.TELEFON
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        TeknikServisDBEntities db= new TeknikServisDBEntities();
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            listele();

            lookUpEdit1.Properties.DataSource= db.TBLDepartment
                .Select(p => new {p.ID,p.AD})
                .ToList();

            var personnelIDs = new[] { 1, 2, 3, 4 };
            var nameTextBoxes = new[] { Txtperadsoyad, textBox3, textBox6, textBox9 };
            var emailTextBoxes = new[] { txtpermail, textBox2, textBox5, textBox8 };
            var departmentTextBoxes = new[] { Txtperdep, textBox1, textBox4, textBox7 };

            for (int i = 0; i < personnelIDs.Length; i++)
            {
                var id = personnelIDs[i];
                var personnel = db.TBLPersonnel.First(x => x.ID == id);

                string fullName = personnel.AD + " " + personnel.SOYAD;
                 string email = personnel.MAIL.ToLower();
                string department = $"({personnel.TBLDepartment.AD})";

                nameTextBoxes[i].Text = fullName;
                emailTextBoxes[i].Text = email;
                departmentTextBoxes[i].Text = department;
            }
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
            listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLPersonnel.Find(id);
            db.TBLPersonnel.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Personel başarılı bir şekilde silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            listele();
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
            listele();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
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
            var departmanValue = gridView1.GetFocusedRowCellValue("DEP");
            if (departmanValue != null)
            {
                lookUpEdit1.Text = departmanValue.ToString();
            }
            else
            {
                lookUpEdit1.EditValue = ""; // Veya başka bir varsayılan değer    
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TxtID.Text = "";
            Txtad.Text = "";
            Txtsoyad.Text = "";
            Txttel.Text = "";
            txtpersonelmail.Text = "";
            Txtfoto.Text = "";
            lookUpEdit1.EditValue = "";
        }
    }
}
