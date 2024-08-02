using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnicalServiceProject.Formlar
{
    public partial class FrmArizaListesi : Form
    {
        public FrmArizaListesi()
        {
            InitializeComponent();
        }
        TeknikServisDBEntities db = new TeknikServisDBEntities();
        private void FrmArizaListesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLProductAcceptance
                           select new
                           {
                               x.ISLEMID,
                               CARİ = x.TBLCari.AD + " " + x.TBLCari.SOYAD,
                               PERSONEL = x.TBLPersonnel.AD + " " + x.TBLPersonnel.SOYAD,
                               x.GELISTARIHI,
                               x.CIKISTARIHI,
                               x.URUNSERINO,
                               x.DURUM
                           };
            gridControl1.DataSource = degerler.ToList();

            labelControl3.Text = db.TBLProductAcceptance.Count(x => x.DURUM != "Kargoya Verildi").ToString();
            labelControl1.Text = db.TBLProductAcceptance.Count(x => x.DURUM == "İşlem Tamamlandı").ToString();
            labelControl7.Text = db.TBLProductAcceptance.Count(x => x.DURUM == "Parça Bekliyor").ToString();
            labelControl11.Text = db.TBLProduct.Count().ToString();
            labelControl15.Text = db.TBLProductAcceptance.Count(x => x.DURUM == "Müşteri Bekleniyor").ToString();
            labelControl13.Text = db.TBLProductAcceptance.Count(x => x.DURUM == "İptal Edildi").ToString();


            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-BAPR309;Initial Catalog=TeknikServisDB;Integrated Security=True;TrustServerCertificate=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select DURUM,COUNT(*) FROM TBLProductAcceptance GROUP BY DURUM", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmArizaDetaylar fr = new FrmArizaDetaylar();
            fr.urunid =gridView1.GetFocusedRowCellValue("ISLEMID").ToString();
            fr.serino =gridView1.GetFocusedRowCellValue("URUNSERINO").ToString();
            fr.Show();
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            FrmArizaDetaylar fr = new FrmArizaDetaylar();
            fr.urunid = gridView1.GetFocusedRowCellValue("ISLEMID").ToString();
            fr.serino = gridView1.GetFocusedRowCellValue("URUNSERINO").ToString();
            fr.Show();
        }
    }
}
