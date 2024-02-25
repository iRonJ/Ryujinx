using Ryujinx.HLE.HOS.Services.Pctl.ParentalControlServiceFactory;

namespace Ryujinx.HLE.HOS.Services.Pctl
{
<<<<<<< HEAD
    [Service("pctl", 0x303)]
=======
    [Service("pctl",   0x303)]
>>>>>>> 1ec71635b (sync with main branch)
    [Service("pctl:a", 0x83BE)]
    [Service("pctl:r", 0x8040)]
    [Service("pctl:s", 0x838E)]
    class IParentalControlServiceFactory : IpcService
    {
<<<<<<< HEAD
        private readonly int _permissionFlag;
=======
        private int _permissionFlag;
>>>>>>> 1ec71635b (sync with main branch)

        public IParentalControlServiceFactory(ServiceCtx context, int permissionFlag)
        {
            _permissionFlag = permissionFlag;
        }

        [CommandCmif(0)]
        // CreateService(u64, pid) -> object<nn::pctl::detail::ipc::IParentalControlService>
        public ResultCode CreateService(ServiceCtx context)
        {
            ulong pid = context.Request.HandleDesc.PId;

            MakeObject(context, new IParentalControlService(context, pid, true, _permissionFlag));

            return ResultCode.Success;
        }

        [CommandCmif(1)] // 4.0.0+
        // CreateServiceWithoutInitialize(u64, pid) -> object<nn::pctl::detail::ipc::IParentalControlService>
        public ResultCode CreateServiceWithoutInitialize(ServiceCtx context)
        {
            ulong pid = context.Request.HandleDesc.PId;

            MakeObject(context, new IParentalControlService(context, pid, false, _permissionFlag));

            return ResultCode.Success;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
