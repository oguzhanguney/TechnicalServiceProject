namespace TechnicalServiceProject.Formlar
{
    partial class FrmArizaDetaylar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmArizaDetaylar));
            this.BtnGuncel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.TxtDetay = new System.Windows.Forms.RichTextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.TxtSerino = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.TxtTarih = new DevExpress.XtraEditors.TextEdit();
            this.BtnVazgec = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSerino.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTarih.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnGuncel
            // 
            this.BtnGuncel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnKaydet.ImageOptions.Image")));
            this.BtnGuncel.Location = new System.Drawing.Point(197, 204);
            this.BtnGuncel.Name = "BtnGuncel";
            this.BtnGuncel.Size = new System.Drawing.Size(131, 36);
            this.BtnGuncel.TabIndex = 4;
            this.BtnGuncel.Text = "GÜNCELLE";
            this.BtnGuncel.Click += new System.EventHandler(this.BtnGuncel_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(197, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(252, 25);
            this.labelControl1.TabIndex = 44;
            this.labelControl1.Text = "ARIZALI ÜRÜN KAYDI DETAY";
            // 
            // TxtDetay
            // 
            this.TxtDetay.Location = new System.Drawing.Point(222, 97);
            this.TxtDetay.Name = "TxtDetay";
            this.TxtDetay.Size = new System.Drawing.Size(401, 95);
            this.TxtDetay.TabIndex = 3;
            this.TxtDetay.Text = "";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(38, 74);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 17);
            this.labelControl2.TabIndex = 46;
            this.labelControl2.Text = "SERİ NO";
            // 
            // TxtSerino
            // 
            this.TxtSerino.Location = new System.Drawing.Point(38, 97);
            this.TxtSerino.Name = "TxtSerino";
            this.TxtSerino.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.TxtSerino.Properties.MaskSettings.Set("MaskManagerSignature", "ignoreMaskBlank=True");
            this.TxtSerino.Properties.MaskSettings.Set("mask", "AAAAA");
            this.TxtSerino.Size = new System.Drawing.Size(137, 20);
            this.TxtSerino.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(222, 74);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(101, 17);
            this.labelControl3.TabIndex = 48;
            this.labelControl3.Text = "ARIZA DETAYLARI";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(38, 149);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(35, 17);
            this.labelControl4.TabIndex = 49;
            this.labelControl4.Text = "TARİH";
            // 
            // TxtTarih
            // 
            this.TxtTarih.Location = new System.Drawing.Point(38, 172);
            this.TxtTarih.Name = "TxtTarih";
            this.TxtTarih.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.DateTimeMaskManager));
            this.TxtTarih.Properties.MaskSettings.Set("mask", "d");
            this.TxtTarih.Size = new System.Drawing.Size(137, 20);
            this.TxtTarih.TabIndex = 2;
            // 
            // BtnVazgec
            // 
            this.BtnVazgec.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnVazgec.ImageOptions.SvgImage")));
            this.BtnVazgec.Location = new System.Drawing.Point(335, 204);
            this.BtnVazgec.Name = "BtnVazgec";
            this.BtnVazgec.Size = new System.Drawing.Size(126, 36);
            this.BtnVazgec.TabIndex = 5;
            this.BtnVazgec.Text = "VAZGEÇ";
            // 
            // FrmArizaDetaylar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(647, 269);
            this.Controls.Add(this.BtnVazgec);
            this.Controls.Add(this.TxtTarih);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.TxtSerino);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.TxtDetay);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.BtnGuncel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmArizaDetaylar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmArizaDetaylar";
            ((System.ComponentModel.ISupportInitialize)(this.TxtSerino.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTarih.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnGuncel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.RichTextBox TxtDetay;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit TxtSerino;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit TxtTarih;
        private DevExpress.XtraEditors.SimpleButton BtnVazgec;
    }
}