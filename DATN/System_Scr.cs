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
    public partial class System_Scr : Form
    {
        public System_Scr()
        {
            InitializeComponent();
        }

        private void System_Scr_Load(object sender, EventArgs e)
        {
            btnSystem.Enabled = false;
            rBtnNull.Checked = true;
            rSwEmerDeact.Checked = true;
            
        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
         //   Windows_colection.system_window.Show();
         //   this.Hide();
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
            Windows_colection.trend_window.Show();
            this.Hide();
        }

        private void rBtnManual_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVariables.opcWriteModeMaunual = true;
            GlobalVariables.opcWriteModeAuto = false;
        }

        private void rBtnAuto_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVariables.opcWriteModeMaunual = false;
            GlobalVariables.opcWriteModeAuto = true;
        }

        private void rBtnNull_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVariables.opcWriteModeMaunual = false;
            GlobalVariables.opcWriteModeAuto = false;
        }

        private void btnStartStpAuto_Down(object sender, MouseEventArgs e)
        {
            GlobalVariables.opcWriteStartStopAuto = true;
        }

        private void btnStartStpAuto_Up(object sender, MouseEventArgs e)
        {
            GlobalVariables.opcWriteStartStopAuto = false;
        }

        private void btnReset_Down(object sender, MouseEventArgs e)
        {
            GlobalVariables.opcWriteReset = true;
        }

        private void btnReset_Up(object sender, MouseEventArgs e)
        {
            GlobalVariables.opcWriteReset = false;
        }

        private void rSwEmerAct_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVariables.opcWriteEmergency = false;
        }

        private void rSwEmerDeact_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVariables.opcWriteEmergency = true;
        }

        static byte ctBtnConveyor1 = 0;
        static byte ctBtnConveyor2 = 0;
        static byte ctBtnConveyor3 = 0;
        static byte ctBtnConveyorC = 0;
        static byte ctBtnConveyorTr = 0;

        private void btnPusher1_Click(object sender, EventArgs e)
        {
            GlobalVariables.opcWritePusher1 = true;
        }

        private void btnPusher2_Click(object sender, EventArgs e)
        {
            GlobalVariables.opcWritePusher2 = true;
        }

        private void btnPusher3_Click(object sender, EventArgs e)
        {
            GlobalVariables.opcWritePusher3 = true;
        }

        private void btnConveyor1_Click(object sender, EventArgs e)
        {
            ctBtnConveyor1++;
            if((ctBtnConveyor1%2)==1)
            {
                GlobalVariables.opcWriteConveyor1 = true;
                btnConveyor1.ForeColor = Color.Yellow;
            }
            else
            {
                GlobalVariables.opcWriteConveyor1 = false;
                btnConveyor1.ForeColor = Color.Honeydew;
            }
        }

        private void btnConveyor2_Click(object sender, EventArgs e)
        {
            ctBtnConveyor2++;
            if ((ctBtnConveyor2 % 2) == 1)
            {
                GlobalVariables.opcWriteConveyor2 = true;
                btnConveyor2.ForeColor = Color.Yellow;
            }
            else
            {
                GlobalVariables.opcWriteConveyor2 = false;
                btnConveyor2.ForeColor = Color.Honeydew;
            }
        }

        private void btnConveyor3_Click(object sender, EventArgs e)
        {
            ctBtnConveyor3++;
            if ((ctBtnConveyor3 % 2) == 1)
            {
                GlobalVariables.opcWriteConveyor3 = true;
                btnConveyor3.ForeColor = Color.Yellow;
            }
            else
            {
                GlobalVariables.opcWriteConveyor3 = false;
                btnConveyor3.ForeColor = Color.Honeydew;
            }
        }

        private void btnConveyorC_Click(object sender, EventArgs e)
        {
            ctBtnConveyorC++;
            if ((ctBtnConveyorC % 2) == 1)
            {
                GlobalVariables.opcWriteConveyorC = true;
                btnConveyorC.ForeColor = Color.Yellow;
            }
            else
            {
                GlobalVariables.opcWriteConveyorC = false;
                btnConveyorC.ForeColor = Color.Honeydew;
            }
        }

        private void btnConveyorTr_Click(object sender, EventArgs e)
        {
            ctBtnConveyorTr++;
            if ((ctBtnConveyorTr % 2) == 1)
            {
                GlobalVariables.opcWriteConveyorTr = true;
                btnConveyorTr.ForeColor = Color.Yellow;
            }
            else
            {
                GlobalVariables.opcWriteConveyorTr = false;
                btnConveyorTr.ForeColor = Color.Honeydew;
            }
        }

        private void tLightState_Tick(object sender, EventArgs e)
        {
           if (GlobalVariables.opcReadStateReady==true)
                lightStateReady.BackColor = Color.Lime;
            else
                lightStateReady.BackColor = Color.Gray;

            if (GlobalVariables.opcReadStateRunning==true)
                lightStateRunning.BackColor = Color.Yellow;
            else
                lightStateRunning.BackColor = Color.Gray;

            if (GlobalVariables.opcReadStateFauted==true)
                lightStateFaulted.BackColor = Color.Red;
            else
                lightStateFaulted.BackColor = Color.Gray;

            if (GlobalVariables.opcReadStateReset==true)
                lightStateReset.BackColor = Color.Yellow;
            else
                lightStateReset.BackColor = Color.Gray;

            if (GlobalVariables.opcReadStateDeath==true)
                lightStateDeath.BackColor = Color.Maroon;
            else
                lightStateDeath.BackColor = Color.Gray; 

            if(GlobalVariables.opcReadModeMaunual==true)
            {
                rBtnManual.ForeColor = Color.Lime;
                rBtnAuto.ForeColor = Color.Wheat;
            }
            else if (GlobalVariables.opcReadModeAuto==true)
            {
                rBtnManual.ForeColor = Color.Wheat;
                rBtnAuto.ForeColor = Color.Lime;
            }
            else
            {
                rBtnManual.ForeColor = Color.Wheat;
                rBtnAuto.ForeColor = Color.Wheat;
            }

            if (GlobalVariables.opcWritePusher1 == true)
                btnPusher1.ForeColor = Color.Lime;
            else
                btnPusher1.ForeColor = Color.Honeydew;

            if (GlobalVariables.opcWritePusher2 == true)
                btnPusher2.ForeColor = Color.Lime;
            else
                btnPusher2.ForeColor = Color.Honeydew;

            if (GlobalVariables.opcWritePusher3 == true)
                btnPusher3.ForeColor = Color.Lime;
            else
                btnPusher3.ForeColor = Color.Honeydew;
        }


        private void picHomeDoubleClick(object sender, MouseEventArgs e)
        {
            this.Hide();
        }


    }
}
