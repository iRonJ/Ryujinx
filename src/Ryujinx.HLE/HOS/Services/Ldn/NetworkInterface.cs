<<<<<<< HEAD
using Ryujinx.Common.Logging;
=======
﻿using Ryujinx.Common.Logging;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.HLE.HOS.Kernel.Threading;
using Ryujinx.HLE.HOS.Services.Ldn.Types;
using System.Net;

namespace Ryujinx.HLE.HOS.Services.Ldn
{
    internal class NetworkInterface
    {
<<<<<<< HEAD
        public ResultCode NifmState { get; set; }
        public KEvent StateChangeEvent { get; private set; }
=======
        public ResultCode NifmState        { get; set; }
        public KEvent     StateChangeEvent { get; private set; }
>>>>>>> 1ec71635b (sync with main branch)

        private NetworkState _state;

        public NetworkInterface(Horizon system)
        {
            // TODO(Ac_K): Determine where the internal state is set.
<<<<<<< HEAD
            NifmState = ResultCode.Success;
=======
            NifmState        = ResultCode.Success;
>>>>>>> 1ec71635b (sync with main branch)
            StateChangeEvent = new KEvent(system.KernelContext);

            _state = NetworkState.None;
        }

        public ResultCode Initialize(int unknown, int version, IPAddress ipv4Address, IPAddress subnetMaskAddress)
        {
            // TODO(Ac_K): Call nn::nifm::InitializeSystem().
            //             If the call failed, it returns the result code.
            //             If the call succeed, it signal and clear an event then start a new thread named nn.ldn.NetworkInterfaceMonitor.

            Logger.Stub?.PrintStub(LogClass.ServiceLdn, new { version });

            // NOTE: Since we don't support ldn for now, we can return this following result code to make it disabled.
            return ResultCode.DeviceDisabled;
        }

        public ResultCode GetState(out NetworkState state)
        {
            // Return ResultCode.InvalidArgument if _state is null, doesn't occur in our case.

            state = _state;

            return ResultCode.Success;
        }

        public ResultCode Finalize()
        {
            // TODO(Ac_K): Finalize nifm service then kill the thread named nn.ldn.NetworkInterfaceMonitor.

            _state = NetworkState.None;

            StateChangeEvent.WritableEvent.Signal();
            StateChangeEvent.WritableEvent.Clear();

            Logger.Stub?.PrintStub(LogClass.ServiceLdn);

            return ResultCode.Success;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
