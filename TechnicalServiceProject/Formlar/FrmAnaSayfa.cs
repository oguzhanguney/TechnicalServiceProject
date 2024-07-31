using DevExpress.XtraEditors;
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
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }
        TeknikServisDBEntities db = new TeknikServisDBEntities();
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLProduct
                                       select new
                                       {
                                           x.AD,
                                           x.MARKA,
                                           x.STOK
                                       }).Where(x => x.STOK <= 40).ToList();

            gridControl2.DataSource = (from x in db.TBLCari
                                       select new
                                       {
                                           x.AD,
                                           x.SOYAD,
                                           x.IL
                                       }).ToList();

            gridControl3.DataSource = db.urunkategori().ToList();

            DateTime bugun = DateTime.Today;
            gridControl4.DataSource = (from x in db.TBLNotes.OrderBy(x => x.ID)
                                       where (x.TARIH == bugun)
                                       select new
                                       {
                                           x.BASLIK,
                                           x.ICERIK
                                       }).ToList();

            //contact list

            LabelControl[] labels = { labelControl1, labelControl2, labelControl3, labelControl4, labelControl5, labelControl6, labelControl7, labelControl8 };

            var contacts = db.TBLContact.ToList().AsEnumerable().Reverse().ToList();

            for (int i = 0; i < labels.Length; i++)
            {
                if (i < contacts.Count)
                {
                    var contact = contacts[i];
                    labels[i].Text = $"{contact.AdSoyad} - {contact.Konu}";
                }
                else
                {
                    labels[i].Text = string.Empty; 
                }
            }
        }
    }
}
