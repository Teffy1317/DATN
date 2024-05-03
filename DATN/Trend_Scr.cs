using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DATN
{
    public partial class Trend_Scr : Form
    {
        public Trend_Scr()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.Title = "Time";
            chart1.ChartAreas[0].AxisY.Title = "Quantity";
        }

        private void Trend_Scr_Load(object sender, EventArgs e)
        {
            btnTrend.Enabled = false;
        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            Windows_colection.system_window.Show();
            this.Hide();
        }
        private void btnUser_Click(object sender, EventArgs e)
        {
              Windows_colection.user_window.Show();
              this.Hide();
        }
        private void btnOPCUA_Click(object sender, EventArgs e)
        {
            Windows_colection.opcUA_window.Show();
            this.Hide();
        }
        private void btnDecode_Click(object sender, EventArgs e)
        {
            Windows_colection.decode_window.Show();
            this.Hide();
        }
        private void btnParamater_Click(object sender, EventArgs e)
        {
            Windows_colection.parameter_window.Show();
            this.Hide();
        }

        private void btnDatabase_Click(object sender, EventArgs e)
        {
            Windows_colection.Database_window.Show();
            this.Hide();
        }

        private void btnAlarm_Click(object sender, EventArgs e)
        {
            Windows_colection.alarm_window.Show();
            this.Hide();
        }

        private void btnTrend_Click(object sender, EventArgs e)
        {
         //   Windows_colection.trend_window.Show();
         //   this.Hide();
        }

        private void picHomeDoubleClick(object sender, MouseEventArgs e)
        {
            this.Hide();
        }

        int tempT1 = 0;
        int tempT2 = 0;
        int tempT3 = 0;
        int tempTu = 0;

        private void tTrendView_Tick(object sender, EventArgs e)
        {
            this.chart1.Series["Type_1"].Points.AddXY(DateTime.Now.ToString(), GlobalVariables.opcReadCounterType1 - tempT1);
            this.chart1.Series["Type_2"].Points.AddXY(DateTime.Now.ToString(), GlobalVariables.opcReadCounterType2 - tempT2);
            this.chart1.Series["Type_3"].Points.AddXY(DateTime.Now.ToString(), GlobalVariables.opcReadCounterType3 - tempT3);
            this.chart1.Series["Type_Unknow"].Points.AddXY(DateTime.Now.ToString(), GlobalVariables.opcReadCounterTypeBad - tempTu);
            tempT1 = GlobalVariables.opcReadCounterType1;
            tempT2 = GlobalVariables.opcReadCounterType2;
            tempT3 = GlobalVariables.opcReadCounterType3;
            tempTu = GlobalVariables.opcReadCounterTypeBad;
        }
    }
}
