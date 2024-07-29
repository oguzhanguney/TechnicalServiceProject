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
            t.TARIH = DateTime.Parse(TxtTarih.Text);
            t.SERINO = TxtSerino.Text;
            db.TBLProductTracking.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün arıza detayları güncellendi.");
        }
    }
}
