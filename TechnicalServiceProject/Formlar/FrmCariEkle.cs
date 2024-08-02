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
    public partial class FrmCariEkle : Form
    {
        public FrmCariEkle()
        {
            InitializeComponent();
        }
        TeknikServisDBEntities db = new TeknikServisDBEntities();
        int secilen;
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLCari t=new TBLCari();
            t.AD=TxtAd.Text;
            t.SOYAD=TxtSoyad.Text;
            t.TELEFON=TxtTel.Text;
            t.MAIL=TxtMail.Text;
            t.BANKA=TxtBank.Text;
            t.VERGIDAIRESI=TxtVergi.Text;
            t.VERGINO=TxtVergiNo.Text;
            t.STATU=TxtStatu.Text;
            t.ADRES=TxtAdress.Text;
            t.IL=lookUpEdit1.Text;
            t.ILCE=lookUpEdit2.Text;
            db.TBLCari.Add(t);
            db.SaveChanges();
            MessageBox.Show("Yeni Cari sisteme başarılı bir şekilde eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            DialogResult vazgec = MessageBox.Show("Cari ekleme işleminden vazgeçmek istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (vazgec == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void pictureEdit13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCariEkle_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = (from x in db.TBLIller
                                                 select new
                                                 {
                                                     x.id,
                                                     x.sehir
                                                 }).ToList();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            secilen = int.Parse(lookUpEdit1.EditValue.ToString());
            lookUpEdit2.Properties.DataSource = (from y in db.TBLIlceler
                                                 select new
                                                 {
                                                     y.id,
                                                     y.ilce,
                                                     y.sehir
                                                 }).Where(z => z.sehir == secilen).ToList();
        }
    }
}
