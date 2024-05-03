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
    public partial class Main_Scr : Form
    {
 
        public Main_Scr()
        {
            InitializeComponent();
            GlobalVariables.InitializeVariables();
            Windows_colection.InitializeWindows();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Main_Scr_Load(object sender, EventArgs e)
        {
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            LogIn_Scr f = new LogIn_Scr();
            f.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to exit?", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result==DialogResult.OK)
            {
                GlobalVariables.btnEnable = false;
            }
        }

        private void tBtnEnabled_Tick(object sender, EventArgs e)
        {
            if(GlobalVariables.btnEnable==true)
            {
                btnLogIn.Enabled = false;
                btnUser.Enabled = true;
                btnSystem.Enabled = true;
                btnOPCUA.Enabled = true;
                btnDecode.Enabled = true;
                btnParamater.Enabled = true;
                btnDatabase.Enabled = true;
                btnAlarm.Enabled = true;
                btnTrend.Enabled = true;
                btnLogOut.Enabled = true;
            }
            else
            {
                btnLogIn.Enabled = true;
                btnUser.Enabled = false;
                btnSystem.Enabled = false;
                btnOPCUA.Enabled = false;
                btnDecode.Enabled = false;
                btnParamater.Enabled = false;
                btnDatabase.Enabled = false;
                btnAlarm.Enabled = false;
                btnTrend.Enabled = false;
                btnLogOut.Enabled = false;
            }
        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            Windows_colection.open_window((sender as Button).Text);
        }
        private void btnUser_Click(object sender, EventArgs e)
        {
            Windows_colection.open_window((sender as Button).Text);            
        }
        private void btnOPCUA_Click(object sender, EventArgs e)
        {
            Windows_colection.open_window((sender as Button).Text);
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            Windows_colection.open_window((sender as Button).Text);
        }

        private void btnParamater_Click(object sender, EventArgs e)
        {
            Windows_colection.open_window((sender as Button).Text);
        }

        private void btnDatabase_Click(object sender, EventArgs e)
        {
            Windows_colection.open_window((sender as Button).Text);
        }

        private void btnAlarm_Click(object sender, EventArgs e)
        {
            Windows_colection.open_window((sender as Button).Text);
        }

        private void btnTrend_Click(object sender, EventArgs e)
        {
            Windows_colection.open_window((sender as Button).Text);
        }


    }
}
