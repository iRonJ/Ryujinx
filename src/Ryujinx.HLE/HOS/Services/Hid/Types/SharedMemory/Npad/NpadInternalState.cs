<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Common;
=======
﻿using Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Common;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Npad
{
    struct NpadInternalState
    {
        public NpadStyleTag StyleSet;
        public NpadJoyAssignmentMode JoyAssignmentMode;
        public NpadFullKeyColorState FullKeyColor;
        public NpadJoyColorState JoyColor;
        public RingLifo<NpadCommonState> FullKey;
        public RingLifo<NpadCommonState> Handheld;
        public RingLifo<NpadCommonState> JoyDual;
        public RingLifo<NpadCommonState> JoyLeft;
        public RingLifo<NpadCommonState> JoyRight;
        public RingLifo<NpadCommonState> Palma;
        public RingLifo<NpadCommonState> SystemExt;
        public RingLifo<SixAxisSensorState> FullKeySixAxisSensor;
        public RingLifo<SixAxisSensorState> HandheldSixAxisSensor;
        public RingLifo<SixAxisSensorState> JoyDualSixAxisSensor;
        public RingLifo<SixAxisSensorState> JoyDualRightSixAxisSensor;
        public RingLifo<SixAxisSensorState> JoyLeftSixAxisSensor;
        public RingLifo<SixAxisSensorState> JoyRightSixAxisSensor;
        public DeviceType DeviceType;
<<<<<<< HEAD
#pragma warning disable IDE0051 // Remove unused private member
        private readonly uint _reserved1;
#pragma warning restore IDE0051
=======
        private uint _reserved1;
>>>>>>> 1ec71635b (sync with main branch)
        public NpadSystemProperties SystemProperties;
        public NpadSystemButtonProperties SystemButtonProperties;
        public NpadBatteryLevel BatteryLevelJoyDual;
        public NpadBatteryLevel BatteryLevelJoyLeft;
        public NpadBatteryLevel BatteryLevelJoyRight;
        public uint AppletFooterUiAttributes;
        public AppletFooterUiType AppletFooterUiType;
<<<<<<< HEAD
#pragma warning disable IDE0051 // Remove unused private member
        private readonly Reserved2Struct _reserved2;
#pragma warning restore IDE0051
=======
        private Reserved2Struct _reserved2;
>>>>>>> 1ec71635b (sync with main branch)
        public RingLifo<NpadGcTriggerState> GcTrigger;
        public NpadLarkType LarkTypeLeftAndMain;
        public NpadLarkType LarkTypeRight;
        public NpadLuciaType LuciaType;
        public uint Unknown43EC;

        [StructLayout(LayoutKind.Sequential, Size = 123, Pack = 1)]
<<<<<<< HEAD
        private struct Reserved2Struct { }
=======
        private struct Reserved2Struct {}
>>>>>>> 1ec71635b (sync with main branch)

        public static NpadInternalState Create()
        {
            return new NpadInternalState
            {
                FullKey = RingLifo<NpadCommonState>.Create(),
                Handheld = RingLifo<NpadCommonState>.Create(),
                JoyDual = RingLifo<NpadCommonState>.Create(),
                JoyLeft = RingLifo<NpadCommonState>.Create(),
                JoyRight = RingLifo<NpadCommonState>.Create(),
                Palma = RingLifo<NpadCommonState>.Create(),
                SystemExt = RingLifo<NpadCommonState>.Create(),
                FullKeySixAxisSensor = RingLifo<SixAxisSensorState>.Create(),
                HandheldSixAxisSensor = RingLifo<SixAxisSensorState>.Create(),
                JoyDualSixAxisSensor = RingLifo<SixAxisSensorState>.Create(),
                JoyDualRightSixAxisSensor = RingLifo<SixAxisSensorState>.Create(),
                JoyLeftSixAxisSensor = RingLifo<SixAxisSensorState>.Create(),
                JoyRightSixAxisSensor = RingLifo<SixAxisSensorState>.Create(),
                GcTrigger = RingLifo<NpadGcTriggerState>.Create(),
            };
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
