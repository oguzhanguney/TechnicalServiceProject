using DevExpress.XtraEditors;
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
    public partial class FrmMarkalar : Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }
        TeknikServisDBEntities db = new TeknikServisDBEntities();
        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            var degerler = db.TBLProduct.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).Select(z => new
            {
                Marka = z.Key,
                ToplamÜrün = z.Count()
            });
            gridControl1.DataSource = degerler.ToList();
            var marka = db.TBLProduct.GroupBy(p => p.MARKA).OrderByDescending(g => g.Count()).FirstOrDefault();
            labelControl3.Text = marka.Key;
            labelControl5.Text = db.TBLProduct.Count().ToString();
            labelControl1.Text = db.TBLProduct.Select(x => x.MARKA).Distinct().Count().ToString();
            labelControl7.Text = db.TBLProduct.OrderByDescending(x => x.SATISFIYAT).Select(y => y.MARKA).FirstOrDefault().ToString();

            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-BAPR309;Initial Catalog=TeknikServisDB;Integrated Security=True;TrustServerCertificate=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select MARKA,count(*) from TBLProduct group by MARKA", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();

            SqlConnection baglanti2 = new SqlConnection(@"Data Source=DESKTOP-BAPR309;Initial Catalog=TeknikServisDB;Integrated Security=True;TrustServerCertificate=True");
            baglanti2.Open();
            SqlCommand komut2 = new SqlCommand("select TBLCategory.AD,count(*) from TBLProduct \r\ninner join TBLCategory on TBLCategory.ID=TBLProduct.KATEGORI\r\ngroup by TBLCategory.AD ", baglanti2);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Kategoriler"].Points.AddPoint(Convert.ToString(dr2[0]), int.Parse(dr2[1].ToString()));
            }
            baglanti2.Close();


            

        }


    }
}
