<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Host1x
{
    struct Host1xClassRegisters
    {
<<<<<<< HEAD
#pragma warning disable CS0649 // Field is never assigned to
=======
#pragma warning disable CS0649
>>>>>>> 1ec71635b (sync with main branch)
        public uint IncrSyncpt;
        public uint IncrSyncptCntrl;
        public uint IncrSyncptError;
        public Array5<uint> ReservedC;
        public uint WaitSyncpt;
        public uint WaitSyncptBase;
        public uint WaitSyncptIncr;
        public uint LoadSyncptBase;
        public uint IncrSyncptBase;
        public uint Clear;
        public uint Wait;
        public uint WaitWithIntr;
        public uint DelayUsec;
        public uint TickcountHi;
        public uint TickcountLo;
        public uint Tickctrl;
        public Array23<uint> Reserved50;
        public uint Indctrl;
        public uint Indoff2;
        public uint Indoff;
        public Array31<uint> Inddata;
        public uint Reserved134;
        public uint LoadSyncptPayload32;
        public uint Stallctrl;
        public uint WaitSyncpt32;
        public uint WaitSyncptBase32;
        public uint LoadSyncptBase32;
        public uint IncrSyncptBase32;
        public uint StallcountHi;
        public uint StallcountLo;
        public uint Xrefctrl;
        public uint ChannelXrefHi;
        public uint ChannelXrefLo;
#pragma warning restore CS0649
    }
}
