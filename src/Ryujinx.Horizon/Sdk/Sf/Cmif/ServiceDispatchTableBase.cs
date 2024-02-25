<<<<<<< HEAD
using Ryujinx.Common.Logging;
=======
﻿using Ryujinx.Common.Logging;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Horizon.Common;
using Ryujinx.Horizon.Sdk.Sf.Hipc;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Ryujinx.Horizon.Sdk.Sf.Cmif
{
    abstract class ServiceDispatchTableBase
    {
        private const uint MaxCmifVersion = 1;

        public abstract Result ProcessMessage(ref ServiceDispatchContext context, ReadOnlySpan<byte> inRawData);

<<<<<<< HEAD
        protected static Result ProcessMessageImpl(ref ServiceDispatchContext context, ReadOnlySpan<byte> inRawData, IReadOnlyDictionary<int, CommandHandler> entries, string objectName)
=======
        protected Result ProcessMessageImpl(ref ServiceDispatchContext context, ReadOnlySpan<byte> inRawData, IReadOnlyDictionary<int, CommandHandler> entries, string objectName)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (inRawData.Length < Unsafe.SizeOf<CmifInHeader>())
            {
                Logger.Warning?.Print(LogClass.KernelIpc, $"Request message size 0x{inRawData.Length:X} is invalid");

                return SfResult.InvalidHeaderSize;
            }

            CmifInHeader inHeader = MemoryMarshal.Cast<byte, CmifInHeader>(inRawData)[0];

            if (inHeader.Magic != CmifMessage.CmifInHeaderMagic || inHeader.Version > MaxCmifVersion)
            {
                Logger.Warning?.Print(LogClass.KernelIpc, $"Request message header magic value 0x{inHeader.Magic:X} is invalid");

                return SfResult.InvalidInHeader;
            }

            ReadOnlySpan<byte> inMessageRawData = inRawData[Unsafe.SizeOf<CmifInHeader>()..];
            uint commandId = inHeader.CommandId;

            var outHeader = Span<CmifOutHeader>.Empty;

            if (!entries.TryGetValue((int)commandId, out var commandHandler))
            {
                if (HorizonStatic.Options.IgnoreMissingServices)
                {
                    // If ignore missing services is enabled, just pretend that everything is fine.
                    PrepareForStubReply(ref context, out Span<byte> outRawData);
                    CommandHandler.GetCmifOutHeaderPointer(ref outHeader, ref outRawData);
<<<<<<< HEAD
                    outHeader[0] = new CmifOutHeader { Magic = CmifMessage.CmifOutHeaderMagic, Result = Result.Success };
=======
                    outHeader[0] = new CmifOutHeader() { Magic = CmifMessage.CmifOutHeaderMagic, Result = Result.Success };
>>>>>>> 1ec71635b (sync with main branch)

                    Logger.Warning?.Print(LogClass.Service, $"Missing service {objectName} (command ID: {commandId}) ignored");

                    return Result.Success;
                }
                else if (HorizonStatic.Options.ThrowOnInvalidCommandIds)
                {
                    throw new NotImplementedException($"{objectName} command ID: {commandId} is not implemented");
                }

                return SfResult.UnknownCommandId;
            }

            Logger.Trace?.Print(LogClass.KernelIpc, $"{objectName}.{commandHandler.MethodName} called");

            Result commandResult = commandHandler.Invoke(ref outHeader, ref context, inMessageRawData);

            if (commandResult.Module == SfResult.ModuleId ||
                commandResult.Module == HipcResult.ModuleId)
            {
                Logger.Warning?.Print(LogClass.KernelIpc, $"{commandHandler.MethodName} returned error {commandResult}");
            }

            if (SfResult.RequestContextChanged(commandResult))
            {
                return commandResult;
            }

            if (outHeader.IsEmpty)
            {
                commandResult.AbortOnSuccess();

                return commandResult;
            }

<<<<<<< HEAD
            outHeader[0] = new CmifOutHeader { Magic = CmifMessage.CmifOutHeaderMagic, Result = commandResult };
=======
            outHeader[0] = new CmifOutHeader() { Magic = CmifMessage.CmifOutHeaderMagic, Result = commandResult };
>>>>>>> 1ec71635b (sync with main branch)

            return Result.Success;
        }

        private static void PrepareForStubReply(scoped ref ServiceDispatchContext context, out Span<byte> outRawData)
        {
            var response = HipcMessage.WriteResponse(context.OutMessageBuffer, 0, 0x20 / sizeof(uint), 0, 0);
            outRawData = MemoryMarshal.Cast<uint, byte>(response.DataWords);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
