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
    public partial class FrmRehber : Form
    {
        public FrmRehber()
        {
            InitializeComponent();
        }
        TeknikServisDBEntities db = new TeknikServisDBEntities();
        private void FrmRehber_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLCari
                                       select new
                                       {
                                           x.AD,
                                           x.SOYAD,
                                           x.TELEFON,
                                           x.MAIL
                                       }).ToList();
        }
    }
}
