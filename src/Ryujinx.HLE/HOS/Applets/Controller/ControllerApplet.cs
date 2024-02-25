using Ryujinx.Common.Logging;
using Ryujinx.Common.Memory;
using Ryujinx.HLE.HOS.Services.Am.AppletAE;
using Ryujinx.HLE.HOS.Services.Hid;
using Ryujinx.HLE.HOS.Services.Hid.Types;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static Ryujinx.HLE.HOS.Services.Hid.HidServer.HidUtils;

namespace Ryujinx.HLE.HOS.Applets
{
    internal class ControllerApplet : IApplet
    {
<<<<<<< HEAD
        private readonly Horizon _system;
=======
        private Horizon _system;
>>>>>>> 1ec71635b (sync with main branch)

        private AppletSession _normalSession;

        public event EventHandler AppletStateChanged;

        public ControllerApplet(Horizon system)
        {
            _system = system;
        }

        public ResultCode Start(AppletSession normalSession, AppletSession interactiveSession)
        {
            _normalSession = normalSession;

            byte[] launchParams = _normalSession.Pop();
            byte[] controllerSupportArgPrivate = _normalSession.Pop();
            ControllerSupportArgPrivate privateArg = IApplet.ReadStruct<ControllerSupportArgPrivate>(controllerSupportArgPrivate);

            Logger.Stub?.PrintStub(LogClass.ServiceHid, $"ControllerApplet ArgPriv {privateArg.PrivateSize} {privateArg.ArgSize} {privateArg.Mode} " +
                        $"HoldType:{(NpadJoyHoldType)privateArg.NpadJoyHoldType} StyleSets:{(ControllerType)privateArg.NpadStyleSet}");

            if (privateArg.Mode != ControllerSupportMode.ShowControllerSupport)
            {
                _normalSession.Push(BuildResponse()); // Dummy response for other modes
                AppletStateChanged?.Invoke(this, null);

                return ResultCode.Success;
            }

            byte[] controllerSupportArg = _normalSession.Pop();

            ControllerSupportArgHeader argHeader;

            if (privateArg.ArgSize == Marshal.SizeOf<ControllerSupportArgV7>())
            {
                ControllerSupportArgV7 arg = IApplet.ReadStruct<ControllerSupportArgV7>(controllerSupportArg);
                argHeader = arg.Header;

                Logger.Stub?.PrintStub(LogClass.ServiceHid, $"ControllerSupportArg Version 7 EnableExplainText={arg.EnableExplainText != 0}");
                // Read enable text here?
            }
            else if (privateArg.ArgSize == Marshal.SizeOf<ControllerSupportArgVPre7>())
            {
                ControllerSupportArgVPre7 arg = IApplet.ReadStruct<ControllerSupportArgVPre7>(controllerSupportArg);
                argHeader = arg.Header;

                Logger.Stub?.PrintStub(LogClass.ServiceHid, $"ControllerSupportArg Version Pre-7 EnableExplainText={arg.EnableExplainText != 0}");
                // Read enable text here?
            }
            else
            {
<<<<<<< HEAD
                Logger.Stub?.PrintStub(LogClass.ServiceHid, "ControllerSupportArg Version Unknown");
=======
                Logger.Stub?.PrintStub(LogClass.ServiceHid, $"ControllerSupportArg Version Unknown");
>>>>>>> 1ec71635b (sync with main branch)

                argHeader = IApplet.ReadStruct<ControllerSupportArgHeader>(controllerSupportArg); // Read just the header
            }

            int playerMin = argHeader.PlayerCountMin;
            int playerMax = argHeader.PlayerCountMax;
            bool singleMode = argHeader.EnableSingleMode != 0;

            Logger.Stub?.PrintStub(LogClass.ServiceHid, $"ControllerApplet Arg {playerMin} {playerMax} {argHeader.EnableTakeOverConnection} {argHeader.EnableSingleMode}");

            if (singleMode)
            {
                // Applications can set an arbitrary player range even with SingleMode, so clamp it
                playerMin = playerMax = 1;
            }

<<<<<<< HEAD
            int configuredCount;
            PlayerIndex primaryIndex;
            while (!_system.Device.Hid.Npads.Validate(playerMin, playerMax, (ControllerType)privateArg.NpadStyleSet, out configuredCount, out primaryIndex))
            {
                ControllerAppletUIArgs uiArgs = new()
=======
            int configuredCount = 0;
            PlayerIndex primaryIndex = PlayerIndex.Unknown;
            while (!_system.Device.Hid.Npads.Validate(playerMin, playerMax, (ControllerType)privateArg.NpadStyleSet, out configuredCount, out primaryIndex))
            {
                ControllerAppletUiArgs uiArgs = new ControllerAppletUiArgs
>>>>>>> 1ec71635b (sync with main branch)
                {
                    PlayerCountMin = playerMin,
                    PlayerCountMax = playerMax,
                    SupportedStyles = (ControllerType)privateArg.NpadStyleSet,
                    SupportedPlayers = _system.Device.Hid.Npads.GetSupportedPlayers(),
<<<<<<< HEAD
                    IsDocked = _system.State.DockedMode,
                };

                if (!_system.Device.UIHandler.DisplayMessageDialog(uiArgs))
=======
                    IsDocked = _system.State.DockedMode
                };

                if (!_system.Device.UiHandler.DisplayMessageDialog(uiArgs))
>>>>>>> 1ec71635b (sync with main branch)
                {
                    break;
                }
            }

<<<<<<< HEAD
            ControllerSupportResultInfo result = new()
            {
                PlayerCount = (sbyte)configuredCount,
                SelectedId = (uint)GetNpadIdTypeFromIndex(primaryIndex),
=======
            ControllerSupportResultInfo result = new ControllerSupportResultInfo
            {
                PlayerCount = (sbyte)configuredCount,
                SelectedId = (uint)GetNpadIdTypeFromIndex(primaryIndex)
>>>>>>> 1ec71635b (sync with main branch)
            };

            Logger.Stub?.PrintStub(LogClass.ServiceHid, $"ControllerApplet ReturnResult {result.PlayerCount} {result.SelectedId}");

            _normalSession.Push(BuildResponse(result));
            AppletStateChanged?.Invoke(this, null);

            _system.ReturnFocus();

            return ResultCode.Success;
        }

        public ResultCode GetResult()
        {
            return ResultCode.Success;
        }

<<<<<<< HEAD
        private static byte[] BuildResponse(ControllerSupportResultInfo result)
        {
            using MemoryStream stream = MemoryStreamManager.Shared.GetStream();
            using BinaryWriter writer = new(stream);

            writer.Write(MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(ref result, Unsafe.SizeOf<ControllerSupportResultInfo>())));

            return stream.ToArray();
        }

        private static byte[] BuildResponse()
        {
            using MemoryStream stream = MemoryStreamManager.Shared.GetStream();
            using BinaryWriter writer = new(stream);

            writer.Write((ulong)ResultCode.Success);

            return stream.ToArray();
=======
        private byte[] BuildResponse(ControllerSupportResultInfo result)
        {
            using (MemoryStream stream = MemoryStreamManager.Shared.GetStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(ref result, Unsafe.SizeOf<ControllerSupportResultInfo>())));

                return stream.ToArray();
            }
        }

        private byte[] BuildResponse()
        {
            using (MemoryStream stream = MemoryStreamManager.Shared.GetStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write((ulong)ResultCode.Success);

                return stream.ToArray();
            }
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
