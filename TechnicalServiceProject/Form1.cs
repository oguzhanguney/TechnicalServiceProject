using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnicalServiceProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Formlar.FrmUrunListesi fr3;
        private void BtnUrunListesiFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null || fr3.IsDisposed)
            {
                fr3 = new Formlar.FrmUrunListesi();
                fr3.MdiParent = this;
                fr3.Show();
            }
        }

        Formlar.FrmCariEkle fr5;
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr5 == null || fr5.IsDisposed)
            {
                fr5 = new Formlar.FrmCariEkle();
                fr5.Show();
            }
        }


        private void barButtonItem38_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        Formlar.FrmYeniUrun fr6;
        private void BtnYeniUrun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6==null||fr6.IsDisposed)
            {
                fr6 = new Formlar.FrmYeniUrun();
                fr6.Show();
            }
        }


        Formlar.FrmCategory fr2;
        private void BtnKategori_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new Formlar.FrmCategory();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }
        Formlar.FrmYeniKategori fr7;
        private void BtnYeniKategori_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr7==null || fr7.IsDisposed)
            {
                fr7 = new Formlar.FrmYeniKategori();
                fr7.Show();
            }
        }
        Formlar.FrmIstatistik fr4;
        private void BtnIstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4==null||fr4.IsDisposed)
            {
                fr4 = new Formlar.FrmIstatistik();
                fr4.MdiParent = this;
                fr4.Show();
            }
        }
        Formlar.FrmMarkalar fr8;
        private void BtnMarkaIst_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8 == null || fr8.IsDisposed)
            {
                fr8 = new Formlar.FrmMarkalar();
                fr8.MdiParent = this;
                fr8.Show();
            }
        }
        Formlar.FrmCariListesi fr9;
        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9 == null || fr9.IsDisposed)
            {
                fr9 = new Formlar.FrmCariListesi();
                fr9.MdiParent = this;
                fr9.Show();
            }
        }
        Formlar.FrmCariIller fr10;
        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr10 == null || fr10.IsDisposed)
            {
                fr10 = new Formlar.FrmCariIller();
                fr10.MdiParent = this;
                fr10.Show();
            }
        }
        Formlar.FrmDepartman fr11;
        private void BtnDepList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr11 == null || fr11.IsDisposed)
            {
                fr11 = new Formlar.FrmDepartman();
                fr11.MdiParent = this;
                fr11.Show();
            }
        }
        Formlar.FrmYeniDepartman fr12;
        private void BtnYeniDep_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12 == null || fr12.IsDisposed)
            {
                fr12 = new Formlar.FrmYeniDepartman();
                fr12.Show();
            }
        }
        Formlar.FrmPersonel fr13;
        private void BtnPersonelList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr13 == null || fr13.IsDisposed)
            {
                fr13 = new Formlar.FrmPersonel();
                fr13.MdiParent = this;
                fr13.Show();
            }
        }

        private void btnHesapMak_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }
        Formlar.FrmKurlar fr14;
        private void btnKurlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr14 == null || fr14.IsDisposed)
            {
                fr14 = new Formlar.FrmKurlar();
                fr14.MdiParent = this;
                fr14.Show();
            }
        }

        private void btnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("winword");

        }

        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("excel");

        }
        Formlar.FrmYoutube fr15;
        private void btnYoutube_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr15 == null || fr15.IsDisposed)
            {
                fr15 = new Formlar.FrmYoutube();
                fr15.MdiParent = this;
                fr15.Show();
            }
        }
        Formlar.FrmNotlar fr16;
        private void btnAjanda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr16 == null || fr16.IsDisposed)
            {
                fr16 = new Formlar.FrmNotlar();
                fr16.MdiParent = this;
                fr16.Show();
            }
        }
        Formlar.FrmArizaListesi fr17;
        private void btnArizalist_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr17 == null || fr17.IsDisposed)
            {
                fr17 = new Formlar.FrmArizaListesi();
                fr17.MdiParent = this;
                fr17.Show();
            }
        }
        Formlar.FrmUrunSatis fr18;
        private void btnUrunSatis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr18 == null || fr18.IsDisposed)
            {
                fr18 = new Formlar.FrmUrunSatis();
                fr18.Show();
            }
        }
        Formlar.FrmSatisListesi fr19;
        private void btnSatisListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr19 == null || fr19.IsDisposed)
            {
                fr19 = new Formlar.FrmSatisListesi();
                fr19.MdiParent = this;
                fr19.Show();
            }
        }
        Formlar.FrmYeniArızalıUrunKaydı fr20;
        private void btnYeniAriza_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr20 == null || fr20.IsDisposed)
            fr20 = new Formlar.FrmYeniArızalıUrunKaydı();
            fr20.Show();
        }
        Formlar.FrmArizaDetaylar fr21;
        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr21 == null || fr21.IsDisposed)
            {
                fr21 = new Formlar.FrmArizaDetaylar();
                fr21.Show();
            }
        }
        Formlar.FrmArizaliUrunDetayListesi fr22;
        private void btnArizaliurundetay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr22 == null || fr22.IsDisposed)
            {
                fr22 = new Formlar.FrmArizaliUrunDetayListesi();
                fr22.MdiParent = this;
                fr22.Show();
            }
        }
        Formlar.FrmQrCode fr23;
        private void btnQrCode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr23 == null || fr23.IsDisposed)
            {
                fr23 = new Formlar.FrmQrCode();
                fr23.Show();
            }
        }
        Formlar.FrmFaturaListesi fr24;
        private void btnFaturaListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr24 == null || fr24.IsDisposed)
            {
                fr24 = new Formlar.FrmFaturaListesi();
                fr24.MdiParent = this;
                fr24.Show();
            }
            
        }
        Formlar.FrmFaturaKalem fr25;
        private void btnfaturakalem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr25 == null || fr25.IsDisposed)
            {
                fr25 = new Formlar.FrmFaturaKalem();
                fr25.MdiParent = this;
                fr25.Show();
            }
        }
        Formlar.FrmFaturaKalemleri fr26;
        private void btnFaturaKalemListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr26 == null || fr26.IsDisposed)
            {
                fr26 = new Formlar.FrmFaturaKalemleri();
                fr26.MdiParent = this;
                fr26.Show();
            }
        }

       
        Formlar.FrmHarita fr28;
        private void btnHaritalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr28 == null || fr28.IsDisposed)
            {
                fr28 = new Formlar.FrmHarita();
                fr28.MdiParent = this;
                fr28.Show();
            }
        }
        Formlar.FrmRapor fr29;
        private void btnRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr29 == null || fr29.IsDisposed)
            {
                fr29 = new Formlar.FrmRapor();
                fr29.Show();
            }
            
        }


        Formlar.FrmAnaSayfa fr;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmAnaSayfa();
                fr.MdiParent = this;
                fr.Show();
            }

        }
        private void btnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmAnaSayfa();
                fr.MdiParent = this;
                fr.Show();
            }
        }
        Formlar.FrmRehber fr30;
        private void btnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr30 == null || fr30.IsDisposed)
            {
                fr30 = new Formlar.FrmRehber();
                fr30.MdiParent = this;
                fr30.Show();
            }
        }
        Formlar.FrmGelenMesajlar fr31;
        private void btnGelenmesajlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr31 == null || fr31.IsDisposed)
            {
                fr31 = new Formlar.FrmGelenMesajlar();
                fr31.MdiParent = this;
                fr31.Show();
            }
        }
        Formlar.FrmMail fr32;
        private void btnMailGönder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr32 == null || fr31.IsDisposed)
            {
                fr32 = new Formlar.FrmMail();
                fr32.Show();
            }
        }

        

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmQrTaratma fr33 = new Formlar.FrmQrTaratma();
            fr33.Show();
        }
    }
}
