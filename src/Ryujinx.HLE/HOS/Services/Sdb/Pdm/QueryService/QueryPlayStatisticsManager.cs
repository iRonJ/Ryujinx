<<<<<<< HEAD
using Ryujinx.Common;
=======
﻿using Ryujinx.Common;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Cpu;
using Ryujinx.HLE.HOS.Services.Account.Acc;
using Ryujinx.HLE.HOS.Services.Sdb.Pdm.QueryService.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Ryujinx.HLE.HOS.Services.Sdb.Pdm.QueryService
{
<<<<<<< HEAD
    class QueryPlayStatisticsManager
    {
        private static readonly Dictionary<UserId, ApplicationPlayStatistics> _applicationPlayStatistics = new();
=======
    static class QueryPlayStatisticsManager
    {
        private static Dictionary<UserId, ApplicationPlayStatistics> applicationPlayStatistics = new Dictionary<UserId, ApplicationPlayStatistics>();
>>>>>>> 1ec71635b (sync with main branch)

        internal static ResultCode GetPlayStatistics(ServiceCtx context, bool byUserId = false)
        {
            ulong inputPosition = context.Request.SendBuff[0].Position;
<<<<<<< HEAD
            ulong inputSize = context.Request.SendBuff[0].Size;

            ulong outputPosition = context.Request.ReceiveBuff[0].Position;
            ulong outputSize = context.Request.ReceiveBuff[0].Size;
=======
            ulong inputSize     = context.Request.SendBuff[0].Size;

            ulong outputPosition = context.Request.ReceiveBuff[0].Position;
            ulong outputSize     = context.Request.ReceiveBuff[0].Size;
>>>>>>> 1ec71635b (sync with main branch)

            UserId userId = byUserId ? context.RequestData.ReadStruct<UserId>() : new UserId();

            if (byUserId)
            {
                if (!context.Device.System.AccountManager.TryGetUser(userId, out _))
                {
                    return ResultCode.UserNotFound;
                }
            }

            PlayLogQueryCapability queryCapability = (PlayLogQueryCapability)context.Device.Processes.ActiveApplication.ApplicationControlProperties.PlayLogQueryCapability;

<<<<<<< HEAD
            List<ulong> titleIds = new();
=======
            List<ulong> titleIds = new List<ulong>();
>>>>>>> 1ec71635b (sync with main branch)

            for (ulong i = 0; i < inputSize / sizeof(ulong); i++)
            {
                titleIds.Add(context.Memory.Read<ulong>(inputPosition));
            }

            if (queryCapability == PlayLogQueryCapability.WhiteList)
            {
                // Check if input title ids are in the whitelist.
                foreach (ulong titleId in titleIds)
                {
                    if (!context.Device.Processes.ActiveApplication.ApplicationControlProperties.PlayLogQueryableApplicationId.ItemsRo.Contains(titleId))
                    {
                        return (ResultCode)Am.ResultCode.ObjectInvalid;
                    }
                }
            }

            MemoryHelper.FillWithZeros(context.Memory, outputPosition, (int)outputSize);

            // Return ResultCode.ServiceUnavailable if data is locked by another process.
<<<<<<< HEAD
            var filteredApplicationPlayStatistics = _applicationPlayStatistics.AsEnumerable();
=======
            var filteredApplicationPlayStatistics = applicationPlayStatistics.AsEnumerable();
>>>>>>> 1ec71635b (sync with main branch)

            if (queryCapability == PlayLogQueryCapability.None)
            {
                filteredApplicationPlayStatistics = filteredApplicationPlayStatistics.Where(kv => kv.Value.TitleId == context.Process.TitleId);
            }
            else // PlayLogQueryCapability.All
            {
                filteredApplicationPlayStatistics = filteredApplicationPlayStatistics.Where(kv => titleIds.Contains(kv.Value.TitleId));
            }

            if (byUserId)
            {
                filteredApplicationPlayStatistics = filteredApplicationPlayStatistics.Where(kv => kv.Key == userId);
            }

            for (int i = 0; i < filteredApplicationPlayStatistics.Count(); i++)
            {
                MemoryHelper.Write(context.Memory, outputPosition + (ulong)(i * Unsafe.SizeOf<ApplicationPlayStatistics>()), filteredApplicationPlayStatistics.ElementAt(i).Value);
            }

            context.ResponseData.Write(filteredApplicationPlayStatistics.Count());

            return ResultCode.Success;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
