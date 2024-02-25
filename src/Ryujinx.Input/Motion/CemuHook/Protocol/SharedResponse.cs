<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.Input.Motion.CemuHook.Protocol
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SharedResponse
    {
<<<<<<< HEAD
        public MessageType Type;
        public byte Slot;
        public SlotState State;
        public DeviceModelType ModelType;
        public ConnectionType ConnectionType;
=======
        public MessageType     Type;
        public byte            Slot;
        public SlotState       State;
        public DeviceModelType ModelType;
        public ConnectionType  ConnectionType;
>>>>>>> 1ec71635b (sync with main branch)

        public Array6<byte> MacAddress;
        public BatteryStatus BatteryStatus;
    }

    public enum SlotState : byte
    {
        Disconnected,
        Reserved,
<<<<<<< HEAD
        Connected,
=======
        Connected
>>>>>>> 1ec71635b (sync with main branch)
    }

    public enum DeviceModelType : byte
    {
        None,
        PartialGyro,
<<<<<<< HEAD
        FullGyro,
=======
        FullGyro
>>>>>>> 1ec71635b (sync with main branch)
    }

    public enum ConnectionType : byte
    {
        None,
        USB,
<<<<<<< HEAD
        Bluetooth,
=======
        Bluetooth
>>>>>>> 1ec71635b (sync with main branch)
    }

    public enum BatteryStatus : byte
    {
        NA,
        Dying,
        Low,
        Medium,
        High,
        Full,
        Charging,
<<<<<<< HEAD
        Charged,
    }
}
=======
        Charged
    }
}
>>>>>>> 1ec71635b (sync with main branch)
