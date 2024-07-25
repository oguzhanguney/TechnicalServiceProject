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
    public partial class FrmCariIller : Form
    {
        public FrmCariIller()
        {
            InitializeComponent();
        }

        TeknikServisDBEntities db = new TeknikServisDBEntities();

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-BAPR309;Initial Catalog=TeknikServisDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        private void FrmCariIller_Load(object sender, EventArgs e)
        {
            


            gridControl1.DataSource = db.TBLCari.OrderBy(x=>x.IL).
                GroupBy(y=>y.IL).
                Select(z=>new {İL=z.Key,TOPLAM=z.Count()}).ToList();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select IL,COUNT(*) FROM TBLCari group by IL", baglanti);
            SqlDataReader dr= komut.ExecuteReader();
            while (dr.Read()) 
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString( dr[0]),int.Parse( dr[1].ToString()));
            }
            baglanti.Close();
        }
    }
}
