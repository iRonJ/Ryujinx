using Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Common;
using Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.DebugPad;

namespace Ryujinx.HLE.HOS.Services.Hid
{
    public class DebugPadDevice : BaseDevice
    {
        public DebugPadDevice(Switch device, bool active) : base(device, active) { }

        public void Update()
        {
            ref RingLifo<DebugPadState> lifo = ref _device.Hid.SharedMemory.DebugPad;

            ref DebugPadState previousEntry = ref lifo.GetCurrentEntryRef();

<<<<<<< HEAD
            DebugPadState newState = new();
=======
            DebugPadState newState = new DebugPadState();
>>>>>>> 1ec71635b (sync with main branch)

            if (Active)
            {
                // TODO: This is a debug device only present in dev environment, do we want to support it?
            }

            newState.SamplingNumber = previousEntry.SamplingNumber + 1;

            lifo.Write(ref newState);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
