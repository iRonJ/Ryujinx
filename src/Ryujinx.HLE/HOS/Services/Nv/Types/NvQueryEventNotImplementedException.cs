<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.Nv.NvDrvServices;
=======
﻿using Ryujinx.HLE.HOS.Services.Nv.NvDrvServices;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Text;

namespace Ryujinx.HLE.HOS.Services.Nv.Types
{
    class NvQueryEventNotImplementedException : Exception
    {
<<<<<<< HEAD
        public ServiceCtx Context { get; }
        public NvDeviceFile DeviceFile { get; }
        public uint EventId { get; }
=======
        public ServiceCtx   Context    { get; }
        public NvDeviceFile DeviceFile { get; }
        public uint         EventId    { get; }
>>>>>>> 1ec71635b (sync with main branch)

        public NvQueryEventNotImplementedException(ServiceCtx context, NvDeviceFile deviceFile, uint eventId)
            : this(context, deviceFile, eventId, "This query event is not implemented.")
        { }

        public NvQueryEventNotImplementedException(ServiceCtx context, NvDeviceFile deviceFile, uint eventId, string message)
            : base(message)
        {
<<<<<<< HEAD
            Context = context;
            DeviceFile = deviceFile;
            EventId = eventId;
=======
            Context    = context;
            DeviceFile = deviceFile;
            EventId    = eventId;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public override string Message
        {
            get
            {
                return base.Message +
                    Environment.NewLine +
                    Environment.NewLine +
                    BuildMessage();
            }
        }

        private string BuildMessage()
        {
<<<<<<< HEAD
            StringBuilder sb = new();
=======
            StringBuilder sb = new StringBuilder();
>>>>>>> 1ec71635b (sync with main branch)

            sb.AppendLine($"Device File: {DeviceFile.GetType().Name}");
            sb.AppendLine();

            sb.AppendLine($"Event ID: (0x{EventId:x8})");

            sb.AppendLine("Guest Stack Trace:");
            sb.AppendLine(Context.Thread.GetGuestStackTrace());

            return sb.ToString();
        }
    }
}
