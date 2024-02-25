<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.Input.Motion.CemuHook.Protocol
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct ControllerDataRequest
    {
        public MessageType Type;
        public SubscriberType SubscriberType;
        public byte Slot;
        public Array6<byte> MacAddress;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ControllerDataResponse
    {
        public SharedResponse Shared;
<<<<<<< HEAD
        public byte Connected;
        public uint PacketId;
        public byte ExtraButtons;
        public byte MainButtons;
        public ushort PSExtraInput;
        public ushort LeftStickXY;
        public ushort RightStickXY;
        public uint DPadAnalog;
        public ulong MainButtonsAnalog;
=======
        public byte           Connected;
        public uint           PacketId;
        public byte           ExtraButtons;
        public byte           MainButtons;
        public ushort         PSExtraInput;
        public ushort         LeftStickXY;
        public ushort         RightStickXY;
        public uint           DPadAnalog;
        public ulong          MainButtonsAnalog;
>>>>>>> 1ec71635b (sync with main branch)

        public Array6<byte> Touch1;
        public Array6<byte> Touch2;

        public ulong MotionTimestamp;
        public float AccelerometerX;
        public float AccelerometerY;
        public float AccelerometerZ;
        public float GyroscopePitch;
        public float GyroscopeYaw;
        public float GyroscopeRoll;
    }

    enum SubscriberType : byte
    {
        All,
        Slot,
<<<<<<< HEAD
        Mac,
    }
}
=======
        Mac
    }
}
>>>>>>> 1ec71635b (sync with main branch)
