using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.Ua;
using Opc.Ua.Client;
using OpcUaHelper;
using System.Windows.Forms;

namespace DATN
{
    public partial class OpcUA_Scr : Form
    {
        OpcUaClient myClient = new OpcUaClient();
        public OpcUA_Scr()
        {
            InitializeComponent();
            myClient.UserIdentity = new UserIdentity(new AnonymousIdentityToken());
        }

        private void OpcUA_Scr_Load(object sender, EventArgs e)
        {
            btnOPCUA.Enabled = false;
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
          //  Windows_colection.opcUA_window.Show();
          //  this.Hide();
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

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string opcUrl = txtOpcUrl.Text;
            if(opcUrl != "")
            {
                try
                {
                    myClient.ConnectServer(opcUrl);
                    if (myClient.Connected)
                    {
                        btnConnect.Enabled = false;
                        btnDisconnect.Enabled = true;
                        MessageBox.Show("Connected Successfully!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Connection Failed!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Failed!" + ex.ToString(), "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Enter the Opc Url!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            myClient.Disconnect();
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
        }

        private void tStatus_Tick(object sender, EventArgs e)
        {
            if (myClient.Connected)
            {
                lbStatus.Text = "Good";
                GlobalVariables.opcWriteQualityConnected = true;
            }    
            else
            {
                lbStatus.Text = "Bad";
                GlobalVariables.opcWriteQualityConnected = false;
            }
            
            if(myClient.Connected)
            {
                try
                {
                    myClient.WriteNode("ns=4;i=47", GlobalVariables.opcWriteQualityConnected);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data Quality Connected cannot be write" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void tWriteType_Tick(object sender, EventArgs e)
        {
            if(myClient.Connected)
            {
                try
                {
                    myClient.WriteNode("ns=4;i=30", GlobalVariables.opcWriteType);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data Type cannot be write" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void tWriteQualityCamera_Tick(object sender, EventArgs e)
        {
            if(myClient.Connected)
            {
                try
                {
                    myClient.WriteNode("ns=4;i=31", GlobalVariables.opcWriteQualityCamera);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data Quality Camera cannot be write" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tReadCounterType_Tick(object sender, EventArgs e)
        {
            if(myClient.Connected)
            {
                try
                {
                    var counterType_1 = myClient.ReadNode("ns=4;i=34");
                    var counterType_2 = myClient.ReadNode("ns=4;i=35");
                    var counterType_3 = myClient.ReadNode("ns=4;i=36");
                    var counterType_Bad = myClient.ReadNode("ns=4;i=48");
                    GlobalVariables.opcReadCounterType1 = Convert.ToByte(counterType_1.Value);
                    GlobalVariables.opcReadCounterType2 = Convert.ToByte(counterType_2.Value);
                    GlobalVariables.opcReadCounterType3 = Convert.ToByte(counterType_3.Value);
                    GlobalVariables.opcReadCounterTypeBad = Convert.ToByte(counterType_Bad.Value); 
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Data Counter Type cannot be read " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }



        private void tWriteManualConveyor_Tick(object sender, EventArgs e)
        {
            if (GlobalVariables.opcWriteConveyor1 == true)
                lbConveyor1.Text = "ON";
            else
                lbConveyor1.Text = "OFF";

            if (GlobalVariables.opcWriteConveyor2 == true)
                lbConveyor2.Text = "ON";
            else
                lbConveyor2.Text = "OFF";

            if (GlobalVariables.opcWriteConveyor3 == true)
                lbConveyor3.Text = "ON";
            else
                lbConveyor3.Text = "OFF";

            if (GlobalVariables.opcWriteConveyorTr == true)
                lbConveyorTr.Text = "ON";
            else
                lbConveyorTr.Text = "OFF";

            if (GlobalVariables.opcWriteConveyorC == true)
                lbConveyorC.Text = "ON";
            else
                lbConveyorC.Text = "OFF";
        } 

        private void lbConveyorC_Changed(object sender, EventArgs e)
        {
            if (myClient.Connected)
            {
                try
                {
                    myClient.WriteNode("ns=4;i=26", GlobalVariables.opcWriteConveyorC);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data signal Conveyor Classification cannot be write" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lbConveyorTr_Changed(object sender, EventArgs e)
        {
            if (myClient.Connected)
            {
                try
                {
                    myClient.WriteNode("ns=4;i=25", GlobalVariables.opcWriteConveyorTr);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data signal Conveyor Transport cannot be write" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lbConveyor3_Changed(object sender, EventArgs e)
        {
            if (myClient.Connected)
            {
                try
                {
                    myClient.WriteNode("ns=4;i=24", GlobalVariables.opcWriteConveyor3);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data signal Conveyor 3 cannot be write" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lbConveyor2_Changed(object sender, EventArgs e)
        {
            if (myClient.Connected)
            {
                try
                {
                    myClient.WriteNode("ns=4;i=23", GlobalVariables.opcWriteConveyor2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data signal Conveyor 2 cannot be write" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lbConveyor1_Changed(object sender, EventArgs e)
        {
            if (myClient.Connected)
            {
                try
                {
                    myClient.WriteNode("ns=4;i=22", GlobalVariables.opcWriteConveyor1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data signal Conveyor 1 cannot be write" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
        }

        private void tWriteManualPusher_Tick(object sender, EventArgs e)
        {
            if (GlobalVariables.opcWritePusher1 == true)
                lbPusher1.Text = "PUSH";
            else
                lbPusher1.Text = "POP";

            if (GlobalVariables.opcWritePusher2 == true)
                lbPusher2.Text = "PUSH";
            else
                lbPusher2.Text = "POP";

            if (GlobalVariables.opcWritePusher3 == true)
                lbPusher3.Text = "PUSH";
            else
                lbPusher3.Text = "POP";
        }
        private void lbPusher1_Changed(object sender, EventArgs e)
        {
            if (myClient.Connected)
            {
                try
                {
                    myClient.WriteNode("ns=4;i=27", GlobalVariables.opcWritePusher1);
                    GlobalVariables.opcWritePusher1 = false;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data signal Pusher 1 cannot be write" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lbPusher2_Changed(object sender, EventArgs e)
        {
            if (myClient.Connected)
            {
                try
                {
                    myClient.WriteNode("ns=4;i=28", GlobalVariables.opcWritePusher2);
                    GlobalVariables.opcWritePusher2 = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data signal Pusher 2 cannot be write" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lbPusher3_Changed(object sender, EventArgs e)
        {
            if (myClient.Connected)
            {
                try
                {
                    myClient.WriteNode("ns=4;i=29", GlobalVariables.opcWritePusher3);
                    GlobalVariables.opcWritePusher3 = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data signal Pusher 3 cannot be write" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tWriteSigAuto_Tick(object sender, EventArgs e)
        {
            if (GlobalVariables.opcWriteStartStopAuto == true)
                lbStartStopAuto.Text = "Press";
            else
                lbStartStopAuto.Text = "Release";

            if (GlobalVariables.opcWriteReset == true)
                lbReset.Text = "Press";
            else
                lbReset.Text = "Release";

            if (GlobalVariables.opcWriteEmergency == true)
                lbEmergency.Text = "Activated";
            else
                lbEmergency.Text = "Deactivated";
        }

        private void lbStartStopAuto_Changed(object sender, EventArgs e)
        {
            if(myClient.Connected)
            {
                try
                {
                    myClient.WriteNode("ns=4;i=19", GlobalVariables.opcWriteStartStopAuto);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Data signal Start/Stop cannot be write" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lbReset_Changed(object sender, EventArgs e)
        {
            if (myClient.Connected)
            {
                try
                {
                    myClient.WriteNode("ns=4;i=20", GlobalVariables.opcWriteReset);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data signal Reset cannot be write" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lbEmergency_Changed(object sender, EventArgs e)
        {
            if (myClient.Connected)
            {
                try
                {
                    myClient.WriteNode("ns=4;i=21", GlobalVariables.opcWriteEmergency);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data signal Emergency cannot be write" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void tWriteMode_Tick(object sender, EventArgs e)
        {
            if (GlobalVariables.opcWriteModeMaunual == true)
                lbManual.Text = "ON";
            else
                lbManual.Text = "OFF";

            if (GlobalVariables.opcWriteModeAuto == true)
                lbAuto.Text = "ON";
            else
                lbAuto.Text = "OFF";
        }
        private void lbManual_Changed(object sender, EventArgs e)
        {
            if (myClient.Connected)
            {
                try
                {
                    myClient.WriteNode("ns=4;i=17", GlobalVariables.opcWriteModeMaunual);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data Mode manual cannot be write" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lbAuto_Changed(object sender, EventArgs e)
        {
            if (myClient.Connected)
            {
                try
                {
                    myClient.WriteNode("ns=4;i=18", GlobalVariables.opcWriteModeAuto);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data Mode auto cannot be write" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tReadState_Tick(object sender, EventArgs e)
        {
            if (myClient.Connected)
            {
                try
                {
                    var stateReady = myClient.ReadNode("ns=4;i=38");
                    GlobalVariables.opcReadStateReady = Convert.ToBoolean(stateReady.Value);

                    var stateRunning = myClient.ReadNode("ns=4;i=39");
                    GlobalVariables.opcReadStateRunning = Convert.ToBoolean(stateRunning.Value);

                    var stateFauted = myClient.ReadNode("ns=4;i=40");
                    GlobalVariables.opcReadStateFauted = Convert.ToBoolean(stateFauted.Value);

                    var stateReset = myClient.ReadNode("ns=4;i=41");
                    GlobalVariables.opcReadStateReset = Convert.ToBoolean(stateReset.Value);

                    var stateDeath = myClient.ReadNode("ns=4;i=42");
                    GlobalVariables.opcReadStateDeath = Convert.ToBoolean(stateDeath.Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data State cannot be read!" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };
            }
        }

        private void tReadCamera_Tick(object sender, EventArgs e)
        {
            if (myClient.Connected)
            {
                try
                {
                    var requestCamera = myClient.ReadNode("ns=4;i=33");
                    string yeh = requestCamera.ToString();
                    if (yeh == "True")
                        GlobalVariables.opcReadRequestCamera = true;
                    else
                        GlobalVariables.opcReadRequestCamera = false;
                    if (GlobalVariables.opcReadRequestCamera)
                    {
                        lbRequestCamera.Text = "ON";
                    }
                    else
                    {
                        lbRequestCamera.Text = "OFF";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data request camera cannot be read!" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };
            }
        }

        private void lbResetCounterChanged(object sender, EventArgs e)
        {
            if (myClient.Connected)
            {
                try
                {
                    myClient.WriteNode("ns=4;i=45", GlobalVariables.opcWriteResetCounter);
                    GlobalVariables.opcWriteResetCounter = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data Reset counter cannot be write" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tWriteResetCounter_Tick(object sender, EventArgs e)
        {
            if (GlobalVariables.opcWriteResetCounter == true)
                lbResetCounter.Text = "True";
            else
                lbResetCounter.Text = "False";
        }

        private void tReadFaulted_Tick(object sender, EventArgs e)
        {
            if (myClient.Connected)
            {
                try
                {
                    var TypeFaulted = myClient.ReadNode("ns=4;i=46");

                    GlobalVariables.opcReadTypeFaulted = Convert.ToByte(TypeFaulted.Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data Type Faulted cannot be read " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void tReadMode_Tick(object sender, EventArgs e)
        {
            if (myClient.Connected)
            {
                try
                {
                    var ReadModeManual = myClient.ReadNode("ns=4;i=44");
                    GlobalVariables.opcReadModeMaunual = Convert.ToBoolean(ReadModeManual.Value);

                    var ReadModeAuto = myClient.ReadNode("ns=4;i=43");
                    GlobalVariables.opcReadModeAuto = Convert.ToBoolean(ReadModeAuto.Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data mode cannot be read " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void picHomeDoubleClick(object sender, MouseEventArgs e)
        {
            this.Hide();
        }


    }
}
