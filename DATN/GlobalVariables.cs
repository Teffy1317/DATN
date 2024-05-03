using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN
{
    public class GlobalVariables
    {

        public static bool btnEnable { get; set; }
        public static bool opcReadRequestCamera { get; set; }
        public static byte opcWriteType { get; set; }
        public static bool opcWriteQualityCamera { get; set; }
        public static bool opcWriteQualityConnected { get; set; }
        public static byte opcReadCounterType1 { get; set; }
        public static byte opcReadCounterType2 { get; set; }
        public static byte opcReadCounterType3 { get; set; }
        public static byte opcReadCounterTypeBad { get; set; }
        public static byte selectUsers { get; set; }
        public static bool opcWriteModeMaunual { get; set; }
        public static bool opcWriteModeAuto { get; set; }
        public static bool opcWriteStartStopAuto { get; set; }
        public static bool opcWriteReset { get; set; }
        public static bool opcWriteEmergency { get; set; }
        public static bool opcWritePusher1 { get; set; }
        public static bool opcWritePusher2 { get; set; }
        public static bool opcWritePusher3 { get; set; }
        public static bool opcWriteConveyor1 { get; set; }
        public static bool opcWriteConveyor2 { get; set; }
        public static bool opcWriteConveyor3 { get; set; }
        public static bool opcWriteConveyorC { get; set; }
        public static bool opcWriteConveyorTr { get; set; }
        public static bool opcReadStateReady { get; set; }
        public static bool opcReadStateRunning { get; set; }
        public static bool opcReadStateFauted { get; set; }
        public static bool opcReadStateReset { get; set; }
        public static bool opcReadStateDeath { get; set; }
        public static bool opcWriteResetCounter { get; set; }
        public static byte opcReadTypeFaulted { get; set; }
        public static bool opcReadModeMaunual { get; set; }
        public static bool opcReadModeAuto { get; set; }




        public static void InitializeVariables()
        {
            btnEnable = false;

            opcReadRequestCamera = false;

            opcWriteType = 0;

            opcWriteQualityCamera = false;
            opcWriteQualityConnected = false;

            opcReadCounterType1 = 0;
            opcReadCounterType2 = 3;
            opcReadCounterType3 = 4;
            opcReadCounterTypeBad = 0;

            selectUsers = 0;

            opcWriteModeAuto = false;
            opcWriteModeMaunual = false;

            opcWriteStartStopAuto = false;
            opcWriteReset = false;
            opcWriteEmergency = false;

            opcWritePusher1 = false;
            opcWritePusher2 = false;
            opcWritePusher3 = false;

            opcWriteConveyor1 = false;
            opcWriteConveyor2 = false;
            opcWriteConveyor3 = false;
            opcWriteConveyorC = false;
            opcWriteConveyorTr = false;

            opcReadStateReady = false;
            opcReadStateReset = false;
            opcReadStateRunning = false;
            opcReadStateFauted = false;
            opcReadStateDeath = false;

            opcWriteResetCounter = false;
            opcReadTypeFaulted = 0;

            opcReadModeAuto = false;
            opcReadModeMaunual = false;
        }

        
    }
    
}
