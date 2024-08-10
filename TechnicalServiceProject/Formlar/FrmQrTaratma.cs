using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace TechnicalServiceProject.Formlar
{
    public partial class FrmQrTaratma : DevExpress.XtraEditors.XtraForm
    {
        public FrmQrTaratma()
        {
            InitializeComponent();
            this.FormClosing += FrmQrTaratma_FormClosing;
        }

        FilterInfoCollection fic;
        VideoCaptureDevice vcd;
        private void FrmQrTaratma_Load(object sender, EventArgs e)
        {
            fic = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo f in fic)
            {
                comboBox1.Items.Add(f.Name);
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vcd = new VideoCaptureDevice(fic[comboBox1.SelectedIndex].MonikerString);
            vcd.NewFrame += Vcd_NewFrame;
            vcd.Start();
            timer1.Start();
        }

        private void Vcd_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "(*.jpg)|*.jpg";
            DialogResult dr = s.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pictureBox1.Image.Save(s.FileName);
            }
        }

        private void FrmQrTaratma_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vcd != null)
            {
                vcd.SignalToStop();
                vcd.WaitForStop();
            }
        }
        private string previousSerialNumber = string.Empty;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                BarcodeReader brd = new BarcodeReader();
                Result sonuc = brd.Decode((Bitmap)pictureBox1.Image);
                if (sonuc != null)
                {
                    string currentSerialNumber = sonuc.ToString();

                    // Yeni bir QR kod okunduğunda ve eski seri numarasından farklıysa
                    if (currentSerialNumber != previousSerialNumber)
                    {
                        // Seri numarasına göre ürünü getir
                        var product = GetProductBySerial(currentSerialNumber);

                        if (product != null)
                        {
                            richTextBox1.Text = $"Ürün Adı: {product.AD}\n" +
                                                $"Marka: {product.MARKA}\n" +
                                                $"Fiyat: {product.SATISFIYAT}\n" +
                                                $"Stok Durumu: {product.STOK}";
                        }
                        else
                        {
                            richTextBox1.Text = "Ürün bulunamadı!";
                        }

                        // Şu anki seri numarasını sakla
                        previousSerialNumber = currentSerialNumber;
                    }
                }
            }
        }
        private TBLProduct GetProductBySerial(string serialNumber)
        {
            using (var context = new TeknikServisDBEntities())
            {
                var movement = context.TBLProductMovement
                                      .FirstOrDefault(m => m.URUNSERINO == serialNumber);
                if (movement != null)
                {
                    return context.TBLProduct.FirstOrDefault(p => p.ID == movement.URUN);
                }
                return null;
            }
        }
    }
}
