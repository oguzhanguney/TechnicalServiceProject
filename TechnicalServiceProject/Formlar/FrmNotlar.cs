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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        TeknikServisDBEntities db= new TeknikServisDBEntities();
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TBLNotes.Where(x=>x.DURUM==false).ToList();
            gridControl2.DataSource = db.TBLNotes.Where(y=>y.DURUM==true).ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLNotes t =new TBLNotes();
            t.BASLIK=Txtbaslik.Text;
            t.ICERIK=Txtiçerik.Text;
            t.DURUM = false;
            db.TBLNotes.Add(t);
            db.SaveChanges();
            MessageBox.Show("Not başarılı bir şekilde kaydedildi.","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TBLNotes.Where(x => x.DURUM == false).ToList();
            gridControl2.DataSource = db.TBLNotes.Where(y => y.DURUM == true).ToList();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked==true)
            {
                int id = int.Parse(TxtID.Text);
                var deger=db.TBLNotes.Find(id);
                deger.DURUM = true;
                db.SaveChanges();
                MessageBox.Show("Okundu olarak işaretlendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text=gridView1.GetFocusedRowCellValue("ID").ToString();
        }
    }
}
