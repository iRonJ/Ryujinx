<<<<<<< HEAD
using Ryujinx.Graphics.Device;
=======
﻿using Ryujinx.Graphics.Device;
using Ryujinx.Graphics.Gpu.Synchronization;
>>>>>>> 1ec71635b (sync with main branch)
using System.Collections.Generic;
using System.Threading;

namespace Ryujinx.Graphics.Host1x
{
    public class Host1xClass : IDeviceState
    {
<<<<<<< HEAD
        private readonly ISynchronizationManager _syncMgr;
        private readonly DeviceState<Host1xClassRegisters> _state;

        public Host1xClass(ISynchronizationManager syncMgr)
=======
        private readonly SynchronizationManager _syncMgr;
        private readonly DeviceState<Host1xClassRegisters> _state;

        public Host1xClass(SynchronizationManager syncMgr)
>>>>>>> 1ec71635b (sync with main branch)
        {
            _syncMgr = syncMgr;
            _state = new DeviceState<Host1xClassRegisters>(new Dictionary<string, RwCallback>
            {
<<<<<<< HEAD
                { nameof(Host1xClassRegisters.WaitSyncpt32), new RwCallback(WaitSyncpt32, null) },
=======
                { nameof(Host1xClassRegisters.WaitSyncpt32), new RwCallback(WaitSyncpt32, null) }
>>>>>>> 1ec71635b (sync with main branch)
            });
        }

        public int Read(int offset) => _state.Read(offset);
        public void Write(int offset, int data) => _state.Write(offset, data);

        private void WaitSyncpt32(int data)
        {
            uint syncpointId = (uint)(data & 0xFF);
            uint threshold = _state.State.LoadSyncptPayload32;

            _syncMgr.WaitOnSyncpoint(syncpointId, threshold, Timeout.InfiniteTimeSpan);
        }
    }
}
