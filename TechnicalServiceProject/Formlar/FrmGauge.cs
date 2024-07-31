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
    public partial class FrmGauge : Form
    {
        public FrmGauge()
        {
            InitializeComponent();
        }

        private void FrmGauge_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            arcScaleComponent1.Value += 5;
            if (arcScaleComponent1.Value == 100)
            {
                timer1.Stop();
                timer2.Start();
            }
            arcScaleComponent3.Value += 5;
            labelComponent1.Text=arcScaleComponent3.Value.ToString();
            arcScaleComponent4.Value += 5;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            arcScaleComponent1.Value -= 5;
            arcScaleComponent3.Value -= 5;
            arcScaleComponent4.Value -= 5;

            labelComponent1.Text = arcScaleComponent3.Value.ToString();
            if (arcScaleComponent1.Value == 0)
            {
                timer1.Start();
                timer2.Stop();
            }
        }

        
    }
}
