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
    public partial class Parameter_Scr : Form
    {
        public Parameter_Scr()
        {
            InitializeComponent();
            this.ControlBox = false;
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
         //   Windows_colection.parameter_window.Show();
         //   this.Hide();
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
            Windows_colection.trend_window.Show();
            this.Hide();
        }

        private void Parameter_Scr_Load(object sender, EventArgs e)
        {
            btnParamater.Enabled = false;
        }

        private void tQuantityProduct_Tick(object sender, EventArgs e)
        {
            txtQuantityType1.Text = GlobalVariables.opcReadCounterType1.ToString();
            txtQuantityType2.Text = GlobalVariables.opcReadCounterType2.ToString();
            txtQuantityType3.Text = GlobalVariables.opcReadCounterType3.ToString();
            txtQuantityTypeBad.Text = GlobalVariables.opcReadCounterTypeBad.ToString();
            txtQuantityTotal.Text = (GlobalVariables.opcReadCounterType1 + GlobalVariables.opcReadCounterType2 + GlobalVariables.opcReadCounterType3 + GlobalVariables.opcReadCounterTypeBad).ToString();

            if (GlobalVariables.opcReadModeAuto)
                lbMode.Text = "automatic operation mode";
            else if (GlobalVariables.opcReadModeMaunual)
                lbMode.Text = "manual operation mode";
            else
                lbMode.Text = "......";
        }

        private void btnResetCounter_Click(object sender, EventArgs e)
        {
            DialogResult result= MessageBox.Show("Are you sure to reset all counters?", "Question?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                GlobalVariables.opcWriteResetCounter = true;
            else
                GlobalVariables.opcWriteResetCounter = false;

        }

        private void picHomeDoubleClick(object sender, MouseEventArgs e)
        {
            this.Hide();
        }

    }
}
