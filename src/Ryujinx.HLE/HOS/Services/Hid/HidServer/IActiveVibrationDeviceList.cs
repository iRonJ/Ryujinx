namespace Ryujinx.HLE.HOS.Services.Hid.HidServer
{
    class IActiveApplicationDeviceList : IpcService
    {
        public IActiveApplicationDeviceList() { }

        [CommandCmif(0)]
        // ActivateVibrationDevice(nn::hid::VibrationDeviceHandle)
        public ResultCode ActivateVibrationDevice(ServiceCtx context)
        {
<<<<<<< HEAD
#pragma warning disable IDE0059 // Remove unnecessary value assignment
            int vibrationDeviceHandle = context.RequestData.ReadInt32();
#pragma warning restore IDE0059
=======
            int vibrationDeviceHandle = context.RequestData.ReadInt32();
>>>>>>> 1ec71635b (sync with main branch)

            return ResultCode.Success;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
