using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;
using AForge.Video;
using AForge.Video.DirectShow;

namespace DATN
{
    public partial class Decode_Scr : Form
    {
        public static int something { get; set; }
        private FilterInfoCollection cameras;
        private VideoCaptureDevice cam;

        private Dictionary<string, string> origin_dict = new Dictionary<string, string>();
        private Dictionary<string, string> destination_dict = new Dictionary<string, string>();
        private Dictionary<string, string> type_dict = new Dictionary<string, string>();

        private string UNKNOW_CODE = "Unknow";

        public Decode_Scr()
        {
            InitializeComponent();
            cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo info in cameras)
            {
                cbbCamera.Items.Add(info.Name);
            }
            
            //Khởi tạo các cặp giá trị cho origin_dict
            origin_dict.Add("VN","Vietnam");
            origin_dict.Add("TL", "Thailand");
            origin_dict.Add("NB", "Japan");
            origin_dict.Add("US","American");

            //Khỏi tạo các cặp giá trị cho destination_dict
            for (uint i = 1; i <=10; i++)
            {
                destination_dict.Add("0" + i.ToString(), i.ToString() + " Distric");
            }

            //Khởi tạo các cặp giá trị cho type_dict
            for(uint i = 1; i< 10; i++)
            {
                type_dict.Add("L" + i.ToString(), "Type " + i.ToString());
            }


        }

        private void Decode_Scr_Load(object sender, EventArgs e)
        {
            btnDecode.Enabled = false;
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
         //   Windows_colection.decode_window.Show();
         //   this.Hide();
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

        private void btnStartCam_Click(object sender, EventArgs e)
        {
            if(cbbCamera.Text =="Select Cameras")
            {
                MessageBox.Show("Please select camera", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(cam!= null && cam.IsRunning)
            {
                cam.Stop();
            }
            cam = new VideoCaptureDevice(cameras[cbbCamera.SelectedIndex].MonikerString);
            cam.NewFrame += Cam_NewFrame;
            cam.Start();
        }
        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            picCamera.Image = bitmap;
        }

        private void btnStopCam_Click(object sender, EventArgs e)
        {
            if(cam!=null && cam.IsRunning)
            {
                cam.Stop();
                picCamera.Image = null;
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if(cam!=null && cam.IsRunning)
            {
                cam.Stop();
                picCamera.Image = null;
            }
        }

        static string strQR;
        private void tDetectQrCode_Tick(object sender, EventArgs e)
        {
            if (picCamera.Image != null)
            {
                lbStatusCamera.Text = "Good";
                GlobalVariables.opcWriteQualityCamera = true;
                if(GlobalVariables.opcReadRequestCamera)
                {
                    var reader = new BarcodeReader();
                    var img = picCamera.Image as Bitmap;
                    var result = reader.Decode(img);
                    if (result != null)
                    {
                        lbProcess.Text = "Successful";
                        txtDecodeQR.Text = result.Text;
                        strQR = result.Text.ToString();
                        var options = new QrCodeEncodingOptions
                        {
                            Height = picQrCode.Height,
                            Width = picQrCode.Width
                        };
                        var writer = new BarcodeWriter();
                        writer.Format = BarcodeFormat.QR_CODE;
                        writer.Options = options;
                        var text = txtDecodeQR.Text;
                        var resultQR = writer.Write(text);
                        picQrCode.Image = resultQR;
                        cam.Stop();
                    }
                    else
                        lbProcess.Text = "Loading...";
                }
                else
                {
                    strQR = null;
                    txtDecodeQR.Text = null;
                  //  picCamera.Image = null;
                    cam.Start();
                    GlobalVariables.opcWriteType = 0; 
                }

            }
            else
            {
                lbStatusCamera.Text = "Bad";
                GlobalVariables.opcWriteQualityCamera = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            strQR = null;
            txtDecodeQR.Text = null;
            picCamera.Image = null;
            cam.Start();
        }

        static string str_origin, str_destination, str_type, str_date, str_day, str_month, str_year;

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void picHomeDoubleClick(object sender, MouseEventArgs e)
        {
            this.Hide();
        }

        private void lbStatusCamera_Click(object sender, EventArgs e)
        {

        }

        private void lbProcess_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void cbbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void picCamera_Click(object sender, EventArgs e)
        {

        }

        private void tItemInf_Tick(object sender, EventArgs e)
        {
            bool i1 = false, i2 = false, i3 = false, i4 = false, i6 = false;
            if(strQR!=null)
            {
                if(strQR.Length==12)
                {
                    str_origin = strQR.Substring(0, 2);
                    str_destination = strQR.Substring(2, 2);
                    str_type = strQR.Substring(4, 2);
                    str_year = strQR.Substring(6, 2);
                    str_month = strQR.Substring(8, 2);
                    str_day = strQR.Substring(10, 2);

                    int int_month = int.Parse(str_month);
                    int int_day = int.Parse(str_day);

                    if (origin_dict.ContainsKey(str_origin))
                    {
                        str_origin = origin_dict[str_origin];
                    }
                    else
                    {
                        str_origin = UNKNOW_CODE;
                        lbNotes_Origin.Text = UNKNOW_CODE;
                        i1 = true;
                    }

                    /*
                    switch(str_origin)
                    {
                        case "VN": str_origin = "Vietnam";
                            break;
                        case "TL": str_origin = "Thailand";
                            break;
                        case "NB": str_origin = "Japan";
                            break;
                        case "US": str_origin = "American";
                            break;
                        default:
                            {
                                str_origin = "!!!";
                                lbNotes_Origin.Text = "Unknow";
                                i1 = true;
                            }
                            break;
                    }
                    */

                    if (destination_dict.ContainsKey(str_destination))
                    {
                        str_destination = destination_dict[str_destination];
                    }
                    else
                    {
                        str_destination = UNKNOW_CODE;
                        lbNotes_Destination.Text = UNKNOW_CODE;
                        i2 = true;
                    }

                    /*
                    switch (str_destination)
                    {
                        case "01":
                            str_destination = "1 Distric";
                            break;
                        case "02":
                            str_destination = "2 Distric";
                            break;
                        case "03":
                            str_destination = "3 Distric";
                            break;
                        case "04":
                            str_destination = "4 Distric";
                            break;
                        case "10":
                            str_destination = "10 Distric";
                            break;
                        default:
                            {
                                str_destination = "!!!";
                                lbNotes_Destination.Text = "Unknow";
                                i2 = true;
                            }
                            break;
                    }
                    */

                    if (type_dict.ContainsKey(str_type))
                    {
                        GlobalVariables.opcWriteType = Convert.ToByte( type_dict.Keys.ToList().IndexOf(str_type) );
                        str_type = type_dict[str_type];
                    }
                    else
                    {
                        str_type = UNKNOW_CODE;
                        lbNote_Type.Text = UNKNOW_CODE;
                        i3 = true;
                    }

                    /*
                    switch (str_type)
                    {
                        case "L1":
                            str_type = "Type 1";
                            GlobalVariables.opcWriteType = 1;
                            break;
                        case "L2":
                            str_type = "Type 2";
                            GlobalVariables.opcWriteType = 2;
                            break;
                        case "L3":
                            str_type = "Type 3";
                            GlobalVariables.opcWriteType = 3;
                            break;
                        default:
                            {
                                str_type = "!!!";
                                lbNote_Type.Text = "Unknow";
                                i3 = true;
                            }
                            break;
                    }
                    */


                    if(int_day>=1 && int_day<=31 && int_month>=1 && int_month<=12)
                    {
                        str_date = "20" + str_year + "/" + str_month + "/" + str_day;
                    }
                    else
                    {
                        lbNotes_Date.Text = UNKNOW_CODE;
                        str_date = UNKNOW_CODE;
                        i4 = true;
                    }
                    txtInf_Origin.Text = str_origin.ToString();
                    txtInf_Destination.Text = str_destination.ToString();
                    txtInf_Type.Text = str_type.ToString();
                    txtInf_Date.Text = str_date.ToString();
                }
                else
                {
                    lbErrorQRCode.Text = "Error QR Code";
                    str_origin = null;
                    str_destination = null;
                    str_type = null;
                    str_date = null;
                    i6 = true;
                }
                if(i1 != true && i2 != true && i3 != true && i4 != true && i6 != true)
                {
                    txtInf_Result.Text = "Classify";
                    return;
                }
                else
                {
                    txtInf_Result.Text = "Cannot Classify";
                    GlobalVariables.opcWriteType = 4;
                    return;
                }
                string newdata = "{\"origin\": \"" + str_origin + "\", \"destination\": "+str_destination+", \"type\": "+str_type+", \"time_packaged\": "+str_date+"}";
                Database_Scr.InsertData(newdata, "products");
            }
            else
            {
                txtInf_Origin.Text = null;
                txtInf_Destination.Text = null;
                txtInf_Type.Text = null;
                txtInf_Date.Text = null;
                lbNotes_Origin.Text = null;
                lbNotes_Destination.Text = null;
                lbNote_Type.Text = null;
                lbNotes_Date.Text = null;
                lbErrorQRCode.Text = null;
                txtInf_Result.Text = null;
                GlobalVariables.opcWriteType = 0;
            }


        }
    }
}
