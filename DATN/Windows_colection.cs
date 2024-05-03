using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN
{
    class Windows_colection
    {
        public static OpcUA_Scr opcUA_window { get; set; }
        public static Decode_Scr decode_window { get; set; }
        public static System_Scr system_window { get; set; }
        public static User_Scr user_window { get; set; }
        public static Parameter_Scr parameter_window { get; set; }
        public static Database_Scr Database_window { get; set; }
        public static Alarm_Scr alarm_window { get; set; }
        public static Trend_Scr trend_window { get; set; }



        public static void InitializeWindows()
        {
            opcUA_window = new OpcUA_Scr();
            decode_window = new Decode_Scr();
            system_window = new System_Scr();
            user_window = new User_Scr();
            parameter_window = new Parameter_Scr();
            Database_window = new Database_Scr();
            alarm_window = new Alarm_Scr();
            trend_window = new Trend_Scr();
        }

        public static void open_window(string name)
        {
            switch (name)
            {
                case "USER":
                    user_window.Show();
                    break;
                case "SYSTEM":
                    system_window.Show();
                    break;
                case "OPC UA":
                    opcUA_window.Show();
                    break;
                case "DECODE":
                    decode_window.Show();
                    break;
                case "PARAMETER":
                    parameter_window.Show();
                    break;
                case "DATABASE":
                    decode_window.Show();
                    break;
                case "ALARM":
                    alarm_window.Show();
                    break;
                case "TREND":
                    trend_window.Show();
                    break;
            }
        }
        
    }
}
