﻿using System;
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
    public partial class User_Scr : Form
    {
        public User_Scr()
        {
            InitializeComponent();
        }

        private void User_Scr_Load(object sender, EventArgs e)
        {
            btnUser.Enabled = false;
        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            Windows_colection.system_window.Show();
            this.Hide();
        }
        private void btnUser_Click(object sender, EventArgs e)
        {
          //  Windows_colection.user_window.Show();
          //  this.Hide();
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

        private void picHomeDoubleClick(object sender, MouseEventArgs e)
        {
            this.Hide();
        }


    }
}
