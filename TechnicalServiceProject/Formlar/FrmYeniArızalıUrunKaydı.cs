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
    public partial class FrmYeniArızalıUrunKaydı : Form
    {
        public FrmYeniArızalıUrunKaydı()
        {
            InitializeComponent();
        }
        TeknikServisDBEntities db = new TeknikServisDBEntities();
        private void btnMusteri_Click(object sender, EventArgs e)
        {
            var verigetir = db.TBLProductMovement.SingleOrDefault(x => x.URUNSERINO == TxtSeri.Text);
            if (verigetir != null)
            {
                TxtMusterı.Text = verigetir.TBLCari.ID.ToString();
                TxtPersonel.Text=verigetir.TBLPersonnel.ID.ToString();

            }
            else
            {
                 MessageBox.Show("Seri numarasına ait satış bulunamadı","Bilgi",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLProductAcceptance a = new TBLProductAcceptance();
            a.CARI=int.Parse(TxtMusterı.Text);
            a.PERSONEL=short.Parse(TxtPersonel.Text);
            a.GELISTARIHI = DateTime.Parse(TxtTarih.Text);
            a.URUNSERINO = TxtSeri.Text;
            db.TBLProductAcceptance.Add(a);
            db.SaveChanges();
            MessageBox.Show("Arıza kaydı başarıyla gerçekleşti.");
            this.Close();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            DialogResult vazgec = MessageBox.Show("Arıza Kaydı işleminden vazgeçmek istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (vazgec == System.Windows.Forms.DialogResult.Yes)

            {

                this.Close();

            }
        }
    }
}
