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

    public partial class FrmGelenMesajlar : Form
    {
        public FrmGelenMesajlar()
        {
            InitializeComponent();
        }

        TeknikServisDBEntities db = new TeknikServisDBEntities();

        private void FrmGelenMesajlar_Load(object sender, EventArgs e)
        {
            labelControl12.Text = db.TBLContact.Count().ToString();
            labelControl14.Text = db.TBLContact.Where(x => x.Konu == "Teşekkür").Count().ToString();
            labelControl16.Text = db.TBLContact.Where(x => x.Konu == "Rica").Count().ToString();
            labelControl18.Text = db.TBLContact.Where(x => x.Konu == "Şikayet").Count().ToString();
            labelControl1.Text = db.TBLPersonnel.Count().ToString();
            labelControl3.Text = db.TBLCari.Count().ToString();
            labelControl5.Text = db.TBLProduct.Count().ToString();
            labelControl7.Text = db.TBLCategory.Count().ToString();

            gridControl1.DataSource = (from x in db.TBLContact
                                      select new
                                      {
                                          x.ID,
                                          x.AdSoyad,
                                          x.Konu,
                                          x.Mail,
                                          x.Mesaj
                                      }).ToList();
        }
    }
}
