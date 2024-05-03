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
    public partial class Alarm_Scr : Form
    {
        private int rowCount = 0;
        public Alarm_Scr()
        {
            InitializeComponent();
            dataGridViewAlarmTable.Font = new Font("Times New Roman", 20);
            dataGridViewAlarmTable.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn col in dataGridViewAlarmTable.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }    
          /*  dataGridViewAlarmTable.Columns.Add("colErrorName", "Error Name");
            dataGridViewAlarmTable.Columns.Add("colDescription", "Description");
            dataGridViewAlarmTable.Columns.Add("colTime", "Time"); */
        } 

        private void AddRow(int index, string errorName, string description, DateTime time)
        {
            dataGridViewAlarmTable.Rows.Add(index, errorName, description, time);
        }
        
        private void Alarm_Scr_Load(object sender, EventArgs e)
        {
            btnAlarm.Enabled = false;
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
         //   Windows_colection.alarm_window.Show();
         //   this.Hide();
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

        private void tUpdateAlarmTable_Tick(object sender, EventArgs e)
        {
            lbFaultedNo.Text = GlobalVariables.opcReadTypeFaulted.ToString();
        }

        private void lbFaultedNoChanged(object sender, EventArgs e)
        {
            if (GlobalVariables.opcReadTypeFaulted == 0)
            {

            }
            else
            {
                rowCount++;
                DateTime currentTime = DateTime.Now;
                MessageBox.Show(" The system error occurred", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                switch (GlobalVariables.opcReadTypeFaulted)
                {
                    case 1:
                        AddRow(rowCount, "Error 01", "Cylinder 1 has trouble pushing", currentTime);
                        break;
                    case 2:
                        AddRow(rowCount, "Error 02", "Cylinder 2 has trouble pushing", currentTime);
                        break;
                    case 3:
                        AddRow(rowCount, "Error 03", "Cylinder 3 has trouble pushing", currentTime);
                        break;
                    case 4:
                        AddRow(rowCount, "Error 04", "Cylinder 1 has trouble pulling", currentTime);
                        break;
                    case 5:
                        AddRow(rowCount, "Error 05", "Cylinder 2 has trouble pulling", currentTime);
                        break;
                    case 6:
                        AddRow(rowCount, "Error 06", "Cylinder 3 has trouble pulling", currentTime);
                        break;
                    case 7:
                        AddRow(rowCount, "Error 07", "Misclassification of type 1 product", currentTime);
                        break;
                    case 8:
                        AddRow(rowCount, "Error 08", "Misclassification of type 2 product", currentTime);
                        break;
                    case 9:
                        AddRow(rowCount, "Error 09", "Misclassification of type 3 product", currentTime);
                        break;
                    case 10:
                        AddRow(rowCount, "Error 10", "Misclassification of type unknow product", currentTime);
                        break;
                    case 11:
                        AddRow(rowCount, "Error 11", "There are too many type unknow products in a row", currentTime);
                        break;
                    case 12:
                        AddRow(rowCount, "Error 12", "Lost connection between PLC and C# Scada when operating in automatic mode", currentTime);
                        break;
                    case 13:
                        AddRow(rowCount, "Error 13", "Lost connection between Camera and C# Scada when operating in automatic mode", currentTime);
                        break;
                    case 14:
                        AddRow(rowCount, "Error 14", "Lost connection between Camera, PLC and C# Scada when operating in automatic mode", currentTime);
                        break;
                    case 15:
                        AddRow(rowCount, "Error 15", "Lost connection between PLC and C# Scada when operating in manual mode", currentTime);
                        break;
                    default:
                        break;
                }
            }
        }


    }
}
