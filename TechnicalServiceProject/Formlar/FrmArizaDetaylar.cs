using DevExpress.Accessibility;
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
    public partial class FrmArizaDetaylar : Form
    {
        public FrmArizaDetaylar()
        {
            InitializeComponent();
        }
        TeknikServisDBEntities db = new TeknikServisDBEntities();
        private void BtnGuncel_Click(object sender, EventArgs e)
        {
            TBLProductTracking t = new TBLProductTracking();
            t.ACIKLAMA = TxtDetay.Text;
            t.TARIH = DateTime.Parse(textEdit1.Text);
            t.SERINO = TxtSeri.Text;
            db.TBLProductTracking.Add(t);
            if (urunid!=null)
            {
                TBLProductAcceptance a = new TBLProductAcceptance();

                int id = int.Parse(urunid);
                var deger = db.TBLProductAcceptance.Find(id);
                deger.DURUM = comboBox1.Text;
                if (comboBox1.Text=="Kargoya Verildi")
                {
                    
                    deger.CIKISTARIHI =DateTime.Now;
                }
                db.SaveChanges();
                MessageBox.Show("Ürün arıza detayları güncellendi.");
                this.Close();
            }
            else
            {
                var deger = db.TBLProductAcceptance.FirstOrDefault(x => x.URUNSERINO == TxtSeri.Text);
                if (deger != null)
                {
                    deger.DURUM = comboBox1.Text;
                    if (comboBox1.Text == "Kargoya Verildi")
                    {
                        deger.CIKISTARIHI = DateTime.Now; 
                    }
                }
                else
                {
                    MessageBox.Show("Belirtilen seri numarasıyla eşleşen bir ürün bulunamadı.");
                }
                db.SaveChanges();
                MessageBox.Show("Ürün arıza detayları güncellendi.");
                this.Close();
            }

        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            DialogResult vazgec = MessageBox.Show("Arıza detay işleminden  vazgeçmek istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (vazgec == System.Windows.Forms.DialogResult.Yes)
            {

                this.Close();

            }
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtSeri_Click(object sender, EventArgs e)
        {
            TxtSeri.Text = "";
        }

        private void textEdit1_Click(object sender, EventArgs e)
        {
            textEdit1.Text=DateTime.Now.ToShortDateString();
        }

        private void TxtDetay_Click(object sender, EventArgs e)
        {
            TxtDetay.Text = "";
        }
        public string urunid,serino;
        private void FrmArizaDetaylar_Load(object sender, EventArgs e)
        {
            if (serino!=null)
            {
                TxtSeri.Text = serino;
            }
        }
    }
}
