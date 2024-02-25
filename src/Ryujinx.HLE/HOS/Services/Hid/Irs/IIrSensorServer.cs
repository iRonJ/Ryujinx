using Ryujinx.Common;
using Ryujinx.Common.Logging;
using Ryujinx.HLE.HOS.Ipc;
using Ryujinx.HLE.HOS.Services.Hid.HidServer;
using Ryujinx.HLE.HOS.Services.Hid.Irs.Types;
using Ryujinx.Horizon.Common;
using System;

namespace Ryujinx.HLE.HOS.Services.Hid.Irs
{
    [Service("irs")]
    class IIrSensorServer : IpcService
    {
        private int _irsensorSharedMemoryHandle = 0;

        public IIrSensorServer(ServiceCtx context) { }

        [CommandCmif(302)]
        // ActivateIrsensor(nn::applet::AppletResourceUserId, pid)
        public ResultCode ActivateIrsensor(ServiceCtx context)
        {
            ulong appletResourceUserId = context.RequestData.ReadUInt64();

            // NOTE: This seems to initialize the shared memory for irs service.

            Logger.Stub?.PrintStub(LogClass.ServiceIrs, new { appletResourceUserId });

            return ResultCode.Success;
        }

        [CommandCmif(303)]
        // DeactivateIrsensor(nn::applet::AppletResourceUserId, pid)
        public ResultCode DeactivateIrsensor(ServiceCtx context)
        {
            ulong appletResourceUserId = context.RequestData.ReadUInt64();

            // NOTE: This seems to deinitialize the shared memory for irs service.

            Logger.Stub?.PrintStub(LogClass.ServiceIrs, new { appletResourceUserId });

            return ResultCode.Success;
        }

        [CommandCmif(304)]
        // GetIrsensorSharedMemoryHandle(nn::applet::AppletResourceUserId, pid) -> handle<copy>
        public ResultCode GetIrsensorSharedMemoryHandle(ServiceCtx context)
        {
            // NOTE: Shared memory should use the appletResourceUserId.
            // ulong appletResourceUserId = context.RequestData.ReadUInt64();

            if (_irsensorSharedMemoryHandle == 0)
            {
                if (context.Process.HandleTable.GenerateHandle(context.Device.System.IirsSharedMem, out _irsensorSharedMemoryHandle) != Result.Success)
                {
                    throw new InvalidOperationException("Out of handles!");
                }
            }

            context.Response.HandleDesc = IpcHandleDesc.MakeCopy(_irsensorSharedMemoryHandle);

            return ResultCode.Success;
        }

        [CommandCmif(305)]
        // StopImageProcessor(pid, nn::irsensor::IrCameraHandle, nn::applet::AppletResourceUserId)
        public ResultCode StopImageProcessor(ServiceCtx context)
        {
<<<<<<< HEAD
            IrCameraHandle irCameraHandle = context.RequestData.ReadStruct<IrCameraHandle>();
            ulong appletResourceUserId = context.RequestData.ReadUInt64();
=======
            IrCameraHandle irCameraHandle       = context.RequestData.ReadStruct<IrCameraHandle>();
            ulong          appletResourceUserId = context.RequestData.ReadUInt64();
>>>>>>> 1ec71635b (sync with main branch)

            CheckCameraHandle(irCameraHandle);

            Logger.Stub?.PrintStub(LogClass.ServiceIrs, new { appletResourceUserId, irCameraHandle.PlayerNumber, irCameraHandle.DeviceType });

            return ResultCode.Success;
        }

        [CommandCmif(306)]
        // RunMomentProcessor(pid, nn::irsensor::IrCameraHandle, nn::applet::AppletResourceUserId, PackedMomentProcessorConfig)
        public ResultCode RunMomentProcessor(ServiceCtx context)
        {
<<<<<<< HEAD
            IrCameraHandle irCameraHandle = context.RequestData.ReadStruct<IrCameraHandle>();
            ulong appletResourceUserId = context.RequestData.ReadUInt64();
            var packedMomentProcessorConfig = context.RequestData.ReadStruct<PackedMomentProcessorConfig>();
=======
            IrCameraHandle irCameraHandle              = context.RequestData.ReadStruct<IrCameraHandle>();
            ulong          appletResourceUserId        = context.RequestData.ReadUInt64();
            var            packedMomentProcessorConfig = context.RequestData.ReadStruct<PackedMomentProcessorConfig>();
>>>>>>> 1ec71635b (sync with main branch)

            CheckCameraHandle(irCameraHandle);

            Logger.Stub?.PrintStub(LogClass.ServiceIrs, new { appletResourceUserId, irCameraHandle.PlayerNumber, irCameraHandle.DeviceType, packedMomentProcessorConfig.ExposureTime });

            return ResultCode.Success;
        }

        [CommandCmif(307)]
        // RunClusteringProcessor(pid, nn::irsensor::IrCameraHandle, nn::applet::AppletResourceUserId, PackedClusteringProcessorConfig)
        public ResultCode RunClusteringProcessor(ServiceCtx context)
        {
<<<<<<< HEAD
            IrCameraHandle irCameraHandle = context.RequestData.ReadStruct<IrCameraHandle>();
            ulong appletResourceUserId = context.RequestData.ReadUInt64();
            var packedClusteringProcessorConfig = context.RequestData.ReadStruct<PackedClusteringProcessorConfig>();
=======
            IrCameraHandle irCameraHandle                  = context.RequestData.ReadStruct<IrCameraHandle>();
            ulong          appletResourceUserId            = context.RequestData.ReadUInt64();
            var            packedClusteringProcessorConfig = context.RequestData.ReadStruct<PackedClusteringProcessorConfig>();
>>>>>>> 1ec71635b (sync with main branch)

            CheckCameraHandle(irCameraHandle);

            Logger.Stub?.PrintStub(LogClass.ServiceIrs, new { appletResourceUserId, irCameraHandle.PlayerNumber, irCameraHandle.DeviceType, packedClusteringProcessorConfig.ExposureTime });

            return ResultCode.Success;
        }

        [CommandCmif(308)]
        // RunImageTransferProcessor(pid, nn::irsensor::IrCameraHandle, nn::applet::AppletResourceUserId, PackedImageTransferProcessorConfig, u64 TransferMemorySize, TransferMemoryHandle)
        public ResultCode RunImageTransferProcessor(ServiceCtx context)
        {
<<<<<<< HEAD
            IrCameraHandle irCameraHandle = context.RequestData.ReadStruct<IrCameraHandle>();
            ulong appletResourceUserId = context.RequestData.ReadUInt64();
            var packedImageTransferProcessorConfig = context.RequestData.ReadStruct<PackedImageTransferProcessorConfig>();
=======
            IrCameraHandle irCameraHandle                     = context.RequestData.ReadStruct<IrCameraHandle>();
            ulong          appletResourceUserId               = context.RequestData.ReadUInt64();
            var            packedImageTransferProcessorConfig = context.RequestData.ReadStruct<PackedImageTransferProcessorConfig>();
>>>>>>> 1ec71635b (sync with main branch)

            CheckCameraHandle(irCameraHandle);

            // TODO: Handle the Transfer Memory.

            Logger.Stub?.PrintStub(LogClass.ServiceIrs, new { appletResourceUserId, irCameraHandle.PlayerNumber, irCameraHandle.DeviceType, packedImageTransferProcessorConfig.ExposureTime });

            return ResultCode.Success;
        }

        [CommandCmif(309)]
        // GetImageTransferProcessorState(pid, nn::irsensor::IrCameraHandle, nn::applet::AppletResourceUserId)
        public ResultCode GetImageTransferProcessorState(ServiceCtx context)
        {
<<<<<<< HEAD
            IrCameraHandle irCameraHandle = context.RequestData.ReadStruct<IrCameraHandle>();
            ulong appletResourceUserId = context.RequestData.ReadUInt64();
=======
            IrCameraHandle irCameraHandle       = context.RequestData.ReadStruct<IrCameraHandle>();
            ulong          appletResourceUserId = context.RequestData.ReadUInt64();
>>>>>>> 1ec71635b (sync with main branch)

            // ulong imageTransferBufferAddress = context.Request.ReceiveBuff[0].Position;
            ulong imageTransferBufferSize = context.Request.ReceiveBuff[0].Size;

            if (imageTransferBufferSize == 0)
            {
                return ResultCode.InvalidBufferSize;
            }

            CheckCameraHandle(irCameraHandle);

            Logger.Stub?.PrintStub(LogClass.ServiceIrs, new { appletResourceUserId, irCameraHandle.PlayerNumber, irCameraHandle.DeviceType });

            // TODO: Uses the buffer to copy the JoyCon IR data (by using a JoyCon driver) and update the following struct.
            context.ResponseData.WriteStruct(new ImageTransferProcessorState()
            {
<<<<<<< HEAD
                SamplingNumber = 0,
                AmbientNoiseLevel = 0,
=======
                SamplingNumber    = 0,
                AmbientNoiseLevel = 0
>>>>>>> 1ec71635b (sync with main branch)
            });

            return ResultCode.Success;
        }

        [CommandCmif(310)]
        // RunTeraPluginProcessor(pid, nn::irsensor::IrCameraHandle, nn::applet::AppletResourceUserId, PackedTeraPluginProcessorConfig)
        public ResultCode RunTeraPluginProcessor(ServiceCtx context)
        {
<<<<<<< HEAD
            IrCameraHandle irCameraHandle = context.RequestData.ReadStruct<IrCameraHandle>();
            ulong appletResourceUserId = context.RequestData.ReadUInt64();
            var packedTeraPluginProcessorConfig = context.RequestData.ReadStruct<PackedTeraPluginProcessorConfig>();
=======
            IrCameraHandle irCameraHandle                  = context.RequestData.ReadStruct<IrCameraHandle>();
            ulong          appletResourceUserId            = context.RequestData.ReadUInt64();
            var            packedTeraPluginProcessorConfig = context.RequestData.ReadStruct<PackedTeraPluginProcessorConfig>();
>>>>>>> 1ec71635b (sync with main branch)

            CheckCameraHandle(irCameraHandle);

            Logger.Stub?.PrintStub(LogClass.ServiceIrs, new { appletResourceUserId, irCameraHandle.PlayerNumber, irCameraHandle.DeviceType, packedTeraPluginProcessorConfig.RequiredMcuVersion });

            return ResultCode.Success;
        }

        [CommandCmif(311)]
        // GetNpadIrCameraHandle(u32) -> nn::irsensor::IrCameraHandle
        public ResultCode GetNpadIrCameraHandle(ServiceCtx context)
        {
            NpadIdType npadIdType = (NpadIdType)context.RequestData.ReadUInt32();

<<<<<<< HEAD
            if (npadIdType > NpadIdType.Player8 &&
=======
            if (npadIdType >  NpadIdType.Player8 &&
>>>>>>> 1ec71635b (sync with main branch)
                npadIdType != NpadIdType.Unknown &&
                npadIdType != NpadIdType.Handheld)
            {
                return ResultCode.NpadIdOutOfRange;
            }

            PlayerIndex irCameraHandle = HidUtils.GetIndexFromNpadIdType(npadIdType);

            context.ResponseData.Write((int)irCameraHandle);

            // NOTE: If the irCameraHandle pointer is null this error is returned, Doesn't occur in our case.
            //       return ResultCode.HandlePointerIsNull;

            return ResultCode.Success;
        }

        [CommandCmif(314)] // 3.0.0+
        // CheckFirmwareVersion(nn::irsensor::IrCameraHandle, nn::irsensor::PackedMcuVersion, nn::applet::AppletResourceUserId, pid)
        public ResultCode CheckFirmwareVersion(ServiceCtx context)
        {
<<<<<<< HEAD
            int irCameraHandle = context.RequestData.ReadInt32();
            short packedMcuVersionMajor = context.RequestData.ReadInt16();
            short packedMcuVersionMinor = context.RequestData.ReadInt16();
            long appletResourceUserId = context.RequestData.ReadInt64();
=======
            int   irCameraHandle        = context.RequestData.ReadInt32();
            short packedMcuVersionMajor = context.RequestData.ReadInt16();
            short packedMcuVersionMinor = context.RequestData.ReadInt16();
            long  appletResourceUserId  = context.RequestData.ReadInt64();
>>>>>>> 1ec71635b (sync with main branch)

            Logger.Stub?.PrintStub(LogClass.ServiceIrs, new { appletResourceUserId, irCameraHandle, packedMcuVersionMajor, packedMcuVersionMinor });

            return ResultCode.Success;
        }

        [CommandCmif(318)] // 4.0.0+
        // StopImageProcessorAsync(nn::irsensor::IrCameraHandle, nn::applet::AppletResourceUserId, pid)
        public ResultCode StopImageProcessorAsync(ServiceCtx context)
        {
<<<<<<< HEAD
            int irCameraHandle = context.RequestData.ReadInt32();
=======
            int  irCameraHandle       = context.RequestData.ReadInt32();
>>>>>>> 1ec71635b (sync with main branch)
            long appletResourceUserId = context.RequestData.ReadInt64();

            Logger.Stub?.PrintStub(LogClass.ServiceIrs, new { appletResourceUserId, irCameraHandle });

            return ResultCode.Success;
        }

        [CommandCmif(319)] // 4.0.0+
        // ActivateIrsensorWithFunctionLevel(nn::applet::AppletResourceUserId, nn::irsensor::PackedFunctionLevel, pid)
        public ResultCode ActivateIrsensorWithFunctionLevel(ServiceCtx context)
        {
            long appletResourceUserId = context.RequestData.ReadInt64();
<<<<<<< HEAD
            long packedFunctionLevel = context.RequestData.ReadInt64();
=======
            long packedFunctionLevel  = context.RequestData.ReadInt64();
>>>>>>> 1ec71635b (sync with main branch)

            Logger.Stub?.PrintStub(LogClass.ServiceIrs, new { appletResourceUserId, packedFunctionLevel });

            return ResultCode.Success;
        }

        private ResultCode CheckCameraHandle(IrCameraHandle irCameraHandle)
        {
            if (irCameraHandle.DeviceType == 1 || (PlayerIndex)irCameraHandle.PlayerNumber >= PlayerIndex.Unknown)
            {
                return ResultCode.InvalidCameraHandle;
            }

            return ResultCode.Success;
        }
    }
}
