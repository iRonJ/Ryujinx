<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.Account.Acc.AsyncContext;
=======
﻿using Ryujinx.HLE.HOS.Services.Account.Acc.AsyncContext;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Account.Acc
{
    class IAsyncNetworkServiceLicenseKindContext : IAsyncContext
    {
<<<<<<< HEAD
        private readonly NetworkServiceLicenseKind? _serviceLicenseKind;
=======
        private NetworkServiceLicenseKind? _serviceLicenseKind;
>>>>>>> 1ec71635b (sync with main branch)

        public IAsyncNetworkServiceLicenseKindContext(AsyncExecution asyncExecution, NetworkServiceLicenseKind? serviceLicenseKind) : base(asyncExecution)
        {
            _serviceLicenseKind = serviceLicenseKind;
        }

        [CommandCmif(100)]
        // GetNetworkServiceLicenseKind() -> nn::account::NetworkServiceLicenseKind
        public ResultCode GetNetworkServiceLicenseKind(ServiceCtx context)
        {
            if (!AsyncExecution.IsInitialized)
            {
                return ResultCode.AsyncExecutionNotInitialized;
            }

            if (!AsyncExecution.SystemEvent.ReadableEvent.IsSignaled())
            {
                return ResultCode.Unknown41;
            }

            if (!_serviceLicenseKind.HasValue)
            {
                return ResultCode.MissingNetworkServiceLicenseKind;
            }

            context.ResponseData.Write((uint)_serviceLicenseKind.Value);

            return ResultCode.Success;
        }
    }
}
