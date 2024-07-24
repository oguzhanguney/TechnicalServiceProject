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
    public partial class FrmMarkalar : Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }
        TeknikServisDBEntities db= new TeknikServisDBEntities();
        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            var degerler = db.TBLProduct.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).Select(z => new
            {
                Marka = z.Key,
                ToplamÜrün= z.Count()
            });
            gridControl1.DataSource = degerler.ToList();
            labelControl5.Text =  db.TBLProduct.Count().ToString();
            labelControl1.Text = db.TBLProduct.Select(x => x.MARKA).Distinct().Count().ToString();
            labelControl7.Text=db.TBLProduct.OrderByDescending(x=>x.SATISFIYAT).Select(y=>y.MARKA).FirstOrDefault().ToString();

            chartControl1.Series["Series 1"].Points.AddPoint("Siemens",4);
            chartControl1.Series["Series 1"].Points.AddPoint("Arçelik",5);
            chartControl1.Series["Series 1"].Points.AddPoint("Bosch",7);
            chartControl1.Series["Series 1"].Points.AddPoint("Philips",8);

            chartControl2.Series["Kategoriler"].Points.AddPoint("Beyaz Eşya", 5);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Bilgisayar", 8);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Küçük Ev Aletleri", 2);
            chartControl2.Series["Kategoriler"].Points.AddPoint("TV", 12);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Mobilya", 7);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Yapı Aksesuar", 4);

        }   


    }
}
