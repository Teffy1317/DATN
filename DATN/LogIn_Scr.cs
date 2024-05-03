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
    public partial class LogIn_Scr : Form
    {
        public LogIn_Scr()
        {
            InitializeComponent();
            this.ControlBox = false;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            switch(txtUserName.Text+txtPassword.Text)
            {
                case "Teffy2313":
                    {
                        GlobalVariables.btnEnable = true;
                        GlobalVariables.selectUsers = 1;
                        MessageBox.Show(" Welcome Teffy!", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        break;
                    }
                case "Anne1317":
                    {
                        GlobalVariables.btnEnable = true;
                        GlobalVariables.selectUsers = 2;
                        MessageBox.Show(" Welcome Anne!", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        break;
                    }
                case "Taylor13":
                    {
                        GlobalVariables.btnEnable = true;
                        GlobalVariables.selectUsers = 3;
                        MessageBox.Show(" Welcome Taylor!", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        break;
                    }
                default:
                    {
                        MessageBox.Show(" Your UserName or Password is incorrect. Try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void LogIn_Scr_Load(object sender, EventArgs e)
        {

        }
    }
}
