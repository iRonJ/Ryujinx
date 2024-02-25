<<<<<<< HEAD
using MsgPack;
=======
﻿using MsgPack;
>>>>>>> 1ec71635b (sync with main branch)
using MsgPack.Serialization;
using Ryujinx.Common.Logging;
using Ryujinx.Common.Utilities;
using Ryujinx.Horizon.Common;
using Ryujinx.Horizon.Prepo.Types;
using Ryujinx.Horizon.Sdk.Account;
<<<<<<< HEAD
using Ryujinx.Horizon.Sdk.Arp;
=======
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Horizon.Sdk.Prepo;
using Ryujinx.Horizon.Sdk.Sf;
using Ryujinx.Horizon.Sdk.Sf.Hipc;
using System;
using System.Text;
<<<<<<< HEAD
using ApplicationId = Ryujinx.Horizon.Sdk.Ncm.ApplicationId;
=======
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Horizon.Prepo.Ipc
{
    partial class PrepoService : IPrepoService
    {
        enum PlayReportKind
        {
            Normal,
<<<<<<< HEAD
            System,
        }

        private readonly ArpApi _arp;
        private readonly PrepoServicePermissionLevel _permissionLevel;
        private ulong _systemSessionId;

        private bool _immediateTransmissionEnabled;
        private bool _userAgreementCheckEnabled = true;

        public PrepoService(ArpApi arp, PrepoServicePermissionLevel permissionLevel)
        {
            _arp = arp;
=======
            System
        }

        private readonly PrepoServicePermissionLevel _permissionLevel;
        private ulong _systemSessionId;

        private bool _immediateTransmissionEnabled = false;
        private bool _userAgreementCheckEnabled    = true;

        public PrepoService(PrepoServicePermissionLevel permissionLevel)
        {
>>>>>>> 1ec71635b (sync with main branch)
            _permissionLevel = permissionLevel;
        }

        [CmifCommand(10100)] // 1.0.0-5.1.0
        [CmifCommand(10102)] // 6.0.0-9.2.0
        [CmifCommand(10104)] // 10.0.0+
        public Result SaveReport([Buffer(HipcBufferFlags.In | HipcBufferFlags.Pointer)] ReadOnlySpan<byte> gameRoomBuffer, [Buffer(HipcBufferFlags.In | HipcBufferFlags.MapAlias)] ReadOnlySpan<byte> reportBuffer, [ClientProcessId] ulong pid)
        {
            if ((_permissionLevel & PrepoServicePermissionLevel.User) == 0)
            {
                return PrepoResult.PermissionDenied;
            }

            ProcessPlayReport(PlayReportKind.Normal, gameRoomBuffer, reportBuffer, pid, Uid.Null);

            return Result.Success;
        }

        [CmifCommand(10101)] // 1.0.0-5.1.0
        [CmifCommand(10103)] // 6.0.0-9.2.0
        [CmifCommand(10105)] // 10.0.0+
        public Result SaveReportWithUser(Uid userId, [Buffer(HipcBufferFlags.In | HipcBufferFlags.Pointer)] ReadOnlySpan<byte> gameRoomBuffer, [Buffer(HipcBufferFlags.In | HipcBufferFlags.MapAlias)] ReadOnlySpan<byte> reportBuffer, [ClientProcessId] ulong pid)
        {
            if ((_permissionLevel & PrepoServicePermissionLevel.User) == 0)
            {
                return PrepoResult.PermissionDenied;
            }

            ProcessPlayReport(PlayReportKind.Normal, gameRoomBuffer, reportBuffer, pid, userId, true);

            return Result.Success;
        }

        [CmifCommand(10200)]
        public Result RequestImmediateTransmission()
        {
            _immediateTransmissionEnabled = true;

            // It signals an event of nn::prepo::detail::service::core::TransmissionStatusManager that requests the transmission of the report.
            // Since we don't use reports, it's fine to do nothing.

            return Result.Success;
        }

        [CmifCommand(10300)]
        public Result GetTransmissionStatus(out int status)
        {
            status = 0;

            if (_immediateTransmissionEnabled && _userAgreementCheckEnabled)
            {
                status = 1;
            }

            return Result.Success;
        }

        [CmifCommand(10400)] // 9.0.0+
        public Result GetSystemSessionId(out ulong systemSessionId)
        {
            systemSessionId = default;

            if ((_permissionLevel & PrepoServicePermissionLevel.User) == 0)
            {
                return PrepoResult.PermissionDenied;
            }

            if (_systemSessionId == 0)
            {
                _systemSessionId = (ulong)Random.Shared.NextInt64();
            }

            systemSessionId = _systemSessionId;

            return Result.Success;
        }

        [CmifCommand(20100)]
<<<<<<< HEAD
        public Result SaveSystemReport([Buffer(HipcBufferFlags.In | HipcBufferFlags.Pointer)] ReadOnlySpan<byte> gameRoomBuffer, ApplicationId applicationId, [Buffer(HipcBufferFlags.In | HipcBufferFlags.MapAlias)] ReadOnlySpan<byte> reportBuffer)
=======
        public Result SaveSystemReport([Buffer(HipcBufferFlags.In | HipcBufferFlags.Pointer)] ReadOnlySpan<byte> gameRoomBuffer, Sdk.Ncm.ApplicationId applicationId, [Buffer(HipcBufferFlags.In | HipcBufferFlags.MapAlias)] ReadOnlySpan<byte> reportBuffer)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if ((_permissionLevel & PrepoServicePermissionLevel.System) != 0)
            {
                return PrepoResult.PermissionDenied;
            }

            return ProcessPlayReport(PlayReportKind.System, gameRoomBuffer, reportBuffer, 0, Uid.Null, false, applicationId);
        }

        [CmifCommand(20101)]
<<<<<<< HEAD
        public Result SaveSystemReportWithUser(Uid userId, [Buffer(HipcBufferFlags.In | HipcBufferFlags.Pointer)] ReadOnlySpan<byte> gameRoomBuffer, ApplicationId applicationId, [Buffer(HipcBufferFlags.In | HipcBufferFlags.MapAlias)] ReadOnlySpan<byte> reportBuffer)
=======
        public Result SaveSystemReportWithUser(Uid userId, [Buffer(HipcBufferFlags.In | HipcBufferFlags.Pointer)] ReadOnlySpan<byte> gameRoomBuffer, Sdk.Ncm.ApplicationId applicationId, [Buffer(HipcBufferFlags.In | HipcBufferFlags.MapAlias)] ReadOnlySpan<byte> reportBuffer)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if ((_permissionLevel & PrepoServicePermissionLevel.System) != 0)
            {
                return PrepoResult.PermissionDenied;
            }

            return ProcessPlayReport(PlayReportKind.System, gameRoomBuffer, reportBuffer, 0, userId, true, applicationId);
        }

        [CmifCommand(40100)] // 2.0.0+
        public Result IsUserAgreementCheckEnabled(out bool enabled)
        {
            enabled = false;

            if (_permissionLevel == PrepoServicePermissionLevel.User || _permissionLevel == PrepoServicePermissionLevel.System)
            {
                enabled = _userAgreementCheckEnabled;

                // If "enabled" is false, it sets some internal fields to 0.
                // Then, it mounts "prepo-sys:/is_user_agreement_check_enabled.bin" and returns the contained bool.
                // We can return the private bool instead, we don't care about the agreement since we don't send reports.

                return Result.Success;
            }

            return PrepoResult.PermissionDenied;
        }

        [CmifCommand(40101)] // 2.0.0+
        public Result SetUserAgreementCheckEnabled(bool enabled)
        {
            if (_permissionLevel == PrepoServicePermissionLevel.User || _permissionLevel == PrepoServicePermissionLevel.System)
            {
                _userAgreementCheckEnabled = enabled;

                // If "enabled" is false, it sets some internal fields to 0.
                // Then, it mounts "prepo-sys:/is_user_agreement_check_enabled.bin" and stores the "enabled" value.
                // We can store in the private bool instead, we don't care about the agreement since we don't send reports.

                return Result.Success;
            }

            return PrepoResult.PermissionDenied;
        }

<<<<<<< HEAD
        private Result ProcessPlayReport(PlayReportKind playReportKind, ReadOnlySpan<byte> gameRoomBuffer, ReadOnlySpan<byte> reportBuffer, ulong pid, Uid userId, bool withUserId = false, ApplicationId applicationId = default)
=======
        private static Result ProcessPlayReport(PlayReportKind playReportKind, ReadOnlySpan<byte> gameRoomBuffer, ReadOnlySpan<byte> reportBuffer, ulong pid, Uid userId, bool withUserId = false, Sdk.Ncm.ApplicationId applicationId = default)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (withUserId)
            {
                if (userId.IsNull)
                {
                    return PrepoResult.InvalidArgument;
                }
            }

            if (gameRoomBuffer.Length > 31)
            {
                return PrepoResult.InvalidArgument;
            }

            string gameRoom = Encoding.UTF8.GetString(gameRoomBuffer).TrimEnd();

            if (gameRoom == string.Empty)
            {
                return PrepoResult.InvalidState;
            }

            if (reportBuffer.Length == 0)
            {
                return PrepoResult.InvalidBufferSize;
            }

<<<<<<< HEAD
            StringBuilder builder = new();
=======
            StringBuilder     builder            = new();
>>>>>>> 1ec71635b (sync with main branch)
            MessagePackObject deserializedReport = MessagePackSerializer.UnpackMessagePackObject(reportBuffer.ToArray());

            builder.AppendLine();
            builder.AppendLine("PlayReport log:");
            builder.AppendLine($" Kind: {playReportKind}");

<<<<<<< HEAD
            // NOTE: Reports are stored internally and an event is signaled to transmit them.

=======
            // NOTE: The service calls arp:r using the pid to get the application id, if it fails PrepoResult.InvalidPid is returned.
            //       Reports are stored internally and an event is signaled to transmit them.
>>>>>>> 1ec71635b (sync with main branch)
            if (pid != 0)
            {
                builder.AppendLine($" Pid: {pid}");
            }
            else
            {
                builder.AppendLine($" ApplicationId: {applicationId}");
            }

<<<<<<< HEAD
            Result result = _arp.GetApplicationInstanceId(out ulong applicationInstanceId, pid);
            if (result.IsFailure)
            {
                return PrepoResult.InvalidPid;
            }

            _arp.GetApplicationLaunchProperty(out ApplicationLaunchProperty applicationLaunchProperty, applicationInstanceId).AbortOnFailure();

            builder.AppendLine($" ApplicationVersion: {applicationLaunchProperty.Version}");

=======
>>>>>>> 1ec71635b (sync with main branch)
            if (!userId.IsNull)
            {
                builder.AppendLine($" UserId: {userId}");
            }

            builder.AppendLine($" Room: {gameRoom}");
            builder.AppendLine($" Report: {MessagePackObjectFormatter.Format(deserializedReport)}");

            Logger.Info?.Print(LogClass.ServicePrepo, builder.ToString());

            return Result.Success;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
