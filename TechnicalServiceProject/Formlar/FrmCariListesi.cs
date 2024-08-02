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
    public partial class FrmCariListesi : Form
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }
        TeknikServisDBEntities db = new TeknikServisDBEntities();
        int secilen;
        private void FrmCariListesi_Load(object sender, EventArgs e)
        {

            gridControl1.DataSource = (from x in db.TBLCari
                                       select new
                                       {
                                           x.ID,
                                           x.AD,
                                           x.SOYAD,
                                           x.MAIL,
                                           x.IL,
                                           x.ILCE
                                       }).ToList();

            labelControl12.Text = db.TBLCari.Count().ToString();
            labelControl14.Text = db.TBLCari.Select(x=>x.ILCE).Distinct().Count().ToString();
            labelControl16.Text = db.TBLCari.Select(x => x.IL).Distinct().Count().ToString();
            labelControl18.Text = db.TBLCari
                .GroupBy(c => c.IL)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault().ToString();

            lookUpEdit1.Properties.DataSource = (from x in db.TBLIller
                                                 select new
                                                 {
                                                     x.id,
                                                     x.sehir
                                                 }).ToList();


        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLCari c = new TBLCari();
            c.AD = TxtCariAd.Text;
            c.SOYAD = Txtcarsoyad.Text;
            c.TELEFON = Txttel.Text;
            c.MAIL = Txtmail.Text;
            c.IL = lookUpEdit1.Text;
            c.ILCE = lookUpEdit2.Text;
            c.BANKA = Txtbank.Text;
            c.VERGIDAIRESI = Txtvergid.Text;
            c.VERGINO = Txtvergino.Text;
            c.STATU = Txtstat.Text;
            c.ADRES = Txtadr.Text;
            db.TBLCari.Add(c);
            db.SaveChanges();
            MessageBox.Show("Cari başarılı bir şekilde eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLCari.Find(id);
            db.TBLCari.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Cari başarılı bir şekilde silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLCari.Find(id);
            deger.AD = TxtCariAd.Text;
            deger.SOYAD = Txtcarsoyad.Text;
            deger.TELEFON = Txttel.Text;
            deger.MAIL = Txtmail.Text;
            deger.IL = lookUpEdit1.Text;
            deger.ILCE=lookUpEdit2.Text;
            deger.BANKA = Txtbank.Text;
            deger.VERGIDAIRESI = Txtvergid.Text;
            deger.VERGINO = Txtvergino.Text;
            deger.STATU = Txtstat.Text;
            deger.ADRES = Txtadr.Text;
            db.SaveChanges();
            MessageBox.Show("Cari başarılı bir Şekilde güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLCari
                                       select new
                                       {
                                           x.ID,
                                           x.AD,
                                           x.SOYAD,
                                           x.MAIL,
                                           x.IL,
                                           x.ILCE
                                       }).ToList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtCariAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            Txtcarsoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
            var telefonValue = gridView1.GetFocusedRowCellValue("TELEFON");
            Txttel.Text = telefonValue != null ? telefonValue.ToString() : "";
            var mailValue = gridView1.GetFocusedRowCellValue("MAIL");
            Txtmail.Text = mailValue != null ? mailValue.ToString() : "";
            var bankaValue = gridView1.GetFocusedRowCellValue("BANKA");
            Txtbank.Text = bankaValue != null ? bankaValue.ToString() : "";

            var vergiDairesiValue = gridView1.GetFocusedRowCellValue("VERGIDAIRESI");
            Txtvergid.Text = vergiDairesiValue != null ? vergiDairesiValue.ToString() : "";

            var vergiNoValue = gridView1.GetFocusedRowCellValue("VERGINO");
            Txtvergino.Text = vergiNoValue != null ? vergiNoValue.ToString() : "";

            var statuValue = gridView1.GetFocusedRowCellValue("STATU");
            Txtstat.Text = statuValue != null ? statuValue.ToString() : "";

            var adresValue = gridView1.GetFocusedRowCellValue("ADRES");
            Txtadr.Text = adresValue != null ? adresValue.ToString() : "";
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("IL").ToString();
            lookUpEdit2.Text = gridView1.GetFocusedRowCellValue("ILCE").ToString();
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TxtID.Text = "";
            TxtCariAd.Text = "";
            Txtcarsoyad.Text = "";
            Txttel.Text = "";
            Txtmail.Text = "";
            Txtbank.Text = "";
            Txtvergid.Text = "";
            Txtvergino.Text = "";
            Txtstat.Text = "";
            Txtadr.Text = "";
        }
    }
}
